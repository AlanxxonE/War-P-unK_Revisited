using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{

    public GameObject wallReference;
    GameObject wallTemp;

	void Start ()
    {
        InvokeRepeating("SpawnWall", 0f, 10f);
        if (gameObject != null)
            StartCoroutine("wallDelay");
    }
	
	void SpawnWall ()
    {
        wallTemp = Instantiate(wallReference);
	}

    IEnumerator wallDelay()
    {
        yield return new WaitForSeconds(0.1f);
        wallTemp.SetActive(true);
    }
}
