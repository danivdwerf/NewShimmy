using System.Collections.Generic;
using UnityEngine;

public class NPCStateHandler : MonoBehaviour 
{
    private Dictionary<EnemyStates, NPCBehaviour> states;
    private NPCBehaviour currentBehaviour;

    private void Awake()
    {
        this.states = new Dictionary<EnemyStates, NPCBehaviour>();
        this.currentBehaviour = null;
    }

    public void setState(EnemyStates state)
    {
        if (!states.ContainsKey(state))
            return;

        if (this.currentBehaviour != null)
            this.currentBehaviour.leave();
        
        this.currentBehaviour = this.states[state];
        this.currentBehaviour.enter();
    }

    public void addState(EnemyStates id, NPCBehaviour command)
    {
        this.states.Add(id, command);
    }

    private void Update()
    {
        if (this.currentBehaviour == null)
            return;
        
        this.currentBehaviour.update();
    }
}
