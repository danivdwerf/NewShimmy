using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SavePoint : MonoBehaviour 
{
    [SerializeField] private GameObject savePanel;
    [HideInInspector] public bool inSaveArea;
    private EventSystem system;  

    void Start()
    {
        savePanel.SetActive(false);
        system = GameObject.FindObjectOfType<EventSystem>();
        inSaveArea = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inSaveArea = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inSaveArea = false;
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel") && PlayerStates.playerStates.saving)
        {
            ReturnToGame();
        }

        if (Input.GetButtonDown("Submit") && inSaveArea)
        {
            SavingPoint();
        }
    }
    
    void SavingPoint()
    {
        Spawner.spawn.DeleterEnemies();
        savePanel.SetActive(true);
        PlayerStates.playerStates.saving = true;
        Time.timeScale = 0;
        SaveLoad.save.Save();

        Flask.flask.flaskLeft = Flask.flask.maxFlask;
        Stamina.stam.curStamina = Stamina.stam.maxStamina;
        PlayerHealth.health.curHealth = PlayerHealth.health.maxHealth;
    }

    void ReturnToGame()
    {
        Time.timeScale = 1;
        savePanel.SetActive(false);
        system.SetSelectedGameObject(null);
        PlayerStates.playerStates.saving = false;
        Spawner.spawn.EnemySpawn();
    }
}
