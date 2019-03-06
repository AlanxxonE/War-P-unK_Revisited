using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float BulletSpeed = 0.3f;
    public Transform ship;
    public float maxDistance = 40f;

    private void FixedUpdate()
    {
        transform.Translate(0.0f, 0.0f, BulletSpeed);
    }
    void Update()
    {
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
