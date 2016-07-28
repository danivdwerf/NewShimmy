using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LockOnTarget : MonoBehaviour
{
    public List<Transform> targets;
    public Transform selectedTargets;
    public bool theTarget;
    private Transform myTransform;

    void Start()
    {
        theTarget = false;
        targets = new List<Transform>();
        selectedTargets = null;
        myTransform = transform;

        AddAllEnemies();
    }

    public void AddAllEnemies()
    {
        GameObject[] go = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in go)
            AddTarget(enemy.transform);
    }

    public void AddTarget(Transform enemy)
    {
        targets.Add(enemy);
    }

    private void SortTargetsByDistance()
    {
        targets.Sort(delegate (Transform t1, Transform t2)
            {
                return Vector3.Distance(t1.position, myTransform.position).CompareTo(Vector3.Distance(t2.position, myTransform.position));
            });
    }

    private int selectNr = 0;

    private void TargetEnemy()
    {
        if (selectedTargets == null)
        {
            SortTargetsByDistance();
            theTarget = true;
            selectedTargets = targets[0];
            selectNr = 0;

        }
        else if (selectNr < targets.Count)
        {
            selectNr++;
            int index = selectNr;

            DeselectTarget();
            selectedTargets = targets[index];
        }
        else
        {
            selectedTargets = null;
        }
    }

    private void DeselectTarget ()
    {
        selectedTargets = null;
    }


    void Update()
    {
        if(Input.GetButtonDown("Target"))
        {
            TargetEnemy();
        }
        if (theTarget == true)
        {
            transform.LookAt(selectedTargets);
        }
    }
}