using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private Transform cameraTransform;

    private PlayerInput playerInput;

    private Rigidbody rb;

    private Vector3 direction;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        var input = playerInput.GetMoveDirection();
        direction = cameraTransform.forward * input.y + cameraTransform.right * input.x;
        direction.Normalize();
    }

    private void FixedUpdate()
    {
        rb.velocity = speed * direction;
    }
}
