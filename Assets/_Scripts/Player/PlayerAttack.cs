using UnityEngine;

public class PlayerAttack : MonoBehaviour 
{
    private Animator anim;
    private int _attackAnim;

    private int attackState;

    private void Start()
    {
        this.anim = this.GetComponent<Animator>();
        this._attackAnim = Animator.StringToHash("attack");

        this.attackState = 0;
    }

    private void Update()
    {
        if (Input.GetButtonDown(Controller.R1))
            this.anim.SetTrigger(this._attackAnim);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (attackState == 0)
            return;

        other.gameObject.SendMessage("OnWeaponEnter", SendMessageOptions.DontRequireReceiver);
    }

    void AttackEvent(int value)
    {
        this.attackState = value;
    }
}
