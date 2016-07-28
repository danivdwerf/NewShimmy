using UnityEngine;
using System.Collections;

public class PlayerStates : MonoBehaviour 
{
    [HideInInspector] public bool paused;
    [HideInInspector] public bool equip;
    [HideInInspector] public bool saving;
    [HideInInspector] public bool upgrading;
    [HideInInspector] public float level;

    public static PlayerStates playerStates;

	void Awake () 
    {
        playerStates = this;
        paused = false;
        equip = false;
        saving = false;
        upgrading = false;
        level = 0;
	}

    public void LevelUp()
    {
        level++;
    }
}
