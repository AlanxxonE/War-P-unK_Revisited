using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid_Spawner_V2 : MonoBehaviour
{
    public GameObject asteroidReference;
    float randomSize;
    float randomY;
    bool rateOfAsteroids = true;

	// Update is called once per frame
	void Update ()
    {
        if(rateOfAsteroids == true)
            StartCoroutine("CreateAsteroid");
	}

    IEnumerator CreateAsteroid()
    {
        rateOfAsteroids = false;

        yield return new WaitForSeconds(0.8f);

        randomSize = Random.Range(1f, 5f);
        randomY = Random.Range(-2f, 5f);

        GameObject asteroidTemp = Instantiate(asteroidReference);
        asteroidTemp.SetActive(true);
        asteroidTemp.transform.position = gameObject.transform.position;
        asteroidTemp.transform.localScale = new Vector3(randomSize, randomSize);
        asteroidTemp.transform.position += new Vector3(0,randomY);

        rateOfAsteroids = true;
    }
}
