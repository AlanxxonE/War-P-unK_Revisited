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
    bool movedDown = false;
    Quaternion original2DRot;
    Quaternion original3DPos;

    float axisY;
    float axisX;

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

        axisY = Input.GetAxis("Vertical");
        axisX = Input.GetAxis("Horizontal");
        print(camera2DRef.transform.localEulerAngles.x);


        //if (axisY < 0 && !(camera2DRef.transform.localEulerAngles.x > 10)) { 
        //    camera2DRef.transform.Rotate(-axisY * 0.2f, 0, 0);
        //    camera3DRef.transform.Rotate(-axisY * 0.2f, axisX * 0.2f, 0);
        //}
        //else if (axisY > 0 && !(360 - camera2DRef.transform.localEulerAngles.x > 10) || camera2DRef.transform.localEulerAngles.x == 0)
        //{
        //    camera2DRef.transform.Rotate(-axisY * 0.2f, 0, 0);
        //    camera3DRef.transform.Rotate(-axisY * 0.2f, axisX * 0.2f, 0);
        //}

        //if (axisX < 0 && !(camera3DRef.transform.localEulerAngles.y > 350))
        //    camera3DRef.transform.Rotate(-axisX * 0.2f, 0, 0);

        //if (axisX > 0 && !(camera3DRef.transform.localEulerAngles.y < 10))
        //    camera3DRef.transform.Rotate(-axisX * 0.2f, 0, 0);

        axisY = Input.GetAxis("Vertical");
        axisX = -1*Input.GetAxis("Horizontal");
        if (axisY > 0 && (camera2DRef.transform.rotation.x > -0.05))
        {
            camera2DRef.transform.Rotate(-axisY * 0.5f, 0, 0);
            camera3DRef.transform.Rotate(-axisY * 0.5f, 0, 0);
        }
        else if (axisY < 0 && (camera2DRef.transform.rotation.x < 0.05))
        {
            camera2DRef.transform.Rotate(-axisY * 0.5f, 0, 0);
            camera3DRef.transform.Rotate(-axisY * 0.5f, 0, 0);
        }
        else if (axisX > 0 && (camera3DRef.transform.rotation.y > -0.05))
            camera3DRef.transform.Rotate(0, -axisX * 0.5f, 0);

        else if (axisX < 0 && (camera3DRef.transform.rotation.y < 0.05))
            camera3DRef.transform.Rotate(0, -axisX * 0.5f, 0);


        //camera2DRef.transform.eulerAngles = new Vector3(Mathf.Clamp(camera2DRef.transform.eulerAngles.x, -10, 10), Mathf.Clamp(camera2DRef.transform.eulerAngles.y, -10, 10), 0);


        //////////////////////////////////////////////////////////
        //if (Input.GetKey(KeyCode.UpArrow) && movedDown == false)
        //{
        //    if (Quaternion.Angle(camera2DRef.rotation, original2DRot) <= 5f)
        //    {
        //        camera2DRef.transform.Rotate(-0.4f,0,0);
        //        camera3DRef.transform.Rotate(-0.4f, 0, 0);
        //    }

        //    movedUp = true;
        //}

        //if ((!Input.GetKey(KeyCode.UpArrow)) && movedUp && movedDown == false)
        //{
        //    camera2DRef.transform.Rotate(0.4f, 0, 0);
        //    camera3DRef.transform.Rotate(0.4f, 0, 0);

        //    if (Quaternion.Angle(camera2DRef.rotation, original2DRot) <= 0.1f)
        //    {
        //        movedUp = false;
        //    }
        //}

        //if (Input.GetKey(KeyCode.DownArrow) && movedUp == false)
        //{
        //    if (Quaternion.Angle(camera2DRef.rotation, original2DRot) <= 4f)
        //    {
        //        camera2DRef.transform.Rotate(0.2f, 0, 0);
        //        camera3DRef.transform.Rotate(0.2f, 0, 0);
        //    }

        //    movedDown = true;
        //}

        //if ((!Input.GetKey(KeyCode.DownArrow)) && movedDown && movedUp == false)
        //{
        //    camera2DRef.transform.Rotate(-0.2f, 0, 0);
        //    camera3DRef.transform.Rotate(-0.2f, 0, 0);

        //    if (Quaternion.Angle(camera2DRef.rotation, original2DRot) <= 0.1f)
        //    {
        //        movedDown = false;
        //    }
        //}

        //if (Input.GetKey(KeyCode.RightArrow))
        //{

        //    if (Mathf.Abs((camera3DRef.rotation.eulerAngles.y % 360) - original3DPos.eulerAngles.y) <= 5)
        //    {
        //        camera3DRef.transform.Rotate(0,0.2f,0);
        //    }

        //    movedRight = true;
        //}

        //if ((!Input.GetKey(KeyCode.RightArrow)) && movedRight)
        //{
        //    if (Mathf.Abs((camera3DRef.rotation.eulerAngles.y % 360) - original3DPos.eulerAngles.y) < 1)
        //    {

        //        movedRight = false;
        //    }

        //    print(Mathf.Abs((camera3DRef.rotation.eulerAngles.y % 360) - original3DPos.eulerAngles.y));

        //    camera3DRef.transform.Rotate(0,-0.2f,0);


        //}
    }
}
