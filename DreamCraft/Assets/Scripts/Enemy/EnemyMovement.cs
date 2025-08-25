using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private NavMeshAgent agent;

    private Transform targetTransform;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        agent.speed = speed;
    }

    public void SetTarget(Transform target)
    {
        if (targetTransform == null)
            targetTransform = target;
    }

    private void Update()
    {
        if (targetTransform != null)
            agent.SetDestination(targetTransform.position);
    }
}
