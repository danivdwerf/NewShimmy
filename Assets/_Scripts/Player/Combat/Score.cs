using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    [HideInInspector] public float nPoints;
    [SerializeField] private Text nightmare;
    [SerializeField] private Image darkBar;
    public static Score score;

    void Awake ()
    {
        score = this;
    }

    void Start ()
    {
        nPoints = 0;
    }

    void Update()
    {
        nightmare.text = "NightmarePoints: " + nPoints.ToString();
        darkBar.fillAmount = nPoints/10000;
    }

    public void nPointsUp(float points)
    {
        nPoints += points;
    }
}