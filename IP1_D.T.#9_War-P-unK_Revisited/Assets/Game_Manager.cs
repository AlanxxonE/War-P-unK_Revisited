using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    public Text fuelReference;
    public int fuel = 100;
    bool fuelDecreaseRate = true;
    public Text scoreReference;
    public int score = 0;
    public GameObject fuelBarRef;
    //public Texture fuelBarTex;

    public int hitPoints = 3;
    public GameObject spaceShip2DRef;
    public GameObject spaceShip3DRef;
    public GameObject lightRef;

    public Text greenMineralsCountRef;
    public int greenMinerals = 0;

    public bool checkWarpDelay = false;
    public Animator animationReference;

    // Use this for initialization
    void Start ()
    {
        animationReference.speed = 1000;
	}
	
	// Update is called once per frame
	void Update ()
    {
        fuelReference.text = fuel.ToString();
        scoreReference.text = score.ToString();
        if (greenMinerals < 25)
            greenMineralsCountRef.text = greenMinerals.ToString() + " / 25";
        if(fuelDecreaseRate == true)
        {
            StartCoroutine("DecreaseFuel");
        }
        fuelBarRef.GetComponent<RectTransform>().sizeDelta = new Vector2(fuel*3, 40);

        if(fuel == 0)
        {
            SceneManager.LoadScene("Main_Menu", LoadSceneMode.Single);
        }
        if(hitPoints == 2)
        {
            lightRef.GetComponent<Light>().color = Color.magenta;
        }
        else if( hitPoints == 1)
        {
            lightRef.GetComponent<Light>().color = Color.red;
        }
        else if (hitPoints <= 0)
        {
            SceneManager.LoadScene("Main_Menu", LoadSceneMode.Single);
        }

        if(Input.GetKeyDown(KeyCode.W) && checkWarpDelay == false)
        {
            animationReference.speed = 1;
            StartCoroutine("WarpDelay");
        }
	}

    //private void OnGUI()
    //{
    //    GUI.Box(new Rect((fuelBarRef.transform.position.x), 5, fuel, 10), fuelBarTex);
    //}

    IEnumerator DecreaseFuel()
    {
        fuelDecreaseRate = false;
        fuel -= 10;
        yield return new WaitForSeconds(4f);
        fuelDecreaseRate = true;
    }

    IEnumerator WarpDelay()
    {
        if(checkWarpDelay == false)
        {
            animationReference.Play("Recall", 0,0);
            spaceShip2DRef.GetComponent<PlayerMovements_V2>().checkActive2D = !spaceShip2DRef.GetComponent<PlayerMovements_V2>().checkActive2D;
            spaceShip2DRef.GetComponent<BoxCollider>().enabled = !spaceShip2DRef.GetComponent<BoxCollider>().enabled;
            spaceShip3DRef.GetComponent<Ship>().checkActive3D = !spaceShip3DRef.GetComponent<Ship>().checkActive3D;
            spaceShip3DRef.GetComponent<BoxCollider>().enabled = !spaceShip3DRef.GetComponent<BoxCollider>().enabled;
        }
        checkWarpDelay = true;
        yield return new WaitForSeconds(3f);
        checkWarpDelay = false;
    }
}
