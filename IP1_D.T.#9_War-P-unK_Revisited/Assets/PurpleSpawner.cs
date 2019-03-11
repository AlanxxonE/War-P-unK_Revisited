using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleSpawner : MonoBehaviour
{
    public GameObject purpleMineralReference;
    public Game_Manager gMRef;
    int tempScore = 100;
    int iCounter = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Game_Manager.score >= tempScore * iCounter)
        {
            GameObject purpleTemp = Instantiate(purpleMineralReference);
            purpleTemp.SetActive(true);
            //tempScore = gMRef.score;
            iCounter += 1;
        }
	}
}
