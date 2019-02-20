using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float EnemySpeed = 0.5f;

    private void FixedUpdate()
    {
        transform.Translate(0.0f, 0f, -EnemySpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch(collision.gameObject.name)
        {
            case "Back Wall":
                Destroy(gameObject);
                break;

            default:
                break;
        }
    }
}
