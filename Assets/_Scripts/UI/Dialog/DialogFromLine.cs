using UnityEngine;
using System.Collections;

public class DialogFromLine : MonoBehaviour 
{
    [SerializeField] private TextAsset textFile;
    public int startLine;
    public int endLine;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TextBoxManager.tbm.ReloadScript(textFile);
            TextBoxManager.tbm.currentLine = startLine;
            TextBoxManager.tbm.endLine = endLine;
            TextBoxManager.tbm.EnableTextBox();
        }
    }
}
