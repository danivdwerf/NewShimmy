﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour 
{
    [HideInInspector] public float health; 
    [HideInInspector] public float maxHealth;
    [HideInInspector] public bool isDead;
    [SerializeField] private GameObject cbt;
    private Animator anim;

    public static EnemyHealth enemyHP;

	private void Awake()
	{
        enemyHP = this;
        anim = GetComponentInChildren<Animator>();

        maxHealth = 100;
        health = maxHealth;
        isDead = false;
	}

	private void Update()
	{
		if (health <= 0) 
		{
            health = 0.1f;
			KillEnemy ();
		}
	}

	private void ApplyDamage(int damage)
	{
		health -= damage;
        Initcbt(damage.ToString());
	}

	private void KillEnemy()
	{
        isDead = true;
        Score.score.nPointsUp(20f);
        anim.SetBool("dead", true);
        Destroy(gameObject,5f);
	}

    private void Initcbt(string damage)
    {
        GameObject temp = (GameObject)Instantiate(cbt);
        RectTransform tempRect = temp.GetComponent<RectTransform>();
        temp.transform.parent = GameObject.Find("EnemyCanvas").transform;
        tempRect.transform.localPosition = cbt.transform.localPosition;
        tempRect.transform.localScale = cbt.transform.localScale;
        tempRect.transform.localRotation = cbt.transform.localRotation;
        temp.GetComponent<Text>().text = damage;

        Destroy(temp.gameObject, 1f);
    }
}