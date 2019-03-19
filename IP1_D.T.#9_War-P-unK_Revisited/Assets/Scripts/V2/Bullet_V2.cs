using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_V2 : MonoBehaviour
{
    public GameObject gMRef;

    private void Start()
    {
        StartCoroutine("autoBulletDeath");
    }
    void FixedUpdate ()
    {
        transform.localPosition += new Vector3(0.5f, 0, 0);
        transform.localScale += new Vector3(0.03f, 0.03f, 0.03f);
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Asteroid")
        {
            gMRef.GetComponent<CameraShake>().shakeAmount = 0.2f;
            gMRef.GetComponent<CameraShake>().shakeDuration = 0;
            gMRef.GetComponent<CameraShake>().shakeDuration = 0.2f;
            Destroy(gameObject);
        }
    }

    IEnumerator autoBulletDeath()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

}
