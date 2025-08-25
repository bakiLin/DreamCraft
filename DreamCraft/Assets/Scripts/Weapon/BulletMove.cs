using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void SetRotation(Quaternion rotation)
    {
        transform.rotation = rotation;
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.forward * speed;
    }
}
