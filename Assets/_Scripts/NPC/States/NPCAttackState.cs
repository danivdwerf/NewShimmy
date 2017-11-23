using UnityEngine;
using UnityEngine.AI;

public class NPCAttackState : NPCBehaviour 
{
    [SerializeField]private float followDistance = 20.0f;

    public override void enter()
    {
        agent.isStopped = true;
    }

    public override void update()
    {
        if (this.dead)
            return;

        if (target == null)
            stateHandler.setState(EnemyStates.idle);
        
        var distance = (transform.position - target.position).sqrMagnitude;
        if (distance > followDistance)
            stateHandler.setState(EnemyStates.follow);

        anim.SetBool("attack", true);
    }

    public override void leave()
    {

    }
}
