using UnityEngine;

public class NPCAttack : MonoBehaviour 
{
//    private Animator anim;
    private int attackState;

    private void Start()
    {
//        this.anim = this.GetComponent<Animator>();
        this.attackState = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (attackState == 0)
            return;

        print("player hit");
        other.gameObject.SendMessage("OnWeaponEnter", SendMessageOptions.DontRequireReceiver);
    }

    void AttackEvent(int value)
    {
        this.attackState = value;
    }
}
