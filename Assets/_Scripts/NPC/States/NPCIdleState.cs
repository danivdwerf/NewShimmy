using UnityEngine;
using UnityEngine.AI;

public class NPCIdleState : NPCBehaviour 
{
    private int _velocity;
    private int _dead;

    public override void enter()
    {
        this._velocity = Animator.StringToHash("velocity");
        this._dead = Animator.StringToHash("dead");
        agent.isStopped = true;
    }

    public override void update()
    {
        if (this.dead)
            return;

        this.dead = anim.GetBool(_dead);
        anim.SetFloat(this._velocity, agent.velocity.sqrMagnitude, 0.5f, Time.deltaTime);

        if (this.target == null)
            return;

        stateHandler.setState(EnemyStates.follow);
    }
}
