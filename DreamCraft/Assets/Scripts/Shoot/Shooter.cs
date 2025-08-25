using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField]
    private Pooler pooler;

    [SerializeField]
    private Transform cameraTransform;

    [SerializeField]
    private float shootSpeed;

    private float time;

    private int counter;

    public void ResetTimer()
    {
        time = 0f;
        counter = 0;
    }

    public void Shoot()
    {
        time += Time.deltaTime * shootSpeed;
        if (Mathf.FloorToInt(time) >= counter)
        {
            GameObject bullet = pooler.Spawn("bullet", cameraTransform.position + cameraTransform.forward);
            bullet.GetComponent<BulletMove>().SetRotation(cameraTransform.rotation);
            counter++;
        }
    }
}
