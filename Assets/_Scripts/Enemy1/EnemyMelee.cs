using UnityEngine;
using System.Collections;

public class EnemyMelee : MonoBehaviour 
{
    private EnemySight sight;
    private Animator _animator;
    private int _playerAttackStateHash = Animator.StringToHash("Base Layer.Attack");

    void Start()
    {
        sight = FindObjectOfType<EnemySight>();
        _animator = GetComponentInParent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AnimatorStateInfo info = _animator.GetCurrentAnimatorStateInfo(0);
            if (info.nameHash == _playerAttackStateHash)
            {
                PlayerHealth.health.Hurt(10);
            }
        }
    }
}