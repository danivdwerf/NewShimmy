using UnityEngine;

public class Billboarding : MonoBehaviour 
{
    private void Update()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, Camera.main.transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
    }
}
