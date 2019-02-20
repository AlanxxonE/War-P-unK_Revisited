using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid_V1 : MonoBehaviour
{
    float rotZ;

	void Start () {
		
	}
	void Update ()
    {
        rotZ -= 1f;
        transform.position += new Vector3(0.03f, 0);
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ);
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
