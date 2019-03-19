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

    bool movedUp = false;
    bool movedRight = false;
    Quaternion original2DRot;
    Quaternion original3DPos;


    void Start()
    {
        original2DRot = camera2DRef.transform.rotation;
        original3DPos = camera3DRef.transform.rotation;
        
    }

    void Update()
    {
        //if(Input.GetKey(KeyCode.UpArrow))
        //{
        //    if (moveUp <= 2)
        //    {
        //        moveUp += 0.2f;
        //        //camera2DRef.transform.localRotation = Quaternion.Euler(-moveUp, 0, 0);
        //        camera2DRef.transform.localEulerAngles += new Vector3(-moveUp, 0, 0);
        //        camera3DRef.transform.localEulerAngles += new Vector3(-moveUp, 0, 0);

        //    }
        //}
        //else if (!Input.GetKey(KeyCode.UpArrow) && moveUp >= 0)
        //{
        //    moveUp -= 0.1f;
        //    camera2DRef.transform.localEulerAngles -= new Vector3(-moveUp, 0, 0);
        //    camera3DRef.transform.localEulerAngles -= new Vector3(-moveUp, 0, 0);
        //}

        //if (Input.GetKey(KeyCode.DownArrow))
        //{
        //    if (moveDown <= 2)
        //    {
        //        moveDown += 0.2f;
        //        camera2DRef.transform.localEulerAngles += new Vector3(moveDown, 0, 0);
        //        camera3DRef.transform.localEulerAngles += new Vector3(moveDown, 0, 0);
        //    }
        //}
        //else if (!Input.GetKey(KeyCode.DownArrow) && moveDown >= 0)
        //{
        //    moveDown -= 0.1f;
        //    camera2DRef.transform.localEulerAngles += new Vector3(moveDown, 0, 0);
        //    camera3DRef.transform.localEulerAngles += new Vector3(moveDown, 0, 0);
        //}

        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    if (moveLeft < 3)
        //    {
        //        camera3DRef.transform.localEulerAngles += new Vector3(0, -moveLeft, 0);
        //        moveLeft += 0.2f;
        //    }
        //}
        //else if (!Input.GetKey(KeyCode.LeftArrow) && moveLeft > 0)
        //{
        //    camera3DRef.transform.localEulerAngles += new Vector3(0, -moveLeft, 0);
        //    moveLeft -= 0.2f;
        //}


        //if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    if (moveRight < 3)
        //    {
        //        camera3DRef.transform.localEulerAngles += new Vector3(0, moveRight, 0);
        //        moveRight += 0.2f;
        //        print(moveRight);
        //    }
        //}
        //else if (!Input.GetKey(KeyCode.RightArrow) && moveRight > 0)
        //{
        //    camera3DRef.transform.localEulerAngles += new Vector3(0, moveRight, 0);
        //    moveRight -= 0.2f;
        //}


        //camera2DRef.localPosition = original2DPos;
        //camera3DRef.localPosition = original3DPos;

        //Vector3 temp = Vector3.forward - camera3DRef.forward;
        //temp.z = 0;
        //print(temp);

        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (Quaternion.Angle(camera2DRef.rotation, original2DRot) <= 2.9f)
            {
                camera2DRef.transform.Rotate(-0.1f,0,0);
                camera3DRef.transform.Rotate(-0.1f, 0, 0);
            }

            movedUp = true;
        }

        if ((!Input.GetKey(KeyCode.UpArrow)) && movedUp)
        {
            camera2DRef.transform.Rotate(0.1f, 0, 0);
            camera3DRef.transform.Rotate(0.1f, 0, 0);

            if (Quaternion.Angle(camera2DRef.rotation, original2DRot) <= 0)
            {
                movedUp = false;
            }
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            
            if (Mathf.Abs((camera3DRef.rotation.eulerAngles.y % 360) - original3DPos.eulerAngles.y) <= 5)
            {
                camera3DRef.transform.Rotate(0,0.1f,0);
            }

            movedRight = true;
        }

        if ((!Input.GetKey(KeyCode.RightArrow)) && movedRight)
        {
            if (Mathf.Abs((camera3DRef.rotation.eulerAngles.y % 360) - original3DPos.eulerAngles.y) < 0.2f)
            {

                movedRight = false;
            }

            print(Mathf.Abs((camera3DRef.rotation.eulerAngles.y % 360) - original3DPos.eulerAngles.y));

            camera3DRef.transform.Rotate(0,-0.1f,0);


        }
    }
}
