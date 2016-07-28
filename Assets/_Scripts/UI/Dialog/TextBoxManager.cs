using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour 
{
    [SerializeField] private GameObject textBox;
    [SerializeField] private Text textField;
    [SerializeField] private TextAsset textFile;
    [HideInInspector] public int currentLine;
    [HideInInspector] public int endLine;
    private string[] textLines;
    private bool isActive;

    public static TextBoxManager tbm;

	void Start () 
    {
        tbm = this;
        currentLine = 0;
        endLine = 0;
        if (textFile != null)
        {
            textLines = (textFile.text.Split('\n'));
        }

        if (endLine == 0)
        {
            endLine = textLines.Length - 1;
        }
        DisableTextBox();
	}

    void Update()
    {
        if (!isActive)
        {
            return;
        }
        textField.text = textLines[currentLine];
        if (Input.GetButtonDown("Submit"))
        {
            currentLine++;
        }

        if (currentLine > endLine)
        {
            DisableTextBox();
        }
    }

    public void EnableTextBox()
    {
        isActive = true;
        textBox.SetActive(true);
        SimpleMovement.move.enabled = false;
    }

    public void DisableTextBox()
    {
        isActive = false;
        textBox.SetActive(false);
        SimpleMovement.move.enabled = true;
    }

    public void ReloadScript(TextAsset newFile)
    {
        if (newFile != null)
        {
            textLines = new string[1];
            textLines = (newFile.text.Split('\n'));
        }
    }
}
