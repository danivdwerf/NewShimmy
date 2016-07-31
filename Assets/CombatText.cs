using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CombatText : MonoBehaviour 
{
    [HideInInspector] public static CombatText combatText;
    [SerializeField] private GameObject cbt;
	void Start ()
    {
        combatText = this;
    }

    public void Initcbt(string damage)
    {
        GameObject temp = (GameObject)Instantiate(cbt);
        RectTransform tempRect = temp.GetComponent<RectTransform>();
        temp.transform.SetParent(transform);
        tempRect.transform.localPosition = cbt.transform.localPosition;
        tempRect.transform.localScale = cbt.transform.localScale;
        tempRect.transform.localRotation = cbt.transform.localRotation;
        temp.GetComponent<Text>().text = damage;
        Destroy(temp.gameObject, 1f);
    }
}
