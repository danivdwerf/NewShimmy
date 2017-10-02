using UnityEngine;

public class PlayerAttack : MonoBehaviour 
{
    private Animator anim;
    private int _attackAnim;

    private void Start()
    {
        this.anim = this.GetComponent<Animator>();
        this._attackAnim = Animator.StringToHash("attack");
    }

    private void Update()
    {
        if (Input.GetButtonDown(Controller.R1))
            this.anim.SetTrigger(this._attackAnim);
    }
}
