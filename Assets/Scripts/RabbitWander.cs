using NaughtyAttributes;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

public class RabbitWander : MonoBehaviour
{
    public int maxDistance = 4;
    public int direction = 0;
    Tilemap tilemap;

    public Vector3Int end;

    public float speed = .1f;

    [MinMaxSlider(0, 10)] public Vector2 waitTime;

    public bool moving;

    public Vector3 destination;

    public Vector3 origin;
    private Rigidbody2D rb;


    public Vector3Int CurrentCell
    {
        get
        {
            if (tilemap == null) tilemap = GetComponentInParent<Tilemap>();
            return tilemap.WorldToCell(transform.position);
        }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        tilemap = GetComponentInParent<Tilemap>();
    }

    private void OnEnable()
    {
        StartNewMovement();
    }

    private bool isFalling = false;
    private void Update()
    {
        if (IsFalling())
        {
            moving = false;
            isFalling = true;
            return;
        }

        if (isFalling)
        {
            OnComplete();
            isFalling = false;
        }

        if (moving)
        {
            if (Vector2.Distance(rb.position, destination) <= .1f)
            {
                moving = false;
                OnComplete();
            }
            else
            {
                rb.MovePosition(rb.position + Vector2.right * (direction * speed * Time.deltaTime));
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(destination, .1f);
        Gizmos.DrawLine(destination, transform.position);
    }

    private bool IsFalling()
    {
        return rb.velocity.y < 0;
    }

#if UNITY_EDITOR
    [Button]
#endif
    public void StartNewMovement()
    {
        Vector3Int randomPos = Vector3Int.right * Random.Range(-maxDistance, maxDistance + 1);


        Vector3Int originCell = CurrentCell;
        end = HavePath(originCell, originCell + randomPos);
        if (originCell != end)
        {
            moving = true;
            destination = tilemap.GetCellCenterWorld(end);
            origin = transform.position;
        }
        else
        {
            OnComplete();
        }
    }

    private void OnComplete()
    {
        Invoke(nameof(StartNewMovement), Random.Range(waitTime.x, waitTime.y));
    }

    private Vector3Int HavePath(Vector3Int a_start, Vector3Int a_end)
    {
        if (a_start == a_end) return a_start;
        int distance = a_end.x - a_start.x;
        direction = (int)math.sign(distance);


        Vector3Int previous = a_start;
        for (int i = 0; i != (a_end.x - a_start.x) + direction; i += direction)
        {
            Vector3Int point = a_start + Vector3Int.right * i;
            bool path = tilemap.GetTile(point) == null;
            bool ground = tilemap.GetTile(point + Vector3Int.down);
            Debug.DrawRay(tilemap.GetCellCenterWorld(point), Vector3.up, ground ? Color.green : Color.red, .2f);
            Debug.DrawRay(tilemap.GetCellCenterWorld(point), Vector3.up, path ? Color.green : Color.red, .2f);


            if (!ground || !path)
            {
                return previous;
            }

            previous = point;
        }

        return a_end;
    }
}