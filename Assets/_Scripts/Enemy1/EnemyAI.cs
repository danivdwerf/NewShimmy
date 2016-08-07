using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour 
{
    private GameObject player;
    private NavMeshAgent nav;
    [SerializeField] private Animator anim;

    void Start()
    {
        anim.SetBool("attack", false);
        anim.SetBool("walk", false);
        anim.SetBool("idle", true);
        nav = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Chase()
    {
        nav.Resume();
        nav.destination = player.transform.position;
        anim.SetBool("attack", false);
        anim.SetBool("walk", true);
    }

    public void Attack()
    {
        nav.Stop();
        anim.SetBool("attack", true);
        anim.SetBool("walk", false);
        anim.SetBool("idle", false);
    }

    public void Idle()
    {
        nav.Stop();
        anim.SetBool("attack", false);
        anim.SetBool("walk", false);
        anim.SetBool("idle", true);
    }
}