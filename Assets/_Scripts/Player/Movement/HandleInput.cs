using UnityEngine;
using System.Collections;

public class HandleInput : MonoBehaviour 
{
    [HideInInspector] public string controller = "";

	void Update ()
    {
        if (Input.GetJoystickNames().Length != 0)
        {
            string check = Input.GetJoystickNames()[0].ToLower();
            if (check.Contains("xbox"))
            {
                controller="xbox";
            }
        }
        else
        {
            controller = "keyboard";
        }
    }
}