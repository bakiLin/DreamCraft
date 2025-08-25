using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    [SerializeField]
    private float damage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var health = other.GetComponent<PlayerHealth>();
            health.Hit(damage);
            gameObject.SetActive(false);
        }
    }
}
