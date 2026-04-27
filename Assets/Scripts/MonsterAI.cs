using UnityEngine;
using UnityEngine.AI;

public class MonsterAI : MonoBehaviour
{
    public Transform player;
    public Transform[] patrolPoints;

    public float viewDistance = 10f;
    public float viewAngle = 70f;
    public float patrolSpeed = 1.5f;
    public float chaseSpeed = 3.5f;

    private NavMeshAgent agent;
    private int currentPoint = 0;
    private bool chasing = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = patrolSpeed;

        if (patrolPoints.Length > 0)
            agent.SetDestination(patrolPoints[currentPoint].position);
    }

    void Update()
    {
        if (CanSeePlayer())
        {
            chasing = true;
        }

        if (chasing)
        {
            ChasePlayer();
        }
        else
        {
            Patrol();
        }
    }

    void Patrol()
    {
        agent.speed = patrolSpeed;

        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            currentPoint = (currentPoint + 1) % patrolPoints.Length;
            agent.SetDestination(patrolPoints[currentPoint].position);
        }
    }

    void ChasePlayer()
    {
        agent.speed = chaseSpeed;
        agent.SetDestination(player.position);

        if (!CanSeePlayer())
        {
            chasing = false;
            agent.SetDestination(patrolPoints[currentPoint].position);
        }
    }

    bool CanSeePlayer()
    {
        Vector3 dirToPlayer = player.position - transform.position;

        if (dirToPlayer.magnitude > viewDistance)
            return false;

        float angle = Vector3.Angle(transform.forward, dirToPlayer);

        if (angle > viewAngle / 2f)
            return false;

        Ray ray = new Ray(transform.position + Vector3.up * 1.5f, dirToPlayer.normalized);

        if (Physics.Raycast(ray, out RaycastHit hit, viewDistance))
        {
            if (hit.transform == player)
                return true;
        }

        return false;
    }
}