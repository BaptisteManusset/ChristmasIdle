using System;
using System.Collections;
using UnityEngine;
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

    public Vector2 destination;

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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(destination, .25f);
        Gizmos.DrawWireSphere(startPosition, wanderRange);
    }
}