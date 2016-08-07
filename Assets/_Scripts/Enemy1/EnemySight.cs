using UnityEngine;
using System.Collections;

public class EnemySight : MonoBehaviour 
{
    public RaycastHit hit;
    private GameObject player;
    private EnemyHealth enemyHP;
    private EnemyAI ai;
    [HideInInspector] public bool attack;
    [HideInInspector] public static EnemySight sight;

    void Start()
    {
        sight = this;
        enemyHP = GetComponent<EnemyHealth>();
        player = GameObject.FindGameObjectWithTag("Player");
        ai = GetComponent<EnemyAI>();
        attack = false;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && !enemyHP.isDead)
        {
            transform.LookAt(transform.position + player.transform.rotation * Vector3.forward, player.transform.rotation * Vector3.up);
            Vector3 direction = other.transform.position - transform.position;

            if (Physics.Raycast(transform.position, direction.normalized, out hit))
            {
                if (hit.collider.gameObject == player)
                {
                    if (hit.distance <= 9 && hit.distance > 2.5f)
                    {
                        ai.Chase();
                        attack = false;
                    }
                    else if (hit.distance <= 2.5f)
                    {
                        ai.Attack();
                        attack = true;
                    }
                    else
                    {
                        ai.Idle();
                        attack = false;
                    }
                }
            }
        }
    }
}
