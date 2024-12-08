using DG.Tweening;
using NaughtyAttributes;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

public class RabbitWander : MonoBehaviour
{
    public int maxDistance = 4;
    public Vector3Int nextPos;
    public int direction = 0;
    public Vector3Int destination;
    Tilemap tilemap;

    public Vector3Int end;

    public float speed = .1f;


    [Button]
    public void Test()
    {
        tilemap = GetComponentInParent<Tilemap>();
        Vector3Int randomPos = Vector3Int.right * Random.Range(-maxDistance, maxDistance + 1);


        Vector3Int origin = tilemap.WorldToCell(transform.position);
        end = HavePath(
            origin,
            origin + randomPos);
        if (origin != end)
        {
            transform.DOMove(tilemap.GetCellCenterWorld(end), speed);
        }
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