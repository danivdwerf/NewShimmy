using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class SpawnLocations
{
    public Transform location;
}

[System.Serializable]
public class EnemyObjects
{
    [HideInInspector]public GameObject enemy;
}

public class Spawner : MonoBehaviour 
{

    [SerializeField] private GameObject prefab;
    [SerializeField] private List<SpawnLocations> locations;
    [SerializeField] private List<EnemyObjects> enemies;

    public static Spawner spawn;

	void Start ()
    {
        spawn = this;
        EnemySpawn();
	}

    public void EnemySpawn()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            enemies[i].enemy= (GameObject)Instantiate(prefab, locations[i].location.position, Quaternion.identity);
        }
    }

    public void DeleterEnemies()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            Destroy(enemies[i].enemy);
        }
    }
}
