using UnityEngine;
using System.Collections;

public class Melee1 : MonoBehaviour
{
    private float damage;
    private float distance;
    private float maxDistance = 1.5f;
    private RaycastHit hit;
    private EnemyHealth enemyhp;
    [HideInInspector] public float takeStamina;

    public static Melee1 melee1; 

    private void Start()
    {
        melee1 = this;
        takeStamina = 20.0f;
    }

    void Update ()
    {
        if (Input.GetButtonDown("Hit1") && Stamina.stam.curStamina >= 20)
        { 
            Stamina.stam.curStamina -= takeStamina;
            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                distance = hit.distance;
                Debug.DrawLine(transform.position, hit.transform.position, Color.red);
                if (distance < maxDistance)
                {
                    damage = Mathf.Round(Random.Range(45.0f, 60.0f) + (PlayerStates.playerStates.level * 5));
                    hit.transform.GetComponent<EnemyHealth>().ApplyDamage(damage);
                }
            }
        }   
    }
}