using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float BulletSpeed = 0.3f;
    public Transform ship;
    public float maxDistance = 40f;
    
    void Update()
    {
        transform.position += new Vector3(0.0f, 0.0f, BulletSpeed);

        if (Vector3.Distance(transform.position, ship.position) > maxDistance)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
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
