using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField]
    private Transform playerTransform;

    [SerializeField]
    private float speed, limitRotation;

    private PlayerInput playerInput;

    private Vector2 rotation;

    private Vector3 offset;

    private void Awake()
    {
        playerInput = playerTransform.GetComponent<PlayerInput>();
        offset = transform.position - playerTransform.position;
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        transform.position = playerTransform.position + offset;
        Rotate();
    }

    private void Rotate()
    {
        rotation += Time.deltaTime * speed * playerInput.GetRotation();
        rotation.y = Mathf.Clamp(rotation.y, -limitRotation, limitRotation);

        var xQuat = Quaternion.AngleAxis(rotation.x, Vector3.up);
        var yQuat = Quaternion.AngleAxis(rotation.y, Vector3.left);

        transform.localRotation = xQuat * yQuat;
    }
}
