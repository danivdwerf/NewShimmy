using UnityEngine;
using UnityEngine.UI;

using System.Collections.Generic;

public class ShowRooms : MonoBehaviour 
{
    private LoadRooms loadRooms;

    [SerializeField]private GameObject parent;
    [SerializeField]private Font buttonFont;

    private Button[] buttons;
    private Text[] buttonLabels;

    private NetworkManager networkManager;

    private void Start()
    {
        buttons = new Button[NetworkValues.MAXROOMS];
        buttonLabels = new Text[NetworkValues.MAXROOMS];

        this.networkManager = FindObjectOfType<NetworkManager>();
        this.loadRooms = this.GetComponent<LoadRooms>();
        loadRooms.OnLoadedRooms += this.showRooms;

        this.createButtons();
    }

    private void createButtons()
    {
        for (var i = 0; i < buttons.Length; i++)
        {
            var currentButton = new GameObject("Room button " + i);
            currentButton.transform.parent = parent.transform;
            currentButton.transform.localPosition = new Vector3(currentButton.transform.position.x, currentButton.transform.position.y, 0);
            currentButton.transform.localScale = new Vector3(1, 1, 1);

            var imageComponent = currentButton.AddComponent<Image>();
            imageComponent.rectTransform.sizeDelta = new Vector2(NetworkValues.BUTTON_WIDTH, NetworkValues.BUTTON_HEIGHT);

            var buttonComponent = currentButton.AddComponent<Button>();
            buttons[i] = buttonComponent;

            var labelObject = new GameObject("Label");
            labelObject.transform.parent = currentButton.transform;
            labelObject.transform.localPosition = Vector3.zero;
            labelObject.transform.localScale = new Vector3(1, 1, 1);

            var labelComponent = labelObject.AddComponent<Text>();
            labelComponent.font = buttonFont;
            labelComponent.color = Color.black;
            labelComponent.text = "Room " + i;
            labelComponent.rectTransform.sizeDelta = new Vector2(NetworkValues.BUTTON_WIDTH, NetworkValues.BUTTON_HEIGHT);
            labelComponent.resizeTextForBestFit = true;
            labelComponent.alignment = TextAnchor.MiddleCenter;
            buttonLabels[i] = labelComponent;

            currentButton.SetActive(false);
        }
    }

    private void showRooms(List<OnlineRoom> rooms)
    {
        for (var i = 0; i < buttons.Length; i++)
            buttons[i].gameObject.SetActive(false);

        for(var i = 0; i < rooms.Count; i++)
        {
            var index = i;

            if (rooms[i].Size >= NetworkValues.MAX_PLAYERS)
                continue;
            
            if (buttons[index].gameObject.activeInHierarchy)
                continue;

            var button = buttons[index];
            var label = buttonLabels[index];

            label.text = rooms[index].Name + " (" +rooms[index].Size + "/" + NetworkValues.MAX_PLAYERS + ")";
            button.onClick.AddListener(delegate(){networkManager.joinRoom(rooms[index].Name);});
            button.gameObject.SetActive(true);
        }
    }
}
