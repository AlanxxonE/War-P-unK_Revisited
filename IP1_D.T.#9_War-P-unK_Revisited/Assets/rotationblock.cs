using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationblock : MonoBehaviour {

    float rotZ;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        rotZ += 1.0f;

        transform.localRotation = Quaternion.Euler(0, 0, rotZ);
	}
}
