using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public GameObject CameraOne;
    public GameObject CameraTwo;
    public GameObject spaceShip2D;
    public GameObject spaceShip3D;

    public KeyCode switchKey = KeyCode.W;

    public int CameraControl = 0;

    private void Update()
    {
        bool isWPressed = Input.GetKeyDown(switchKey);

        if (isWPressed)
        {
            if (CameraControl == 0)
            {
                //    //spaceShip2D.SetActive(true);
                //spaceShip2D.GetComponent<BoxCollider>().enabled = true;
                //    //spaceShip3D.SetActive(false);
                //spaceShip3D.GetComponent<BoxCollider>().enabled = false;
                CameraOne.SetActive(true);
                CameraTwo.SetActive(false);
                CameraControl = 1;
            }
            else if (CameraControl == 1)
            {
                //    //spaceShip2D.SetActive(false);
                //spaceShip2D.GetComponent<BoxCollider>().enabled = false;
                //    //spaceShip3D.SetActive(true);
                //spaceShip3D.GetComponent<BoxCollider>().enabled= true;
                CameraOne.SetActive(false);
                CameraTwo.SetActive(true);
                CameraControl = 0;
            }
        }
    }
}
