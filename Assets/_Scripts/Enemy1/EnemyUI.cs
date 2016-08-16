using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyUI:MonoBehaviour
{
    private EnemyHealth enemyHealth;
    private GameObject player;
    [SerializeField]private Image bar;

    void Start()
    {
        enemyHealth = GetComponent<EnemyHealth>();
        player = GameObject.FindGameObjectWithTag("Player");
        bar.fillAmount = enemyHealth.health / enemyHealth.maxHealth;
    }

    void Update()
    {
        bar.fillAmount = enemyHealth.health / enemyHealth.maxHealth;
    }
}