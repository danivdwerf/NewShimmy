using UnityEngine;

using System;

public class NPCHealth : MonoBehaviour 
{
    public Action<float> OnTakeDamage;
    
    [SerializeField]private int maxHealth;
    public int MaxHealth{get{return this.maxHealth;}}

    private int currentHealth;
    public int CurrentHealth{get{return this.currentHealth;}}

    private PhotonView photonView;

    private void Start()
    {
        currentHealth = maxHealth;
        photonView = PhotonView.Get(this.gameObject);
    }

    public void OnWeaponEnter()
    {
        if (this.currentHealth < 20)
            return;
        photonView.RPC("takeDamage", PhotonTargets.All, null);
    }

    [PunRPC]
    private void takeDamage()
    {
        currentHealth -= 20;

        if (this.OnTakeDamage != null)
        {
            float healthRatio = (float)currentHealth / (float)maxHealth;
            this.OnTakeDamage(healthRatio);
        }
    }
}
