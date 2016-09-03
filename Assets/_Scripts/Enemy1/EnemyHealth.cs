using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour 
{
    [HideInInspector] public float health; 
    [HideInInspector] public float maxHealth;
    [HideInInspector] public bool isDead;
    [SerializeField] private GameObject cbt;
    private Transform target;

    private AudioSource source;
    [SerializeField] private AudioClip hurt;
    [SerializeField] private AudioClip death;
    [SerializeField] private AudioClip backstab;
    private GameObject temp;
    private Animator anim;
    private AnimationEvent animEvent;

    public static EnemyHealth enemyHP;

	private void Awake()
	{
        enemyHP = this;
        anim = GetComponentInChildren<Animator>();
        animEvent = GetComponentInChildren<AnimationEvent>();
        source = GetComponent<AudioSource>();
        target = GameObject.FindGameObjectWithTag("Player").transform;    

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

        if (animEvent.hurt == 1)
        {
            anim.SetBool("hurt",false);
        }
	}

    public void ApplyDamage(float damage)
	{
        Vector3 toTarget = (target.position - transform.position).normalized;
        if (!isDead)
        {
            if (Vector3.Dot(toTarget, transform.forward) > 0) 
            {
                if(damage < health)
                {
                    source.PlayOneShot(death);
                }
                health -= damage;
            } 
            else 
            {
                if(damage < health)
                {
                    source.PlayOneShot(backstab);
                }
                health -= (damage * 1.2f);
            }
            Addcbt(damage);
            if (health > 0)
            {
                anim.SetBool("hurt", true);
            }
        }
	}

	private void KillEnemy()
	{
        isDead = true;
        source.PlayOneShot(hurt);
        Score.score.nPointsUp(20f*PlayerStates.playerStates.level);
        anim.SetBool("dead", true);
        Destroy(gameObject, 5f);
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
