using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour 
{
    [SerializeField]private Image healthBar = null;
    [SerializeField]private GameObject healthObject = null;
    private NPCHealth health;

    private void Start()
    {
        this.health = this.GetComponent<NPCHealth>();
        health.OnTakeDamage += this.setHealthbar;
        this.setImageOptions();
        showUI(false);
    }

    private void setImageOptions()
    {
        healthBar.type = Image.Type.Filled;
        healthBar.fillMethod = Image.FillMethod.Horizontal;
        healthBar.fillOrigin = (int)Image.OriginHorizontal.Left;
    }

    public void showUI(bool value)
    {  
        healthObject.SetActive(value);
    }

    private void setHealthbar(float value)
    {
        healthBar.fillAmount = value;
    }
}
