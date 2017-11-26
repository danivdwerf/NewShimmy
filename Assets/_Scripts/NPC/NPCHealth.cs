using UnityEngine;

using System;

public class NPCHealth : MonoBehaviour 
{
    public Action<float> OnTakeDamage;

    [SerializeField]private int maxHealth = 100;
    public int MaxHealth{get{return this.maxHealth;}}

    private int currentHealth;
    public int CurrentHealth{get{return this.currentHealth;}}

    public bool isTakingDamage;
    public bool IsTakingDamage{get{return this.isTakingDamage;}}

    private Animator anim;
    private PhotonView photonView;

    private void Start()
    {
        this.currentHealth = this.maxHealth;
        this.isTakingDamage = false;
        this.photonView = PhotonView.Get(this.gameObject);
        this.anim = this.GetComponent<Animator>();
    }

    public void OnWeaponEnter()
    {
        photonView.RPC("takeDamage", PhotonTargets.All, null);
    }

    [PunRPC]
    private void takeDamage()
    {
        currentHealth -= 20;
        anim.SetBool("damage", true);
        this.isTakingDamage = true;

        if (this.OnTakeDamage != null)
        {
            float healthRatio = (float)currentHealth / (float)maxHealth;
            this.OnTakeDamage(healthRatio);
        }
        this.checkDeath();
    }

    public void onDamageEnd()
    {
        anim.SetBool("damage", false);
        this.isTakingDamage = false;
    }

    private void checkDeath()
    {
        if (currentHealth > 0)
            return;

        anim.SetBool("dead", true);
    }
}
