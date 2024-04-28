using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform playerTransform;
    public float moveSpeed = 3f;
    public float destroyDistance = 15f; // Distance � laquelle l'ennemi est d�truit lorsque le joueur est proche
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

            // V�rifie si la barre d'espace est enfonc�e
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // Calcule la distance entre l'ennemi et le joueur
                float distanceToPlayer = Vector2.Distance(transform.position, playerTransform.position);

                // V�rifie si le joueur est � une certaine distance
                if (distanceToPlayer < destroyDistance)
                {
                    // D�truit l'ennemi si le joueur est � la distance sp�cifi�e
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