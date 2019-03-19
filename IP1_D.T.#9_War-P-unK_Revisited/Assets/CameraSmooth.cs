using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSmooth : MonoBehaviour {

    public Transform camera2DRef;
    public Transform camera3DRef;

    float moveUp = 0;
    float moveDown = 0;
    float moveLeft = 0;
    float moveRight = 0;

    //Vector3 original2DPos;
    //Vector3 original3DPos;

    //void OnEnable()
    //{
    //    original2DPos = camera2DRef.localPosition;
    //    original3DPos = camera3DRef.localPosition;
    //}

    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            if (moveUp < 3)
            {
                //camera2DRef.transform.localRotation = Quaternion.Euler(-moveUp, 0, 0);
                camera2DRef.transform.localEulerAngles += new Vector3(-moveUp, 0, 0);
                camera3DRef.transform.localEulerAngles += new Vector3(-moveUp, 0, 0);
                moveUp += 0.2f;
            }
            else if (!Input.GetKey(KeyCode.UpArrow) && moveUp > 0)
            {
                camera2DRef.transform.localEulerAngles -= new Vector3(-moveUp, 0, 0);
                camera3DRef.transform.localEulerAngles -= new Vector3(-moveUp, 0, 0);
                moveUp -= 0.2f;
            }
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            if (moveDown < 3)
            {
                camera2DRef.transform.localEulerAngles += new Vector3(moveDown, 0, 0);
                camera3DRef.transform.localEulerAngles += new Vector3(moveDown, 0, 0);
                moveDown += 0.2f;
            }
            else if (!Input.GetKey(KeyCode.DownArrow) && moveDown > 0)
            {
                camera2DRef.transform.localEulerAngles += new Vector3(moveDown, 0, 0);
                camera3DRef.transform.localEulerAngles += new Vector3(moveDown, 0, 0);
                moveDown -= 0.2f;
            }
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (moveLeft < 3)
            {
                camera3DRef.transform.localEulerAngles += new Vector3(0, -moveLeft, 0);
                moveLeft += 0.2f;
            }
            else if (!Input.GetKey(KeyCode.LeftArrow) && moveLeft > 0)
            {
                camera3DRef.transform.localEulerAngles += new Vector3(0, -moveLeft, 0);
                moveLeft -= 0.2f;
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            if (moveRight < 3)
            {
                camera3DRef.transform.localEulerAngles += new Vector3(0, moveRight, 0);
                moveRight += 0.2f;
                print(moveRight);
            }
            else if (!Input.GetKey(KeyCode.RightArrow) && moveRight > 0)
            {
                camera3DRef.transform.localEulerAngles += new Vector3(0, moveRight, 0);
                moveRight -= 0.2f;
            }
        }
        //camera2DRef.localPosition = original2DPos;
        //camera3DRef.localPosition = original3DPos;
    }
}
