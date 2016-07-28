using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour 
{
    [HideInInspector] public float curHealth;
    [HideInInspector] public float maxHealth;
    [SerializeField] private Image healthBar;

    public static PlayerHealth health;

    void Awake()
    {
        health = this;
        maxHealth = 100+(PlayerStates.playerStates.level*5);
        curHealth = maxHealth;

        healthBar.fillAmount = (curHealth / maxHealth);
    }

    void Update ()
    {
        healthBar.fillAmount = (curHealth / maxHealth);
        if (curHealth > maxHealth) curHealth = maxHealth;
    }

    public void Hurt(int amount)
    {
        curHealth -= amount;
    }
}