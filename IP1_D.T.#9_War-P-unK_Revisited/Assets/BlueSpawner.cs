using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueSpawner : MonoBehaviour
{
    public GameObject blueMineralRef;
    public Game_Manager gMRef;
    int tempScore = 100;
    int iCounter = 1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(gMRef.score >= (tempScore / 2) * iCounter)
        {
            GameObject purpleTemp = Instantiate(blueMineralRef);
            purpleTemp.SetActive(true);
            tempScore = gMRef.score;
            iCounter += 1;
        }
	}
}
