using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Minerals : MonoBehaviour
{
    float offSetX;
    float offSetY;
    float offSetZ;
    public float pickUpProbability;
    float activeProbability;
    bool checkActive = true;
    public GameObject mineralTarget2;


    // Use this for initialization
    void Start ()
    {
        pickUpProbability = Random.Range(0f, 1f);
        offSetX = Random.Range(0f, 1f);
        offSetY = Random.Range(0f, 1f);
        offSetZ = Random.Range(0f, 1f);
        activeProbability = Random.Range(0f,1f);

        if (activeProbability > 0.5f)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            gameObject.GetComponent<BoxCollider>().enabled = true;
            mineralTarget2.GetComponent<SpriteRenderer>().enabled = true;
            mineralTarget2.GetComponent<BoxCollider>().enabled = true;

            if (pickUpProbability < 0.5f)
            {
                gameObject.GetComponent<SpriteRenderer>().color = Color.green;
                mineralTarget2.GetComponent<SpriteRenderer>().color = Color.green;
            }
            else if (pickUpProbability > 0.5f)
            {
                gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                mineralTarget2.GetComponent<SpriteRenderer>().color = Color.red;
            }

            gameObject.transform.position += new Vector3(offSetX, offSetY);
            mineralTarget2.transform.position += new Vector3(offSetX, offSetY, offSetZ);
        }
        //else if (activeProbability < 0.5f)
        //{
        //    gameObject.SetActive(false);
        //}
    }

    // Update is called once per frame
    void Update ()
    {
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
