using UnityEngine;
using UnityEngine.AI;

public class MonsterAI : MonoBehaviour
{
    public Transform player;
    public float sightRange = 10f;
    public float runRange = 3f;
    public float patrolRadius = 15f;
    public float patrolWaitTime = 3f;

    Animator animator;
    NavMeshAgent agent;
    Vector3 patrolTarget;
    float patrolTimer;

    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        patrolTimer = 0f;
        SetNewPatrolTarget();
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Future: Check if player is hiding
        bool playerIsHiding = false; // Placeholder for hiding spot logic

        if (!playerIsHiding && distanceToPlayer <= sightRange)
        {
            if (distanceToPlayer <= runRange)
            {
                // Run toward player
                agent.speed = 6f;
                agent.SetDestination(player.position);
                animator.SetBool("Z_Idle", false);
                animator.SetBool("Z_Walk1", false);
                animator.SetBool("Z_Run", true);
            }
            else
            {
                // Walk toward player
                agent.speed = 3.5f;
                agent.SetDestination(player.position);
                animator.SetBool("Z_Idle", false);
                animator.SetBool("Z_Walk1", true);
                animator.SetBool("Z_Run", false);
            }
        }
        else
        {
            // Patrol
            Patrol();
        }
    }

    void Patrol()
    {
        agent.speed = 2f;
        animator.SetBool("Z_Idle", false);
        animator.SetBool("Z_Walk1", true);
        animator.SetBool("Z_Run", false);

        if (Vector3.Distance(transform.position, patrolTarget) < 1f)
        {
            patrolTimer += Time.deltaTime;
            if (patrolTimer >= patrolWaitTime)
            {
                SetNewPatrolTarget();
                patrolTimer = 0f;
            }
            else
            {
                agent.SetDestination(transform.position);
                animator.SetBool("Z_Idle", true);
                animator.SetBool("Z_Walk1", false);
            }
        }
        else
        {
            agent.SetDestination(patrolTarget);
        }
    }

    void SetNewPatrolTarget()
    {
        Vector3 randomDirection = Random.insideUnitSphere * patrolRadius;
        randomDirection += transform.position;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomDirection, out hit, patrolRadius, 1))
        {
            patrolTarget = hit.position;
        }
        else
        {
            patrolTarget = transform.position;
        }
    }
}
