using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_Beam : MonoBehaviour
{
    public GameObject gMRef;
    public CircuitSpawner circuitRef;
    //public Ship ship3DRef;
    public bool confirmDestroy = true;

    private void Start()
    {
        StartCoroutine("autoBulletDeath");
    }
    public void Update ()
    {
        //transform.localScale += new Vector3(0.03f, 0.03f, 0.03f);


        if(Input.GetKeyUp(KeyCode.Space) || Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.W))
        {
            PlayerMovements_V2.laserBeamSprite = true;
            Destroy(gameObject);
        }

        if(transform.localScale.x > 20 && transform.localPosition.x > 23)
        {
            transform.localPosition += new Vector3(0, 0, 0);
        }
        else
        {
            transform.localPosition += new Vector3(1f, 0, 0);
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Asteroid")
        {
            circuitRef.CircuitPopUp(gameObject.transform);
            if (other.gameObject.GetComponent<Asteroid_V3>() != null)
            {
                other.gameObject.GetComponent<Asteroid_V3>().destoryHit += 0.5f;
            }
            gMRef.GetComponent<CameraShake>().shakeAmount = 0.2f;
            gMRef.GetComponent<CameraShake>().shakeDuration = 0;
            gMRef.GetComponent<CameraShake>().shakeDuration = 0.2f;
        }
    }

    IEnumerator autoBulletDeath()
    {
        yield return new WaitForSeconds(1f);
        if (confirmDestroy == true)
            Destroy(gameObject);
    }

}
