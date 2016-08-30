using UnityEngine;
using System.Collections;

public class EnemySight : MonoBehaviour 
{
    public RaycastHit hit;
    private GameObject player;
    private EnemyHealth enemyHP;
    private EnemyAI ai;
    [HideInInspector] public static EnemySight sight;

    void Start()
    {
        sight = this;
        enemyHP = GetComponent<EnemyHealth>();
        player = GameObject.FindGameObjectWithTag("Player");
        ai = GetComponent<EnemyAI>();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && !enemyHP.isDead)
        {   
            Vector3 direction = other.transform.position - transform.position;

            if (Physics.Raycast(transform.position, direction.normalized, out hit))
            {
                if (hit.collider.gameObject == player)
                {
                    if (hit.distance > 10)
                    {
                        ai.Idle();
                    }
                    if (hit.distance <= 10 && hit.distance >3)
                    {
                        transform.LookAt(player.transform);
                        ai.Chase();
                    }
                    else if (hit.distance <= 3)
                    {
                        ai.Attack();
                    }
                }
            }
        }
    }
}
