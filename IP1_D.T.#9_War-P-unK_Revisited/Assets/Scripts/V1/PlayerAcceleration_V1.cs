using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAcceleration_V1 : MonoBehaviour
{
    private Rigidbody2D rigidbodyReference;
    private float spaceShipSpeed = 0.01f;
    private Vector2 engineAcceleration;

	void Start ()
    {
        rigidbodyReference = GetComponent<Rigidbody2D>();
        engineAcceleration = new Vector2(1, 0);
	}
	
	void FixedUpdate ()
    {
        if(rigidbodyReference.velocity.x < 10f)
        rigidbodyReference.AddForce(engineAcceleration * spaceShipSpeed, ForceMode2D.Impulse);
	}
}
