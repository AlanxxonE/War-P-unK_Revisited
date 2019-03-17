using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    public Text fuelReference;
    public int fuel = 100;
    int fuelTemp;
    bool fuelDecreaseRate = true;
    public Text scoreReference;
    public static int score = 0;
    int scoreTemp;
    public GameObject fuelBarRef;
    //public Texture fuelBarTex;

    public int hitPoints = 3;
    public GameObject spaceShip2DRef;
    public GameObject spaceShip3DRef;
    public GameObject lightRef;
    public GameObject warpLightRef;

    public GameObject wallRef;

    public Text greenMineralsCountRef;
    public static int greenMinerals = 0;
    public Text blueMineralsCountRef;
    public static int blueMinerals = 0;
    public Text purpleMineralsCountRef;
    public static int purpleMinerals = 0;

    public bool checkWarpDelay = false;
    public Animator animationReference;

    public float warpCharge;
    public GameObject warpParticleRef2D;
    public GameObject warpParticleRef3D;

    public GameObject fuelNotifierRef;
    public GameObject warpNotifierRef;
    public GameObject scoreNotifieref;
    public GameObject addFuelRef;
    public GameObject HPRef;
    public GameObject HPNotifierRef;

    // Use this for initialization
    void Start ()
    {
        score = 0;
        fuel = 100;
        greenMinerals = 0;
        blueMinerals = 0;
        purpleMinerals = 0;
        animationReference.speed = 1000;
        scoreTemp = Game_Manager.score;
        fuelTemp = fuel;
	}
	
	// Update is called once per frame
	void Update ()
    {
        fuelReference.text = fuel.ToString();
        scoreReference.text = score.ToString();
        if (greenMinerals < 25)
            greenMineralsCountRef.text = greenMinerals.ToString() + " / 25";

        if (blueMinerals < 10)
            blueMineralsCountRef.text = blueMinerals.ToString() + " / 10";

        if (purpleMinerals < 5)
            purpleMineralsCountRef.text = purpleMinerals.ToString() + " / 5";

        if (fuelDecreaseRate == true)
        {
            StartCoroutine("DecreaseFuel");
        }
        fuelBarRef.GetComponent<RectTransform>().sizeDelta = new Vector2(fuel*3, 40);

        if(fuel == 0)
        {
            print("RunOutOfFuel");
            SceneManager.LoadScene("Score_Menu", LoadSceneMode.Single);
        }
        if(hitPoints == 2)
        {
            //lightRef.GetComponent<Light>().color = Color.yellow;
            HPRef.GetComponent<Image>().color = Color.yellow;
        }
        else if( hitPoints == 1)
        {
            //lightRef.GetComponent<Light>().color = Color.red;
            HPRef.GetComponent<Image>().color = Color.red;
        }
        else if (hitPoints <= 0)
        {
            SceneManager.LoadScene("Score_Menu", LoadSceneMode.Single);
        }

        if(Input.GetKey(KeyCode.W) && checkWarpDelay == false)
        {
            warpCharge += 0.01f;

            if (Time.timeScale > 0.1f)
                Time.timeScale -= 0.01f;
            
            if(Time.timeScale < 0.5f)
                gameObject.GetComponent<Pause_State>().checkPause = true;

            if (spaceShip2DRef.GetComponent<PlayerMovements_V2>().checkActive2D == true)
            {
                warpParticleRef2D.SetActive(true);
            }
            if (spaceShip3DRef.GetComponent<Ship>().checkActive3D == true)
            {
                warpParticleRef3D.SetActive(true);
            }

            if (warpCharge > 1)
            {
                gameObject.GetComponent<Pause_State>().checkPause = false;
                Time.timeScale = 1.0f;
                animationReference.speed = 1;
                StartCoroutine("WarpDelay");
            }
        }

        if(score >= 300)
        {
            wallRef.SetActive(true);
        }

        if (Input.GetKeyUp(KeyCode.W) || warpCharge == 0f)
        {
            gameObject.GetComponent<Pause_State>().checkPause = false;
            Time.timeScale = 1.0f;
            warpCharge = 0;
            warpParticleRef2D.SetActive(false);
            warpParticleRef3D.SetActive(false);
        }

        if(scoreTemp != Game_Manager.score)
        {
            StartCoroutine("activateScoreNotifier");
            scoreTemp = Game_Manager.score;
        }
        if(fuelTemp != fuel)
        {
            if (fuelTemp < fuel)
                StartCoroutine("addFuelAnim");
            fuelTemp = fuel;
        }

        if(fuel <= 20)
        {
            fuelNotifierRef.SetActive(true);
            fuelNotifierRef.GetComponent<Image>().color = Color.red;
        }
        else
        {
            fuelNotifierRef.GetComponent<Image>().color = Color.yellow;
        }
    }

    //private void OnGUI()
    //{
    //    GUI.Box(new Rect((fuelBarRef.transform.position.x), 5, fuel, 10), fuelBarTex);
    //}

    IEnumerator DecreaseFuel()
    {
        fuelDecreaseRate = false;
        StartCoroutine("activateFuelNotifier");
        fuel -= 10;
        yield return new WaitForSeconds(5f);
        fuelDecreaseRate = true;
    }

    IEnumerator WarpDelay()
    {
        if(checkWarpDelay == false)
        {
            warpLightRef.SetActive(false);
            animationReference.Play("Recall", 0,0);
            spaceShip2DRef.GetComponent<PlayerMovements_V2>().checkActive2D = !spaceShip2DRef.GetComponent<PlayerMovements_V2>().checkActive2D;
            spaceShip2DRef.GetComponent<BoxCollider>().enabled = !spaceShip2DRef.GetComponent<BoxCollider>().enabled;
            spaceShip3DRef.GetComponent<Ship>().checkActive3D = !spaceShip3DRef.GetComponent<Ship>().checkActive3D;
            spaceShip3DRef.GetComponent<BoxCollider>().enabled = !spaceShip3DRef.GetComponent<BoxCollider>().enabled;
        }
        checkWarpDelay = true;
        yield return new WaitForSeconds(3f);
        StartCoroutine("activateWarpNotifier");
        warpLightRef.SetActive(true);
        checkWarpDelay = false;
    }

    IEnumerator activateFuelNotifier()
    {
        fuelNotifierRef.SetActive(true);
        yield return new WaitForSeconds(1f);
        fuelNotifierRef.SetActive(false);
    }

    IEnumerator activateWarpNotifier()
    {
        warpNotifierRef.SetActive(true);
        yield return new WaitForSeconds(1f);
        warpNotifierRef.SetActive(false);
    }

    IEnumerator activateScoreNotifier()
    {
        scoreNotifieref.SetActive(true);
        yield return new WaitForSeconds(0.30f);
        scoreNotifieref.SetActive(false);
    }

    IEnumerator addFuelAnim()
    {
        addFuelRef.SetActive(true);
        yield return new WaitForSeconds(0.30f);
        addFuelRef.SetActive(false);
    }

    IEnumerator HitPointAnim()
    {
        HPNotifierRef.SetActive(true);
        yield return new WaitForSeconds(0.30f);
        HPNotifierRef.SetActive(false);
    }
}
