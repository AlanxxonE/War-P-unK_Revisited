using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        StartCoroutine("spriteDeath");
	}
    IEnumerator spriteDeath()
    {
        yield return new WaitForSeconds(0.30f);
        Destroy(gameObject);
    }
}
