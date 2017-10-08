using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour 
{
    [SerializeField]private Image healthBar;
    private NPCHealth health;

    private void Start()
    {
        this.health = this.GetComponent<NPCHealth>();
        health.OnTakeDamage += this.setHealthbar;
        this.setImageOptions();
    }

    private void setImageOptions()
    {
        healthBar.type = Image.Type.Filled;
        healthBar.fillMethod = Image.FillMethod.Horizontal;
        healthBar.fillOrigin = (int)Image.OriginHorizontal.Left;
    }

    private void setHealthbar(float value)
    {
        healthBar.fillAmount = value;
    }
}
