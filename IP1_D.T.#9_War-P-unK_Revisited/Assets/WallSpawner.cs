using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{

    public GameObject wallReference;

	void Start ()
    {
        InvokeRepeating("SpawnWall", 0f, 10f);
    }
	
	void SpawnWall ()
    {
        GameObject wallTemp = Instantiate(wallReference);
        wallTemp.SetActive(true);
	}
}
