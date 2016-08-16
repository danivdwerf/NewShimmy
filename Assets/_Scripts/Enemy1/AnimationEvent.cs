using UnityEngine;
using System.Collections;

public class AnimationEvent : MonoBehaviour 
{
    [HideInInspector] public int number;
    void Start()
    {
        number = 0;
    }

    public void SwitchAttack(int checkcol)
    {
        number = checkcol;
    }
}
