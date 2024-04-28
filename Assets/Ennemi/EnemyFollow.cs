using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform playerTransform;
    public float moveSpeed = 3f;
    public float destroyDistance = 15f; // Distance à laquelle l'ennemi est détruit lorsque le joueur est proche
    public int damageOnCollision = 25;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (playerTransform == null)
        {
            Debug.LogError("Player transform reference is not set!");
        }
    }

    void Update()
    {
        if (playerTransform != null)
        {
            Vector2 direction = (playerTransform.position - transform.position).normalized;
            rb.velocity = direction * moveSpeed;

            // Vérifie si la barre d'espace est enfoncée
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // Calcule la distance entre l'ennemi et le joueur
                float distanceToPlayer = Vector2.Distance(transform.position, playerTransform.position);

                // Vérifie si le joueur est à une certaine distance
                if (distanceToPlayer < destroyDistance)
                {
                    // Détruit l'ennemi si le joueur est à la distance spécifiée
                    Destroy(gameObject);
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageOnCollision);
            }
        }
    }
}