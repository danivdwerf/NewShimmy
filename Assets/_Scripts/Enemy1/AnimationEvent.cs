using UnityEngine;
using System.Collections;

public class AnimationEvent : MonoBehaviour 
{
    [HideInInspector] public int number;
    [HideInInspector] public int hurt;
    void Start()
    {
        hurt = 0;
        number = 0;
    }

    public void SwitchAttack(int checkcol)
    {
        number = checkcol;
    }

    public void Hurting(int i)
    {
        hurt= i;
    }
}
