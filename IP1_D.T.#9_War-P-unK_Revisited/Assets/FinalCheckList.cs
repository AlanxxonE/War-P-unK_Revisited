using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalCheckList : MonoBehaviour
{
    public GameObject GM;
    public GameObject BM;
    public GameObject PM;

	// Use this for initialization
	void Start ()
    {
        GM.GetComponent<Text>().text = Game_Manager.greenMinerals.ToString() + " /25";
        BM.GetComponent<Text>().text = Game_Manager.blueMinerals.ToString() + " /10";
        PM.GetComponent<Text>().text = Game_Manager.purpleMinerals.ToString() + " /5";
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
