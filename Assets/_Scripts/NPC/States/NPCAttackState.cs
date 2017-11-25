using UnityEngine;
using UnityEngine.AI;

public class NPCAttackState : NPCBehaviour 
{
    [SerializeField]private float followDistance = 10.0f;
    private bool isAttacking;
    private bool ableToDoDamage;
    private int _attack;

    public override void enter()
    {
        agent.isStopped = true;
        this.isAttacking = false;
        this.ableToDoDamage = false;
        this._attack = Animator.StringToHash("attack");
    }

    public override void update()
    {
        if (this.dead)
            return;

        if (target == null)
            stateHandler.setState(EnemyStates.idle);

        if (this.isAttacking)
            return;
        
        var distance = (transform.position - target.position).sqrMagnitude;
        if (distance > followDistance && !this.isAttacking)
        {
            stateHandler.setState(EnemyStates.follow);
            return;
        }

        if (!this.targetInFront())
        {
            stateHandler.setState(EnemyStates.follow);
            return;
        }

        anim.SetBool(this._attack, true);
        this.isAttacking = true;
    }

    public void AttackEvent(int value)
    {
        if (value == 1)
            this.ableToDoDamage = true;
        else
            this.ableToDoDamage = false;
    }

    public void OnAttackFinish()
    {
        this.isAttacking = false;
        anim.SetBool(this._attack, false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (!this.ableToDoDamage)
            return;

        if (other.tag != Tags.Player)
            return;
        
        //other.gameObject.SendMessage("OnWeaponEnter", SendMessageOptions.DontRequireReceiver);
        //this.ableToDoDamage = false;
    }

    public override void leave()
    {
        this.ableToDoDamage = false;
        this.isAttacking = false;
    }
}
