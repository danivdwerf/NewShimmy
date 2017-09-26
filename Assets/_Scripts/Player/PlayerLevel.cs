using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevel : MonoBehaviour
{
    private int level;
    private int currentLevel;
    public int Level { get { return level; } }

    private void Start()
    {
        level = 1;
        currentLevel = 1;
    }

    public void levelUp()
    {
        currentLevel += 1;
    }
}
