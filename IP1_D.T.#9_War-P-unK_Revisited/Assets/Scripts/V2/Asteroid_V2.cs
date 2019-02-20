using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid_V2 : MonoBehaviour
{
    float rotZ;
    public float speed;

	void Start ()
    {
        StartCoroutine("autoAsteroidDeath");
        speed = Random.Range(0.1f, 0.3f);
    }
	void Update ()
    {
        rotZ -= 1f;
        transform.position -= new Vector3(speed, 0);
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ);
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    IEnumerator autoAsteroidDeath()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
