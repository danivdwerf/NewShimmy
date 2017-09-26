using UnityEngine;

public class OrbitalCamera : MonoBehaviour 
{
    [SerializeField]private float sensitivity = 4.0f;
    [SerializeField]private float orbitDampening = 10.0f;
    [SerializeField]private float maxY = 70.0f;
    [SerializeField]private float minY = -20.0f;
    [SerializeField]private bool cameraDisabled = false;

    private Vector3 localPosition;
    private Vector3 localRotation;
    private float cameraDistance = 10.0f;

    private void Start()
    {
        
    }

    private void LateUpdate()
    {
        if (this.cameraDisabled)
            return;

        if (Input.GetAxis("MouseX") == 0 || Input.GetAxis("MouseY") == 0)
            return;

        var mouseX = Input.GetAxis("MouseX");
        var mouseY = Input.GetAxis("MouseY");

        this.localRotation.x += mouseX * this.sensitivity;
        this.localRotation.y += mouseY * this.sensitivity;

        this.localRotation.y = Mathf.Clamp(this.localRotation.y, this.minY, this.maxY);

        Quaternion rotation = Quaternion.Euler(this.localRotation.y, this.localRotation.x, 0.0f);
        this.transform.parent.transform.rotation = Quaternion.Lerp(this.transform.parent.transform.rotation, rotation, Time.deltaTime * orbitDampening);
    }
}
