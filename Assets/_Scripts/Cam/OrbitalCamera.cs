using UnityEngine;
using UnityEngine.Networking;

[AddComponentMenu("Camera/OrbitalCamera")]
public class OrbitalCamera : MonoBehaviour 
{
    [SerializeField]private float sensitivity = 4.0f;
    [SerializeField]private float orbitDampening = 10.0f;
    [SerializeField]private float maxY = 70.0f;
    [SerializeField]private float minY = -20.0f;
    [SerializeField]private float offset = 5.0f;

    [SerializeField]private bool cameraDisabled = false;

    private Vector3 localRotation;

    private void Start()
    {
        this.localRotation = this.transform.rotation.eulerAngles;
        this.transform.position = new Vector3(0, 0, offset);
    }

    private void Update()
    {
        if (this.cameraDisabled)
            return;
        
        var xRot = Input.GetAxis(Controller.RightStickX);
        var yRot = Input.GetAxis(Controller.RightStickY);

        this.localRotation.x += xRot * this.sensitivity;
        this.localRotation.y += yRot * this.sensitivity;

        this.localRotation.y = Mathf.Clamp(this.localRotation.y, this.minY, this.maxY);
    }

    private void LateUpdate()
    {
        if (this.cameraDisabled)
            return;

        Quaternion rotation = Quaternion.Euler(this.localRotation.y, this.localRotation.x, 0.0f);
        this.transform.parent.transform.rotation = Quaternion.Lerp(this.transform.parent.transform.rotation, rotation, Time.deltaTime * orbitDampening);
    }
}
