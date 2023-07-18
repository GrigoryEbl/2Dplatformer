using UnityEngine;

public class CollectCoins : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>())
        {
            Destroy(gameObject);
        }
    }
}
