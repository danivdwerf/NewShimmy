using UnityEngine;
using UnityEngine.AI;

public class NPCFollowState : NPCBehaviour 
{
    [SerializeField]private float attackDistance = 10.0f;
    public override void enter()
    {
        //print("follow");
        agent.stoppingDistance = this.attackDistance;
        agent.isStopped = false;
    }

    public override void update()
    {
        if (this.dead)
            return;

        if (this.target == null)
            stateHandler.setState(EnemyStates.idle);

        print("following");
        agent.SetDestination(target.position);
        anim.SetFloat("velocity", agent.velocity.sqrMagnitude, 0.5f, Time.deltaTime);
        this.dead = anim.GetBool("dead");

        var distance = (this.transform.position - target.position).sqrMagnitude;
        if (distance > attackDistance)
            return;
        stateHandler.setState(EnemyStates.attack);
    }

    public override void leave()
    {
        agent.isStopped = true;
    }
}
