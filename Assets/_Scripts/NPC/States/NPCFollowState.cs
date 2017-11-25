using UnityEngine;
using UnityEngine.AI;

public class NPCFollowState : NPCBehaviour 
{
    [SerializeField]private float attackDistance = 10.0f;
    [SerializeField]private float rotationSpeed = 5.0f;

    private int _dead;
    private int _velocity;

    public override void enter()
    {
        agent.stoppingDistance = this.attackDistance;
        agent.isStopped = false;

        this._dead = Animator.StringToHash("dead");
        this._velocity = Animator.StringToHash("velocity");
    }

    public override void update()
    {
        if (this.dead)
            return;

        if (this.target == null)
        {
            stateHandler.setState(EnemyStates.idle);
            return;
        }

        agent.SetDestination(target.position);
        this.rotateTowardsTarget();
        anim.SetFloat(_velocity, agent.velocity.sqrMagnitude, 0.5f, Time.deltaTime);
        this.dead = anim.GetBool(_dead);

        var distance = (this.transform.position - target.position).sqrMagnitude;
        if (distance > this.attackDistance && this.targetInFront())
            return;
        
        stateHandler.setState(EnemyStates.attack);
    }

    private void rotateTowardsTarget()
    {
        Vector3 lookrotation = agent.steeringTarget - transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookrotation), this.rotationSpeed * Time.deltaTime);
    }

    public override void leave()
    {
        agent.isStopped = true;
    }
}
