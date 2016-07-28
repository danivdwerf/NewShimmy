using UnityEngine;
using System.Collections;

public class PlayerStates : MonoBehaviour 
{
    [HideInInspector] public bool paused;
    [HideInInspector] public bool saving;
    [HideInInspector] public float level;

    public static PlayerStates playerStates;

	void Awake () 
    {
        playerStates = this;
        paused = false;
        saving = false;
        level = 0;
	}

    public void LevelUp()
    {
        level++;
    }
}
