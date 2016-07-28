using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour 
{
    [SerializeField] private Button equipment;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject equipmentPanel;

    void Start()
    {
        pausePanel.SetActive(false);
        equipmentPanel.SetActive(false);
    }

    public void Equipment()
    {
        if (PlayerStates.playerStates.paused)
        {
            equipmentPanel.SetActive(true);
            pausePanel.SetActive(false);
            PlayerStates.playerStates.equip = true;
        }
    }

    public void QuitGame()
    {
        if (PlayerStates.playerStates.paused)
        { 
            Application.Quit();
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Pause") && !PlayerStates.playerStates.paused && !PlayerStates.playerStates.equip && !PlayerStates.playerStates.saving && !PlayerStates.playerStates.upgrading)
        {
            PauseGame();
        }
        else if (Input.GetButtonDown("Cancel") && PlayerStates.playerStates.paused && PlayerStates.playerStates.equip)
        {
            CloseEquipment();
        }
        else if (Input.GetButtonDown("Pause") && PlayerStates.playerStates.paused && !PlayerStates.playerStates.equip) 
        {
            ContinueGame();
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
        PlayerStates.playerStates.paused = true;
        pausePanel.SetActive(true);
        equipment.Select();
    }

    private void ContinueGame()
    {
        Time.timeScale = 1;
        PlayerStates.playerStates.paused = false;
        pausePanel.SetActive(false);
    }

    private void CloseEquipment()
    {
        equipmentPanel.SetActive(false);
        pausePanel.SetActive(true);
        PlayerStates.playerStates.equip = false;
    }


}
