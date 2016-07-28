using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LockOnTarget : MonoBehaviour
{
    private List<Transform> targets;
    private Transform selectedTarget;
    private bool theTarget;
    private Transform myTransform;
    private RaycastHit hit;

    void Start()
    {
        targets = new List<Transform>();
        selectedTarget = null;
        myTransform = transform;
        theTarget = false;
        AddAllEnemies();
    }

    public void AddAllEnemies()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in objects)
        {
            targets.Add(enemy.transform);
        }
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
        if (selectedTarget == null)
        {
            SortTargetsByDistance();
            if (Physics.Raycast(transform.position, targets[0].position, out hit))
            {
                if(hit.collider.CompareTag("Enemy") && hit.distance <= 10)
                {
                    theTarget = true;
                    selectedTarget = targets[0];
                    selectNr = 0;
                }
            }

        }
        else if (selectNr < targets.Count)
        {
            selectNr++;
            int index = selectNr;

            DeselectTarget();
            selectedTarget = targets[index];
        }
        else
        {
            selectedTarget = null;
        }
    }

    private void DeselectTarget ()
    {
        selectedTarget = null;
    }


    void Update()
    {
        if(Input.GetButtonDown("Target"))
        {
            TargetEnemy();
        }
        if (theTarget)
        {
            transform.LookAt(selectedTarget);
        }
    }
}