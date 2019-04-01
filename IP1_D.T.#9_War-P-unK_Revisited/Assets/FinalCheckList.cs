using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalCheckList : MonoBehaviour
{
    public GameObject GM;
    public GameObject BM;
    public GameObject PM;

    public GameObject congrats;
    public GameObject secretEnding;
    //public GameObject outOfFuel;
	// Use this for initialization
	void Start ()
    {
        GM.GetComponent<Text>().text = Game_Manager.greenMinerals.ToString() + " /10";
        BM.GetComponent<Text>().text = Game_Manager.blueMinerals.ToString() + " /3";
        PM.GetComponent<Text>().text = Game_Manager.purpleMinerals.ToString() + " /1";

        if(Game_Manager.greenMinerals == 10 && Game_Manager.blueMinerals == 3 && Game_Manager.purpleMinerals == 1)
        {
            secretEnding.SetActive(true);
            congrats.SetActive(true);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
