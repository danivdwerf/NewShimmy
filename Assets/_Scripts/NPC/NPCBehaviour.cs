using UnityEngine;
using UnityEngine.AI;
using System.Collections;

[RequireComponent(typeof(NavMeshAgent), typeof(NPCHealth))]
public abstract class NPCBehaviour : MonoBehaviour 
{
    [SerializeField]protected float attackRange;

    protected NavMeshAgent agent;
    protected Transform target;
    protected Animator anim;

    protected bool isAttacking;
    protected bool dead;

    protected virtual void Start()
    {
        this.dead = false;
        this.isAttacking = false;

        this.anim = this.GetComponent<Animator>();
        this.agent = this.GetComponent<NavMeshAgent>();
        agent.stoppingDistance = this.attackRange;
        agent.isStopped = false;
        agent.autoBraking = false;
    }

    protected virtual void Update()
    {
        if (this.dead)
            return;

        anim.SetFloat("velocity", agent.velocity.sqrMagnitude, 0.5f, Time.deltaTime);
        this.dead = anim.GetBool("dead");

        if (this.target == null)
            return;

        if (isAttacking)
            return;


        rotateTowardsTarget();
        movementHandler();
        attackHandler();
    }

    protected virtual void rotateTowardsTarget()
    {
        var targetDirection = target.position - this.transform.position;
        var targetRotation = Quaternion.LookRotation (targetDirection, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 1.0f);
    }

    protected virtual void movementHandler()
    {
        agent.SetDestination(target.position);
    }

    protected virtual void attackHandler()
    {
        var direction = transform.position - target.position;
        if (direction.sqrMagnitude > attackRange)
            return;

        anim.SetBool("attack", true);
        isAttacking = true;
        agent.isStopped = true;
    }

    public virtual void OnAttackFinish()
    {
        anim.SetBool("attack", false);
        isAttacking = false;
        agent.isStopped = false;
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (this.target != null)
            return;

        if (other.tag != Tags.Player)
            return;

        if (other.isTrigger)
            return;

        this.target = other.transform;
    }

    protected virtual void OnTriggerExit(Collider other)
    {
        if (other.tag != Tags.Player)
            return;

        if (other.isTrigger)
            return;

        this.target = null;
    }
}
