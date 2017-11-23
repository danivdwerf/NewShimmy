using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public abstract class NPCBehaviour : MonoBehaviour 
{
    protected NPCStateHandler stateHandler; 
    protected NavMeshAgent agent;
    protected Transform target;
    protected Animator anim;
    protected bool dead;

    public virtual void Start()
    {
        this.stateHandler = this.GetComponent<NPCStateHandler>();
        this.agent = this.GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        this.target = null;
        this.anim = this.GetComponent<Animator>();
        this.dead = false;
    }

    public virtual void enter(){}
    public abstract void update();
    public virtual void leave(){}

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (this.target != null)
            return;

        if (other.tag != Tags.Player)
            return;

        if (other.isTrigger)
            return;

        this.target = other.transform;
    }

    protected virtual void OnTriggerExit(Collider other)
    {
        if (other.tag != Tags.Player)
            return;

        if (other.isTrigger)
            return;

        this.target = null;
    }

}
