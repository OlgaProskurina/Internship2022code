using UnityEngine;

public class Heart : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Damagaeble>().Cure(5);
            Destroy(gameObject);
        }
    }

}
