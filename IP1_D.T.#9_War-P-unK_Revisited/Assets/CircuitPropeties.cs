using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircuitPropeties : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        StartCoroutine("CircuitAutoDeath");
	}

    IEnumerator CircuitAutoDeath()
    {
        yield return new WaitForSeconds(0.8f);
        Destroy(gameObject);
    }
}
