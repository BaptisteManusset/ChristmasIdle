using NaughtyAttributes;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

public class RabbitWander : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f; // Vitesse de déplacement
    [SerializeField] private float wanderRange = 5f; // Distance maximale à parcourir autour du point de départ
    [SerializeField] private float idleTime = 2f; // Temps d'attente entre deux déplacements
    [SerializeField] private LayerMask groundLayer; // Masque des tiles
    [SerializeField] private float groundCheckDistance = 0.1f; // Distance pour vérifier la présence de sol

    private Vector2 startPosition;
    private bool isMoving;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
        rb.simulated = true;
    }

    [Button]
    private void FindNextPosition()
    {
        // Tilemap tm = TilemapHandler.Instance.GetCurrentTilemap();

        tilemap = GetComponentInParent<Tilemap>();
        // Vector3Int coor = tm.WorldToCell(transform.position);
        // TileBase tile = tm.GetTile(coor);

        nextPos = transform.position + Vector3Int.right * Random.Range(-3, 4);
        // tile = tilemap.GetTileWorld(nextPos);
        // bottom = tilemap.GetTileWorld(nextPos + Vector3.down);

        // path = PathExist(tilemap, tilemap.WorldToCell(nextPos), tilemap.WorldToCell(transform.position));
    }

    bool path;
    Tilemap tilemap;
    public TileBase bottom;
    public Vector3 nextPos;

    private void OnDrawGizmos()
    {
        Gizmos.color = bottom == null ? Color.red : Color.green;
        Gizmos.DrawWireSphere(nextPos, .25f);
        Gizmos.DrawLine(nextPos, transform.position);

        HavePath(transform.position, nextPos);
    }

    private void HavePath(Vector3 a_posA, Vector3 a_posB)
    {


        if (a_posA.x >= a_posB.x)
        {
            (a_posA, a_posB) = (a_posB, a_posA);
        }

        var posA = tilemap.WorldToCell(a_posA);
        var posB = tilemap.WorldToCell(a_posB);
        int distance = posB.x - posA.x;

        Vector3 offset = new(.5f, .5f, 0);
        for (int i = 0; i < distance; i++)
        {
            TileBase path1 = tilemap.GetTile(posA + Vector3Int.right * i);
            TileBase ground = tilemap.GetTile(posA + Vector3Int.right * i + Vector3Int.down);

            Gizmos.color = path1 ? Color.red : Color.green;
            Gizmos.DrawSphere(posA + Vector3Int.right * i + offset, .25f);
            if (path1) continue;

            Gizmos.color = ground ? Color.green : Color.red;
            Gizmos.DrawSphere(posA + Vector3Int.right * i + Vector3Int.down + offset, .1f);
        }
    }

    private void Update()
    {
        if (Random.value > .5f) return;
        destination = GetRandomPosition();

        if (Vector2.Distance(destination, transform.position) <= .25f)
        {
            destination = GetRandomPosition();
        }

        MoveTowards(destination);
    }

    public Vector3 destination;


    private void MoveTowards(Vector2 targetPosition)
    {
        Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;
        rb.velocity = new Vector2(direction.x * moveSpeed, rb.velocity.y);

        // Retourne le sprite selon la direction
        if (direction.x > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (direction.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);
    }

    private Vector2 GetRandomPosition()
    {
        Vector2 randomOffset = new Vector2(Random.Range(-wanderRange, wanderRange), 0);
        Vector2 targetPosition = startPosition + randomOffset;

        // S'assure que la position est sur le sol
        if (!IsGroundBelow(targetPosition))
        {
            return transform.position;
        }

        return targetPosition;
    }

    private bool IsGroundBelow(Vector2 position)
    {
        RaycastHit2D hit = Physics2D.Raycast(position, Vector2.down, groundCheckDistance, groundLayer);
        return hit.collider != null;
    }
}