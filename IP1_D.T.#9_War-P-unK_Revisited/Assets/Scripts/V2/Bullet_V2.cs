using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_V2 : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine("autoBulletDeath");
    }
    void FixedUpdate ()
    {
        transform.localPosition += new Vector3(0.5f, 0, 0);
	}

    IEnumerator autoBulletDeath()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }

}
