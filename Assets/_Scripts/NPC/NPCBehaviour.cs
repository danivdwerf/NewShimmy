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
    protected HealthUI healthUI;

    public virtual void Awake()
    {
        this.stateHandler = this.GetComponent<NPCStateHandler>();
        this.healthUI = this.GetComponent<HealthUI>();
        this.agent = this.GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        this.target = null;
        this.anim = this.GetComponent<Animator>();
        this.dead = false;
    }

    public virtual void enter(){}
    public abstract void update();
    public virtual void leave(){}

    protected bool targetInFront()
    {
        var dir = target.position - this.transform.position;
        var dotProduct = Vector3.Dot(dir, this.transform.forward);
        if (dotProduct < 0.8f)
            return false;
        return true;
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (this.dead)
            return;
        
        if (this.target != null)
            return;

        if (other.tag != Tags.Player)
            return;

        if (other.isTrigger)
            return;

        healthUI.showUI(true);
        this.target = other.transform;
    }

    protected virtual void OnTriggerExit(Collider other)
    {
        if (other.tag != Tags.Player)
            return;

        if (other.isTrigger)
            return;

        healthUI.showUI(false);
        this.target = null;
    }

}
