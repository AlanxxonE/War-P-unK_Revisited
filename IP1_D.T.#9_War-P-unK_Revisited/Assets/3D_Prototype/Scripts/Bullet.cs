using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float BulletSpeed = 0.5f;
    public Transform ship;
    public GameObject gMRef;
    //public float maxDistance = 5f;

    private void Start()
    {
        StartCoroutine("Bullet3DDeath");
    }

    void Update()
    {
        transform.position += new Vector3(0.0f, 0.0f, BulletSpeed);
        transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);

        //if (Vector3.Distance(transform.position, ship.position) > maxDistance)
        //{
        //    Destroy(gameObject);
        //}
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

    IEnumerator Bullet3DDeath()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    switch(collision.gameObject.name)
    //    {
    //        case "Ship":
    //            break;
    //        default:
    //            Destroy(collision.gameObject);
    //            Destroy(gameObject);
    //            print("HIt");
    //            break;
    //    }
    //}
}
