using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerExp : MonoBehaviour
{

    private PlayerLevel playerLevel;
    private float neededExp;
    private float currentExp;
    private float increaseExp;

    private void Start()
    {
        playerLevel = GetComponent<PlayerLevel>();
        neededExp = 1000f;
        currentExp = 0f;
    }

    private void Update()
    {
        if (currentExp >= neededExp)
        {
            playerLevel.levelUp();
            currentExp -= neededExp;
            increaseExp = 260f * playerLevel.Level * 1.3f;
            neededExp = Mathf.Round(neededExp += increaseExp);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            currentExp += 100;
        }
    }
}
