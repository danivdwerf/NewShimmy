using UnityEngine;
using System.Collections;

public class Patrolling : MonoBehaviour 
{
    [SerializeField] private Transform[] points;
    private int destPoint = 0;
    private UnityEngine.AI.NavMeshAgent agent;

    void Start () 
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.autoBraking = false;
        GotoNextPoint();
    }


    void GotoNextPoint() 
    {
        if (points.Length == 0)
        {
            return;
        }
          
        agent.destination = points[destPoint].position;
        destPoint = (destPoint + 1) % points.Length;
    }


    void Update () 
    {
        if (agent.remainingDistance < 0.5f)
        {
            GotoNextPoint();
        }
    }
}