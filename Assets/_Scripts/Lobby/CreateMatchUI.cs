using UnityEngine;
using UnityEngine.UI;

public class CreateMatchUI : MonoBehaviour 
{
    [SerializeField]private InputField roomName = null;
    [SerializeField]private Button submitButton = null;

    private NetworkManager manager;

    private void Start()
    {
        this.manager = GameObject.FindGameObjectWithTag(Tags.NetworkManager).GetComponent<NetworkManager>();
        submitButton.onClick.AddListener(delegate(){manager.createRoom(roomName.text);});
    }
}
