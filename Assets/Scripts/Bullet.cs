using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Enemy"))
        {
            collision.collider.GetComponent<Damagaeble>().TakeDamage(10);
        }
        Destroy(gameObject);
    }
}
