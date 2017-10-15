using UnityEngine;
using UnityEngine.EventSystems;

public class SetEventSystemInput : MonoBehaviour
{
    private StandaloneInputModule inputModule;

    private void Start()
    {
        this.inputModule = this.GetComponent<StandaloneInputModule>();

        inputModule.horizontalAxis = Controller.LeftStickX;
        inputModule.verticalAxis = Controller.LeftStickY;
        inputModule.submitButton = Controller.Cross;
        inputModule.cancelButton = Controller.Circle;
    }
}
