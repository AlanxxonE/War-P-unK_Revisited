using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements_V1 : MonoBehaviour
{
    private Vector3 movement = new Vector3(0, 0.1f);
    public BulletSpawner_V1 bulletSpawnerReference;
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            bulletSpawnerReference.SpawnBullet();
        }
    }
    void FixedUpdate ()
    {
		if(Input.GetKey(KeyCode.UpArrow))
        {
            transform.localPosition += movement;
        }
        else if(Input.GetKey(KeyCode.DownArrow))
        {
            transform.localPosition -= movement;
        }
    }
}
