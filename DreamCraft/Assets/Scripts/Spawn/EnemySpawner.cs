using UnityEngine;
using Random = System.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private Pooler pooler;

    [SerializeField]
    private Transform playerTransform;

    private Random random = new Random();

    private int cooldown;

    private float time;

    private void Start()
    {
        cooldown = random.Next(5, 10);
    }

    private void Update()
    {
        if (time < cooldown)
            time += Time.deltaTime;
        else
        {
            time = 0f;
            cooldown = random.Next(5, 10);

            var spawnPosition = new Vector3(random.Next(-35, 35), 1f, random.Next(-35, 35));
            GameObject enemy = pooler.Spawn("enemy", spawnPosition);
            enemy.GetComponent<EnemyMovement>().SetTarget(playerTransform);
        }
    }
}
