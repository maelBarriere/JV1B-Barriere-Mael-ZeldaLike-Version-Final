using UnityEngine;

public class HealPowerUp : MonoBehaviour
{

    PlayerHealth vie;

    private void Start()
    {
        vie = FindObjectOfType<PlayerHealth>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            Debug.Log("zut");
            vie.HealPlayer(vie.currentHealth);
            Destroy(gameObject);
        }
    }
}
