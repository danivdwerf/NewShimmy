using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour 
{
    [SerializeField] private Button firstButton;
    [SerializeField] private GameObject pausePanel;

    void Start()
    {
        pausePanel.SetActive(false);
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
        if (Input.GetButtonDown("Pause") && !PlayerStates.playerStates.paused && !PlayerStates.playerStates.saving)
        {
            PauseGame();
        }
        else if (Input.GetButtonDown("Pause") && PlayerStates.playerStates.paused) 
        {
            ContinueGame();
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
        PlayerStates.playerStates.paused = true;
        pausePanel.SetActive(true);
        firstButton.Select(); 
    }

    private void ContinueGame()
    {
        Time.timeScale = 1;
        PlayerStates.playerStates.paused = false;
        pausePanel.SetActive(false);
    }
}
