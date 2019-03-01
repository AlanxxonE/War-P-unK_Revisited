using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Minerals : MonoBehaviour
{
    float offSetX;
    float offSetY;
    float offSetZ;
    float rotZ;
    //float kRot;
    float movementX;
    float movementY;
    float movementZ;
    public float pickUpProbability;
    public float fuelProbability;
    float activeProbability;
    //bool checkActive = true;
    public GameObject mineralTarget2;
    public Sprite greenMineral;
    public Sprite redMineral;
    public Sprite whiteMineral;
    public PlayerMovements_V2 spaceShip2DRef;
    public Ship spaceShip3DRef;

    // Use this for initialization
    void Start ()
    {
        pickUpProbability = Random.Range(0f, 1f);
        offSetX = Random.Range(-0.5f , 0.5f);
        offSetY = Random.Range(-0.5f, 0.5f);
        offSetZ = Random.Range(-0.5f, 0.5f);
        rotZ = Random.Range(-180f, 180f);
        activeProbability = Random.Range(0f,1f);
        fuelProbability = Random.Range(0f, 1f);

        if (activeProbability > 0.5f)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            gameObject.GetComponent<BoxCollider>().enabled = true;
            mineralTarget2.GetComponent<SpriteRenderer>().enabled = true;
            mineralTarget2.GetComponent<BoxCollider>().enabled = true;

            if (pickUpProbability < 0.75f)
            {
                //gameObject.GetComponent<SpriteRenderer>().color = Color.green;
                //mineralTarget2.GetComponent<SpriteRenderer>().color = Color.green;
                gameObject.tag = "Untagged";
                mineralTarget2.tag = "Untagged";
                if (fuelProbability < 0.5f)
                {
                    gameObject.GetComponent<SpriteRenderer>().sprite = greenMineral;
                    mineralTarget2.GetComponent<SpriteRenderer>().sprite = greenMineral;
                }
                else if (fuelProbability > 0.5f)
                {
                    gameObject.GetComponent<SpriteRenderer>().sprite = whiteMineral;
                    mineralTarget2.GetComponent<SpriteRenderer>().sprite = whiteMineral;
                }
                
            }
            else if (pickUpProbability > 0.75f)
            {
                //gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                //mineralTarget2.GetComponent<SpriteRenderer>().color = Color.red;
                gameObject.GetComponent<SpriteRenderer>().sprite = redMineral;
                mineralTarget2.GetComponent<SpriteRenderer>().sprite = redMineral;
            }
        }


        gameObject.transform.localRotation = Quaternion.Euler(0, 0, rotZ);
        mineralTarget2.transform.localRotation = Quaternion.Euler(0, 0, rotZ);
        //else if (activeProbability < 0.5f)
        //{
        //    gameObject.SetActive(false);
        //}
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        if (mineralTarget2 != null)
            mineralTarget2.transform.localScale += new Vector3(0.001f, 0.001f, 0.001f);
        //if(spaceShip2DRef.checkActive2D == true)
        //{
        //    gameObject.GetComponent<BoxCollider>().enabled = true;
        //}
        //else
        //{
        //    gameObject.GetComponent<BoxCollider>().enabled = false;
        //}

        //if(spaceShip3DRef.checkActive3D == true)
        //{
        //    if(mineralTarget2 != null)
        //    mineralTarget2.GetComponent<BoxCollider>().enabled = true;
        //}
        //else
        //{
        //    if(mineralTarget2 != null)
        //    mineralTarget2.GetComponent<BoxCollider>().enabled = false;
        //}
        if (movementX < offSetX)
        {
            movementX += 0.1f;
            gameObject.transform.localPosition += new Vector3(movementX, 0);
            mineralTarget2.transform.localPosition += new Vector3(movementX, 0, 0);
        }
        else if(movementY < offSetY)
        {
            movementY += 0.1f;
            gameObject.transform.localPosition += new Vector3(0, movementY);
            mineralTarget2.transform.localPosition += new Vector3(0, movementY, 0);
        }
        if(movementZ < offSetZ)
        {
            movementZ += 0.1f;
            mineralTarget2.transform.localPosition += new Vector3(0, 0, movementZ);
        }

        //kRot += 10f;
        //gameObject.transform.localRotation = Quaternion.Euler(0, 0, kRot);
        //if(checkActive == true && gameObject.activeSelf == true)
        //{
        //    checkActive = false;

        //    if (activeProbability > 0.5f)
        //    {
        //        if (pickUpProbability < 0.5f)
        //        {
        //            gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        //            mineralTarget2.GetComponent<SpriteRenderer>().color = Color.green;
        //        }
        //        else if (pickUpProbability > 0.5f)
        //        {
        //            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        //            mineralTarget2.GetComponent<SpriteRenderer>().color = Color.red;
        //        }

        //        gameObject.transform.position += new Vector3(offSetX, offSetY);
        //        mineralTarget2.transform.position += new Vector3(offSetX, offSetY, offSetZ);
        //    }
        //    else if (activeProbability < 0.5f)
        //    {
        //        gameObject.SetActive(false);
        //    }
        //}

        if (mineralTarget2 != null)
        {
            if (GetComponent<PickUp>().playerHit == true || mineralTarget2.GetComponent<PickUp>().playerHit == true)
            {
                    Destroy(mineralTarget2);
                if (gameObject != null)
                    Destroy(gameObject);
            }
        }
	}
}
