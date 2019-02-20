﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovements_V2 : MonoBehaviour
{
    private Vector3 spaceVerticalSpeed = new Vector3(0, 0.3f);

    public BulletSpawner_V2 bulletSpawnerReference;
    public bool reload = true;
    public bool checkActive2D = true;

    void Update()
    {

		if(Input.GetKey(KeyCode.UpArrow) && transform.localPosition.y < 12)
        {
            transform.localPosition += spaceVerticalSpeed;
        }
        else if(Input.GetKey(KeyCode.DownArrow) && transform.localPosition.y > -8)
        {
            transform.localPosition -= spaceVerticalSpeed;
        }

        if (Input.GetKey(KeyCode.Space) && reload == true && checkActive2D == true)
        {
            bulletSpawnerReference.SpawnBulletV2();
        }

        if (Input.GetKeyDown(KeyCode.W))
            checkActive2D = !checkActive2D;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Asteroid" && checkActive2D == true)
        {
            SceneManager.LoadScene("Main_Menu", LoadSceneMode.Single);
            print("died");
        }
    }
}
