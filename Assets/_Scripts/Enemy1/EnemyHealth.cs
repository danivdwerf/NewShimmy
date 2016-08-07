using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour 
{
    [HideInInspector] public float health; 
    [HideInInspector] public float maxHealth;
    [HideInInspector] public bool isDead;
    [SerializeField] private GameObject cbt;
    private GameObject temp;
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

    public void ApplyDamage(float damage)
	{
        if (!isDead)
        {
            health -= damage;
            Addcbt(damage);
        }
	}

	private void KillEnemy()
	{
        isDead = true;
        Score.score.nPointsUp(20f);
        anim.SetBool("dead", true);
        Destroy(gameObject,5f);
	}

    public void Addcbt(float damage)
    {
        if (temp == null)
        {
            temp = (GameObject)Instantiate(cbt);
            RectTransform tempRect = temp.GetComponent<RectTransform>();
            temp.transform.SetParent(transform.GetComponentInChildren<Canvas>().transform);
            tempRect.transform.localPosition = cbt.transform.localPosition;
            tempRect.transform.localScale = cbt.transform.localScale;
            tempRect.transform.localRotation = cbt.transform.localRotation; 
            temp.GetComponent<Text>().text = damage.ToString(); 
            Destroy(temp.gameObject, 2.5f);
        }
        else
        {
            float oldDam = float.Parse(temp.GetComponent<Text>().text);
            float newDam = oldDam += damage;
            temp.GetComponent<Text>().text = newDam.ToString();
        }
    }
}
