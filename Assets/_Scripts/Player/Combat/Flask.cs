using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Flask : MonoBehaviour 
{
    [HideInInspector] public float flaskHealing;
    [HideInInspector] public int flaskLeft;
    [HideInInspector] public int maxFlask;

    [SerializeField] private Text flasks;

    public static Flask flask;

    void Start()
    {
        flask = this;
        maxFlask=5;
        flaskLeft = maxFlask;
        flaskHealing = 25+(PlayerStates.playerStates.level*3);
    }

    void Update()
    {
        flasks.text = "Flasks left: " + flaskLeft.ToString();
        if (flaskLeft > 0)
        {
            if (Input.GetButtonDown("Heal"))
            {
                PlayerHealth.health.curHealth += flaskHealing;
                flaskLeft -= 1;
            }
        }
    }
}