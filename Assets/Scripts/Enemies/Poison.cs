using UnityEngine;

public class Poison : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.collider.CompareTag("Enemy"))
        {
            if (collision.collider.CompareTag("Player"))
            {
                collision.collider.GetComponent<Damagaeble>().TakeDamage(10);
            }
            Destroy(gameObject);
        }
    }
}
