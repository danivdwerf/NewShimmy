using UnityEngine;
using System.Collections;

public class PlayerStates : MonoBehaviour 
{
    [HideInInspector] public bool paused;
    [HideInInspector] public bool saving;
    [HideInInspector] public float level;
    [SerializeField] private AudioClip wow; 

    private AudioSource soundSource;
    public static PlayerStates playerStates;

	void Awake () 
    {
        playerStates = this;
        paused = false;
        saving = false;
        level = 0;

        soundSource = GetComponent<AudioSource>();
        soundSource.clip = wow;
	}

    public void LevelUp()
    {
        level++;
        soundSource.Play();
    }
}
