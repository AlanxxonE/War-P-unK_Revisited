using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PairedUpAsteroid : MonoBehaviour
{
    public float asteroidSize;
    public float asteroidSpeed;
    public float offSetX;
    public float offSetY;
    int mineralProbability;
    int asteroidSprite;


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

    public Sprite ast1;
    public Sprite ast2;
    public Sprite ast3;
    public Sprite ast4;

    // Use this for initialization
    void Start ()
    {
        asteroidSize = Random.Range(2.0f, 5.0f);
        asteroidSprite = Random.Range(0, 5);
        
        if(asteroidSprite <= 1)
        {
            mineralReference2D.GetComponent<SpriteRenderer>().sprite = ast1;
            mineralReference3D.GetComponent<SpriteRenderer>().sprite = ast1;
            mineralReference2D.destoryHit = 2;
            mineralReference3D.destoryHit = 2;
        }
        else if(asteroidSprite <= 2)
        {
            mineralReference2D.GetComponent<SpriteRenderer>().sprite = ast2;
            mineralReference3D.GetComponent<SpriteRenderer>().sprite = ast2;
            mineralReference2D.destoryHit = 3;
            mineralReference3D.destoryHit = 3;
        }
        else if (asteroidSprite <= 3)
        {
            mineralReference2D.GetComponent<SpriteRenderer>().sprite = ast3;
            mineralReference3D.GetComponent<SpriteRenderer>().sprite = ast3;
            mineralReference2D.destoryHit = 4;
            mineralReference3D.destoryHit = 4;
        }
        else if (asteroidSprite <= 4)
        {
            mineralReference2D.GetComponent<SpriteRenderer>().sprite = ast4;
            mineralReference3D.GetComponent<SpriteRenderer>().sprite = ast4;
            mineralReference2D.destoryHit = 5;
            mineralReference3D.destoryHit = 5;
        }


        if (Game_Manager.score >= 1000)
        {
            asteroidSpeed = Random.Range(-0.3f, -0.4f);
        }
        else if( Game_Manager.score >= 500)
        {
            asteroidSpeed = Random.Range(-0.2f, -0.3f);
        }
        else
        {
            asteroidSpeed = Random.Range(-0.1f, -0.2f);
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
                if (asteroidTarget1Reference != null)
                {
                    asteroidTarget1Reference.transform.position += new Vector3(-0.1f, 0);
                    if (asteroidTarget2Reference.transform.position.z > gMRef.spaceShip3DRef.transform.position.z - 2)
                        asteroidTarget2Reference.transform.Translate(0, 0, -0.1f);
                    else
                        asteroidTarget2Reference.transform.Translate(0, 0, asteroidSpeed - 0.5f);
                    if (mineralTarget1Reference != null)
                    {
                        mineralTarget1Reference.SetActive(true);
                        if (mineralTarget2Reference != null)
                        mineralTarget2Reference.SetActive(true);
                    }
                    else
                    {
                        Destroy(asteroidTarget1Reference);
                        Destroy(asteroidTarget2Reference);
                    }
                }
            }
            else
            {
                if (asteroidTarget1Reference != null)
                {
                    asteroidTarget1Reference.transform.position += new Vector3(asteroidSpeed, 0);
                    if (asteroidTarget2Reference != null)
                    {
                        if (asteroidTarget2Reference.transform.position.z > gMRef.spaceShip3DRef.transform.position.z - 2)
                            asteroidTarget2Reference.transform.Translate(0, 0, asteroidSpeed);
                        else
                            asteroidTarget2Reference.transform.Translate(0, 0, asteroidSpeed - 2);
                    }
                }
            }
        }
    }
}
