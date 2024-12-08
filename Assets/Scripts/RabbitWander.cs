using System;
using DG.Tweening;
using NaughtyAttributes;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

public class RabbitWander : MonoBehaviour
{
    public int maxDistance = 4;
    public int direction = 0;
    Tilemap tilemap;

    public Vector3Int end;

    public float speed = .1f;

    public float duration;
    public float progress;

    [MinMaxSlider(0, 10)] public Vector2 waitTime;

    public bool moving;

    public Vector3 destination;

    public Vector3 origin;

    private void Awake()
    {
        tilemap = GetComponentInParent<Tilemap>();
    }

    private void OnEnable()
    {
        Test();
    }

    public float distance;
    public AnimationCurve jumpProfil;

    private void Update()
    {
        if (moving)
        {
            if (progress >= duration)
            {
                progress = 0;
                moving = false;
                OnComplete();
            }
            else
            {
                progress += Time.deltaTime * speed / distance;

                Vector3 newPosition = new(
                    math.lerp(origin.x, destination.x, progress),
                    origin.y + jumpProfil.Evaluate(progress));
                transform.position = newPosition;
            }
        }
    }

    [Button]
    public void Test()
    {
        Vector3Int randomPos = Vector3Int.right * Random.Range(-maxDistance, maxDistance + 1);


        Vector3Int originCell = tilemap.WorldToCell(transform.position);
        end = HavePath(originCell, originCell + randomPos);
        if (originCell != end)
        {
            moving = true;
            destination = tilemap.GetCellCenterWorld(end);
            origin = transform.position;
            distance = Math.Abs(end.x - origin.x);
            duration = 1;
        }
        else
        {
            OnComplete();
        }
    }

    private void OnComplete()
    {
        Debug.Log("Complete");
        Invoke(nameof(Test), Random.Range(waitTime.x, waitTime.y));
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