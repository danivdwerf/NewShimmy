using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyUI:MonoBehaviour
{
    private EnemyHealth enemyHealth;
    private GameObject target;
    [SerializeField]private Image bar;

    void Start()
    {
        enemyHealth = GetComponent<EnemyHealth>();
        bar.fillAmount = enemyHealth.health / enemyHealth.maxHealth;
        target = GameObject.FindWithTag("Target");
    }

    void Update()
    {
        bar.fillAmount = enemyHealth.health / enemyHealth.maxHealth;
    }
}