using UnityEngine;
using UnityEngine.AI;

public class NPCIdleState : NPCBehaviour 
{
    public override void enter()
    {
        print("idle");
        agent.isStopped = true;
    }

    public override void update()
    {
        if (this.dead)
            return;
        
        if (target == null)
            return;
        
        this.stateHandler.setState(EnemyStates.follow);
    }
}
