using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsPoints : MonoBehaviour
{
    private int strength;
    public int Strength { get { return strength; } }
    private int vitallity;
    public int Vitallity { get { return vitallity; } }
    private int endurance;
    public int Endurance { get { return endurance; } }
    private int dexterity;
    public int Dexterity { get { return dexterity; } }
    private int critical;
    public int Critical { get { return critical; } }
    
    private void Start()
    {
        strength = 1;
        vitallity = 1;
        endurance = 1;
        dexterity = 1;
        critical = 1;
    }

    public void lvlUpStr()
    {
        strength += 1;
    }
    public void lvlUpVit()
    {
        vitallity += 1;
    }
    public void lvlUpEnd()
    {
        endurance += 1;
    }
    public void lvlUpDex()
    {
        dexterity += 1;
    }
    public void lvlUpCrt()
    {
        critical += 1;
    }
}
