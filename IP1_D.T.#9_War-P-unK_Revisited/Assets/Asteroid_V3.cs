using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid_V3 : MonoBehaviour
{
    float rotZ;
    public bool mineralsCreation = false;
    public PairedUpAsteroid asteroidReference;
    public Game_Manager gMRef;
    public Pause_State pauseRef;

    public float destoryHit;

    public GameObject explosionRef2D;
    public GameObject explosionRef3D;

    //public GameObject otherReference;

    void Start ()
    {
        StartCoroutine("autoAsteroidDeath");
    }
	void Update ()
    {
        if (pauseRef.checkPause == false)
        {
            rotZ -= 1f;
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ);
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        { 
            Game_Manager.score += 10;
            if (destoryHit > 0)
                destoryHit -= 1;
            if (destoryHit == 0)
            {
                mineralsCreation = true;
                asteroidReference.asteroidTarget1Reference.GetComponent<SpriteRenderer>().enabled = false;
                asteroidReference.asteroidTarget1Reference.GetComponent<BoxCollider>().enabled = false;
                asteroidReference.asteroidTarget2Reference.GetComponent<SpriteRenderer>().enabled = false;
                asteroidReference.asteroidTarget2Reference.GetComponent<BoxCollider>().enabled = false;

                if(explosionRef2D != null)
                explosionRef2D.SetActive(true);
                if(explosionRef3D != null)
                explosionRef3D.SetActive(true);
            }
            //otherReference = other.gameObject;
            //StartCoroutine("asteroidDestruction");
        }
    }

    IEnumerator autoAsteroidDeath()
    {
        yield return new WaitForSeconds(20f);
        Destroy(transform.parent.gameObject);
    }

    //IEnumerator asteroidDestruction()
    //{
    //    yield return new WaitForSeconds(0.1f);
    //    Destroy(otherReference.gameObject);
    //    Destroy(transform.parent.gameObject);
    //}
}
