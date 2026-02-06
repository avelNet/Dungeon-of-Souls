using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponentInParent<EnemyHealth>().Die();
        }
    }
}
