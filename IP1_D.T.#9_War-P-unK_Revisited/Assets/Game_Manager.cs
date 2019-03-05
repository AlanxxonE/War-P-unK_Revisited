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
            animationReference.Play(); 
            StartCoroutine("WarpDelay");
        }
	}

    IEnumerator DecreaseFuel()
    {
        fuelDecreaseRate = false;
        fuel -= 10;
        yield return new WaitForSeconds(3f);
        fuelDecreaseRate = true;
    }

    IEnumerator WarpDelay()
    {
        checkWarpDelay = true;
        yield return new WaitForSeconds(3f);
        checkWarpDelay = false;
    }
}
