using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWipe3D : MonoBehaviour
{
    bool abilityAvailable = true;

	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(abilityAvailable == true)
        {
            gameObject.transform.localScale = new Vector3(0, 0, 0);
            abilityAvailable = false;
        }
        if(gameObject.transform.localScale == new Vector3(2,1,5))
        {
            abilityAvailable = true;
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Asteroid")
        {
            print("Got'em");
            Destroy(other.gameObject);
        }
    }
}
