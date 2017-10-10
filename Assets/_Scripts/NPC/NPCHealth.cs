using UnityEngine;

using System;

public class NPCHealth : MonoBehaviour 
{
    public Action<float> OnTakeDamage;

    [SerializeField]private int maxHealth = 100;
    public int MaxHealth{get{return this.maxHealth;}}

    private int currentHealth;
    public int CurrentHealth{get{return this.currentHealth;}}

    private Animator anim;
    private PhotonView photonView;
    private EnemyMovement movement;

    private void Start()
    {
        this.currentHealth = this.maxHealth;
        this.photonView = PhotonView.Get(this.gameObject);
        this.anim = this.GetComponent<Animator>();
        this.movement = this.GetComponent<EnemyMovement>();
    }

    public void OnWeaponEnter()
    {
        photonView.RPC("takeDamage", PhotonTargets.All, null);
    }

    [PunRPC]
    private void takeDamage()
    {
        currentHealth -= 20;
        anim.SetTrigger("damage");

        if (this.OnTakeDamage != null)
        {
            float healthRatio = (float)currentHealth / (float)maxHealth;
            this.OnTakeDamage(healthRatio);
        }
        this.checkDeath();
    }

    private void checkDeath()
    {
        if (currentHealth > 0)
            return;

        anim.SetTrigger("dead");
        movement.stopMoving(true);
    }
}
