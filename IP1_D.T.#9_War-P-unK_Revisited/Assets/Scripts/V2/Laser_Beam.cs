using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_Beam : MonoBehaviour
{
    public GameObject gMRef;
    public CircuitSpawner circuitRef;

    private void Start()
    {
        StartCoroutine("autoBulletDeath");
    }
    void FixedUpdate ()
    {
        transform.localPosition += new Vector3(1f, 0, 0);
        //transform.localScale += new Vector3(0.03f, 0.03f, 0.03f);
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Asteroid")
        {
            circuitRef.CircuitPopUp(gameObject.transform);
            gMRef.GetComponent<CameraShake>().shakeAmount = 0.2f;
            gMRef.GetComponent<CameraShake>().shakeDuration = 0;
            gMRef.GetComponent<CameraShake>().shakeDuration = 0.2f;
        }
    }

    IEnumerator autoBulletDeath()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

}
