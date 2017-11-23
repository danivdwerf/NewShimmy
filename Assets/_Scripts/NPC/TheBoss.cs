using System.Collections.Generic;
using UnityEngine;

public enum EnemyStates
{
    NullCommand,
    idle,
    follow,
    attack
}

public class TheBoss : MonoBehaviour 
{
    private NPCStateHandler states;

    private void Start()
    {
        this.states = GetComponent<NPCStateHandler> ();
        this.setStates();
        states.setState(EnemyStates.idle);
    }

    private void setStates()
    {
        states.addState (EnemyStates.idle, GetComponent<NPCIdleState>());
        states.addState (EnemyStates.follow, GetComponent<NPCFollowState>());
        states.addState(EnemyStates.attack, GetComponent<NPCAttackState>());
    }
}