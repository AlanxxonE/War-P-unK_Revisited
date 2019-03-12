﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PairedUpAsteroid : MonoBehaviour
{
    public float asteroidSize;
    public float asteroidSpeed;
    public float offSetX;
    public float offSetY;
    int mineralProbability;


    //public Animator animatorReference;
    public GameObject target1;
    public GameObject target2;
    public Asteroid_V3 mineralReference2D;
    public Asteroid_V3 mineralReference3D;
    public GameObject mineralTarget1Reference;
    public GameObject mineralTarget2Reference;
    public GameObject asteroidTarget1Reference;
    public GameObject asteroidTarget2Reference;
    public Pause_State pauseRef;
    public Game_Manager gMRef;

    // Use this for initialization
    void Start ()
    {
        asteroidSize = Random.Range(2.0f, 5.0f);

        if (Game_Manager.score >= 200)
        {
            asteroidSpeed = Random.Range(-0.3f, -0.5f);
        }
        else if( Game_Manager.score >= 100)
        {
            asteroidSpeed = Random.Range(-0.2f, -0.4f);
        }
        else
        {
            asteroidSpeed = Random.Range(-0.1f, -0.3f);
        }

        offSetX = Random.Range(-3.0f, 3.0f);
        offSetY = Random.Range(-5.0f, 2.0f);
        mineralProbability = Random.Range(0, 2);

        transform.localScale = new Vector3(asteroidSize,asteroidSize,asteroidSize);

        asteroidTarget1Reference.transform.position = target1.transform.position;
        asteroidTarget2Reference.transform.position = target2.transform.position;

        asteroidTarget1Reference.transform.position += new Vector3(0, offSetY, 0);
        asteroidTarget2Reference.transform.position += new Vector3(offSetX, offSetY, 0);
    }

    // Update is called once per frame
    void Update ()
    {

        if (pauseRef.checkPause == false)
        {
            if ((mineralReference2D.mineralsCreation == true || mineralReference3D.mineralsCreation == true) && mineralProbability == 1)
            {
                asteroidTarget1Reference.transform.position += new Vector3(-0.1f, 0);
                asteroidTarget2Reference.transform.Translate(0, 0, -0.1f);
                mineralTarget1Reference.SetActive(true);
                mineralTarget2Reference.SetActive(true);
            }
            else
            {
                asteroidTarget1Reference.transform.position += new Vector3(asteroidSpeed, 0);
                asteroidTarget2Reference.transform.Translate(0, 0, asteroidSpeed);

            }
        }
    }
}
