using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2D3DSpawner : MonoBehaviour
{

    public GameObject asteroidReference;

	void Start ()
    {
        InvokeRepeating("SpawnAsteroids", 0f, 1.5f);
    }
	
	void SpawnAsteroids ()
    {
        GameObject asteroidTemp = Instantiate(asteroidReference);
        asteroidTemp.SetActive(true);
	}
}
