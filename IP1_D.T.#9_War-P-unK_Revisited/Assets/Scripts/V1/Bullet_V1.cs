using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_V1 : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine("autoBulletDeath");
    }
    void FixedUpdate ()
    {
        transform.localPosition += new Vector3(0.3f, 0, 0);
	}

    IEnumerator autoBulletDeath()
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }

}
