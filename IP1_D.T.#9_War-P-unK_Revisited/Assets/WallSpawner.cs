﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{

    public GameObject wallReference;
    GameObject wallTemp;

	void Start ()
    {
        InvokeRepeating("SpawnWall", 0f, 20f);
    }
	
	void SpawnWall ()
    {
        wallTemp = Instantiate(wallReference);
        StartCoroutine("wallDelay");
    }

    IEnumerator wallDelay()
    {
        yield return new WaitForSeconds(0.1f);
        wallTemp.SetActive(true);
    }
}
