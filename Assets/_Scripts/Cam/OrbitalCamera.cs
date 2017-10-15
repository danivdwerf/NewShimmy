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
    public bool Disabled{get{return cameraDisabled;} set{cameraDisabled = value;}}

    private Vector3 localRotation;
    private Transform target;

    private void Start()
    {
        this.localRotation = this.transform.rotation.eulerAngles;
        this.transform.position = new Vector3(0, 0, offset);
        this.target = this.transform.parent;
    }

    private void Update()
    {
        if (this.cameraDisabled)
            return;
        
        var xRot = Input.GetAxis(Controller.RightStickX);
        var yRot = -Input.GetAxis(Controller.RightStickY);

        this.localRotation.x += xRot * this.sensitivity * Time.deltaTime;
        this.localRotation.y += yRot * this.sensitivity * Time.deltaTime;

        this.localRotation.y = Mathf.Clamp(this.localRotation.y, this.minY, this.maxY);
    }

    private void LateUpdate()
    {
        if (this.cameraDisabled)
            return;

        Quaternion rotation = Quaternion.Euler(this.localRotation.y, this.localRotation.x, 0.0f);
        target.rotation = Quaternion.Lerp(target.rotation, rotation, Time.deltaTime * orbitDampening);
    }

    public void targetMode(Vector3 rotation)
    {
        rotation.x += 30;
        target.rotation = Quaternion.Euler(rotation);
    }
}
