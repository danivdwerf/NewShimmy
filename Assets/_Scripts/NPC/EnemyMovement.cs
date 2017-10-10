using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMovement : MonoBehaviour 
{
    private NavMeshAgent navMeshAgent;
    private Animator anim;
    [SerializeField]private Transform target;

    private void Start()
    {
        this.navMeshAgent = this.GetComponent<NavMeshAgent>();
        this.anim = this.GetComponent<Animator>();
//        this.target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (target == null)
            target = GameObject.FindGameObjectWithTag("Player").transform;
        if (target == null)
            return;
        navMeshAgent.SetDestination(target.position);
        anim.SetFloat("velocity", navMeshAgent.velocity.sqrMagnitude);
//        print(navMeshAgent.velocity.sqrMagnitude);
       
    }

    public void stopMoving(bool value)
    {
        navMeshAgent.isStopped = value;
    }
}
