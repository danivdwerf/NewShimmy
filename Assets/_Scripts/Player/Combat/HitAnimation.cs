﻿using UnityEngine;
using System.Collections;

public class HitAnimation : MonoBehaviour 
{
	//Animator anim;
	//int hit = Animator.StringToHash("Hit");

	// Use this for initialization
	void Start () 
	{
		//anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButtonDown (0)) 
		{
			//anim.SetTrigger (hit);
		}
	}
}
