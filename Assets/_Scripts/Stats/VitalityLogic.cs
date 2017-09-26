using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VitalityLogic : MonoBehaviour
{

    private StatsPoints statsPoints;
    private PlayerLevel playerLevel;
    private int playerHealth;
    private int defense;

    private void Start()
    {
        statsPoints = GetComponent<StatsPoints>();
        playerLevel = GetComponent<PlayerLevel>();
        playerHealth = 95 + statsPoints.Vitallity * 5;
        defense = 15 + statsPoints.Vitallity * 2;
    }

    private void calculatingNewVitality()
    {
        playerHealth = 95 + statsPoints.Vitallity * 5;
        defense = 15 + statsPoints.Vitallity * 2;
    }
}
