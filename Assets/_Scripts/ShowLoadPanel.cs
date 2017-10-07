using UnityEngine;

public class ShowLoadPanel : MonoBehaviour 
{
    [SerializeField]private GameObject loadPanel;
    private NetworkManager networkManager;

    private void Awake()
    {
        loadPanel.SetActive(false);

        this.networkManager = GameObject.FindGameObjectWithTag(Tags.NetworkManager).GetComponent<NetworkManager>();
        networkManager.OnLoad += this.showPanel;
    }

    private void showPanel(bool value)
    {
        loadPanel.SetActive(value);
    }
}
