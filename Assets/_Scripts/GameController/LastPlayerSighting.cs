using UnityEngine;
using System.Collections;

public class LastPlayerSighting : MonoBehaviour
{
    [HideInInspector]public Vector3 position = new Vector3(-1000f, -1000f, -1000f);
    [HideInInspector]public Vector3 resetPosition = new Vector3(-1000f, -1000f, -1000f);

    public static LastPlayerSighting lps;

    void Awake()
    {
        lps = this;
    }
}