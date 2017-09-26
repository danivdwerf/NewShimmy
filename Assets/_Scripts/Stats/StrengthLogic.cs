using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrengthLogic : MonoBehaviour
{
    private StatsPoints statsPoints;
    private PlayerLevel playerLevel;
    private int baseDamage;
    private int damage;

    private void Start()
    {
        statsPoints = GetComponent<StatsPoints>();
        playerLevel = GetComponent<PlayerLevel>();
        baseDamage = 2 + playerLevel.Level;
        damage = baseDamage * 2 + statsPoints.Strength * 3;
    }

    private void calculatingNewDamage()
    {
        baseDamage = 2 + playerLevel.Level;
        damage = baseDamage * 2 + statsPoints.Strength * 3;
    }
}
