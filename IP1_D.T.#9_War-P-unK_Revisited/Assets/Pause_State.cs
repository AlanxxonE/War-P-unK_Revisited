using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_State : MonoBehaviour
{
    public bool checkPause = false;
    public MonoBehaviour spaceship2DReference;
    public MonoBehaviour spaceship3DReference;
    public CameraSwitcher cameraRef;
    public GameObject timeUI;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            checkPause = !checkPause;
            if (checkPause == true)
            {
                Time.timeScale = 0;
                spaceship2DReference.enabled = false;
                spaceship3DReference.enabled = false;
                cameraRef.enabled = false;
                timeUI.SetActive(true);
            }


            if (checkPause == false)
            {
                Time.timeScale = 1;
                spaceship2DReference.enabled = true;
                spaceship3DReference.enabled = true;
                cameraRef.enabled = true;
                timeUI.SetActive(false);
            }
        }
	}
}
