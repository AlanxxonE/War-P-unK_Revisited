﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_State : MonoBehaviour
{
    public bool cutSceneCheck = false;
    public bool checkPause = false;
    public MonoBehaviour spaceship2DReference;
    public MonoBehaviour spaceship3DReference;
    public CameraSwitcher cameraRef;
    public Game_Manager gMRef;
    public GameObject timeUI;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || cutSceneCheck)
        {
            checkPause = !checkPause;
            if (checkPause == true)
            {
                Time.timeScale = 0;
                spaceship2DReference.enabled = false;
                spaceship3DReference.enabled = false;
                cameraRef.enabled = false;
                gMRef.enabled = false;
                timeUI.SetActive(true);
                cutSceneCheck = false;
            }


            if (checkPause == false)
            {
                Time.timeScale = 1;
                spaceship2DReference.enabled = true;
                spaceship3DReference.enabled = true;
                cameraRef.enabled = true;
                gMRef.enabled = true;
                timeUI.SetActive(false);
            }
        }
	}
}
