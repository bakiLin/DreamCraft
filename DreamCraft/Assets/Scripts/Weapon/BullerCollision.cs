using UnityEngine;

public class BullerCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy"))
            collision.gameObject.SetActive(false);

        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
            other.gameObject.SetActive(false);

        gameObject.SetActive(false);
    }
}
