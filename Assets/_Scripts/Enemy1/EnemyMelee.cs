using UnityEngine;
using System.Collections;

public class EnemyMelee : MonoBehaviour 
{
    private AnimationEvent animEvent;
    private Animator _animator;
    private int _playerAttackStateHash = Animator.StringToHash("Base Layer.Attack");

    void Start()
    {
        animEvent = GetComponentInParent<AnimationEvent>();
        _animator = GetComponentInParent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Checks if attack animation is playing
            AnimatorStateInfo info = _animator.GetCurrentAnimatorStateInfo(0);
            if (info.nameHash == _playerAttackStateHash)
            {
                //checks if the animation Event gave through the number I set up
                if (animEvent.number == 1)
                {
                    PlayerHealth.health.Hurt(30);
                }
            }
        }
    }
}