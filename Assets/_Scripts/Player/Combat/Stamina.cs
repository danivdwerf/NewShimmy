using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Stamina : MonoBehaviour 
{
    [HideInInspector] public float curStamina;
    [HideInInspector] public float maxStamina;
    [SerializeField] private Image staminaBar;
	private float regain;

    public static Stamina stam;

	void Awake () 
	{
        stam = this;
        maxStamina = 70+(PlayerStates.playerStates.level*5);
		curStamina = maxStamina;
		regain = 20;
        staminaBar.fillAmount = (curStamina/maxStamina);
	}

	void Update () 
	{
        staminaBar.fillAmount = (curStamina/maxStamina); 
		if (curStamina != maxStamina) 
		{
            curStamina += regain * Time.deltaTime;
            if (curStamina > maxStamina)curStamina = maxStamina;
            if (curStamina < 0)curStamina = 0;
		}
	}
}
