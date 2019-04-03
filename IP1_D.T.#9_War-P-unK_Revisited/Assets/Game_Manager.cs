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
    public GameObject camera2DRef;
    public GameObject camera3DRef;
    bool checkRotationWarp = false;
    public GameObject glitchEffectRef;

    public GameObject wallRef;
    public Material switchBackground;
    public GameObject backgroundRef;

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

    public Sprite standardShip;
    public Sprite powerUpShip;
    public GameObject fadeInDeath;

    public GameObject bulletSpawnerRef;
    public GameObject bulletSlotRef;
    public GameObject torpedoSpawnerRef;
    public GameObject torpedoSlotRef;
    public GameObject shotgunSpawnerRef;
    public GameObject shotgunSlotRef;
    public GameObject laserSpawnerRef;
    public GameObject laserSlotRef;

    public static int radiumCurrency = 49900;
    public static bool torpedoUnlocked = false;
    public static bool shotgunUnlocked = false;
    public static bool laserUnlocked = false;

    bool addCurrency = true;
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

        PlayerMovements_V2.laserBeamSprite = true;
    }
	
	// Update is called once per frame
	void Update ()
    {
        fuelReference.text = fuel.ToString();
        scoreReference.text = score.ToString();
        if (greenMinerals <= 10)
            greenMineralsCountRef.text = greenMinerals.ToString() + " / 10";
        else
            greenMinerals = 10;

        if (blueMinerals <= 3)
            blueMineralsCountRef.text = blueMinerals.ToString() + " / 3";
        else
            blueMinerals = 3;

        if (purpleMinerals <= 1)
            purpleMineralsCountRef.text = purpleMinerals.ToString() + " / 1";
        else
            purpleMinerals = 1;

        if (fuelDecreaseRate == true)
        {
            StartCoroutine("DecreaseFuel");
        }
        fuelBarRef.GetComponent<RectTransform>().sizeDelta = new Vector2(fuel*3, 40);

        if(fuel == 0)
        {
            print("RunOutOfFuel");
            StartCoroutine("PlayerDeath");
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
            StartCoroutine("PlayerDeath");
        }

        if(Input.GetKey(KeyCode.W) && checkWarpDelay == false)
        {
            warpCharge += 0.01f;

            if (glitchEffectRef.activeSelf == false)
                glitchEffectRef.SetActive(true);

            if (spaceShip2DRef.GetComponent<PlayerMovements_V2>().checkActive2D == true)
            {
                camera2DRef.transform.Rotate(0, -warpCharge * 1.8f, 0);
                checkRotationWarp = true;
            }
            if(spaceShip3DRef.GetComponent<Ship>().checkActive3D == true)
            {
                camera3DRef.transform.Rotate(0, warpCharge * 1.8f, 0);
                checkRotationWarp = true;
            }
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
            StartCoroutine("EndGlitchEffect");

            if (spaceShip2DRef.GetComponent<PlayerMovements_V2>().checkActive2D == true && checkRotationWarp == true)
            {
                camera2DRef.transform.localRotation = Quaternion.Euler(0, 0, 0);
                checkRotationWarp = false;
            }
            if(spaceShip3DRef.GetComponent<Ship>().checkActive3D == true && checkRotationWarp == true)
            {
                camera3DRef.transform.localRotation = Quaternion.Euler(0, 0, 0);
                checkRotationWarp = false;
            }
            gameObject.GetComponent<Pause_State>().checkPause = false;
            Time.timeScale = 1.0f;
            warpCharge = 0;
            warpParticleRef2D.SetActive(false);
            warpParticleRef3D.SetActive(false);
        }

        //if(score >= 800)
        //{
        //    backgroundRef.GetComponent<MeshRenderer>().material = switchBackground;
        //}

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

        if (spaceShip2DRef.GetComponent<PlayerMovements_V2>().checkActive2D == true)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                if(spaceShip2DRef.GetComponent<SpriteRenderer>().sprite != standardShip)
                spaceShip2DRef.GetComponent<SpriteRenderer>().sprite = standardShip;

                if (bulletSpawnerRef.activeSelf == false)
                {
                    spaceShip2DRef.GetComponent<PlayerMovements_V2>().reload = true;
                    bulletSpawnerRef.SetActive(true);
                    bulletSlotRef.SetActive(true);
                }
                if (torpedoSpawnerRef.activeSelf == true)
                {
                    torpedoSpawnerRef.SetActive(false);
                    torpedoSlotRef.SetActive(false);
                }
                if (shotgunSpawnerRef.activeSelf == true)
                {
                    shotgunSpawnerRef.SetActive(false);
                    shotgunSlotRef.SetActive(false);
                }
                if(laserSpawnerRef.activeSelf == true)
                {
                    laserSpawnerRef.SetActive(false);
                    laserSlotRef.SetActive(false);
                }
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2) && torpedoUnlocked == true)
            {

                if (spaceShip2DRef.GetComponent<SpriteRenderer>().sprite != powerUpShip)
                    spaceShip2DRef.GetComponent<SpriteRenderer>().sprite = powerUpShip;

                if (torpedoSpawnerRef.activeSelf == false)
                {
                    spaceShip2DRef.GetComponent<PlayerMovements_V2>().reload = true;
                    torpedoSpawnerRef.SetActive(true);
                    torpedoSlotRef.SetActive(true);
                }
                if (bulletSpawnerRef.activeSelf == true)
                {
                    bulletSpawnerRef.SetActive(false);
                    bulletSlotRef.SetActive(false);
                }
                if (shotgunSpawnerRef.activeSelf == true)
                {
                    shotgunSpawnerRef.SetActive(false);
                    shotgunSlotRef.SetActive(false);
                }
                if (laserSpawnerRef.activeSelf == true)
                {
                    laserSpawnerRef.SetActive(false);
                    laserSlotRef.SetActive(false);
                }
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3) && shotgunUnlocked == true)
            {

                if (spaceShip2DRef.GetComponent<SpriteRenderer>().sprite != powerUpShip)
                    spaceShip2DRef.GetComponent<SpriteRenderer>().sprite = powerUpShip;

                if (shotgunSpawnerRef.activeSelf == false)
                {
                    spaceShip2DRef.GetComponent<PlayerMovements_V2>().reload = true;
                    shotgunSpawnerRef.SetActive(true);
                    shotgunSlotRef.SetActive(true);
                }
                if (bulletSpawnerRef.activeSelf == true)
                {
                    bulletSpawnerRef.SetActive(false);
                    bulletSlotRef.SetActive(false);
                }
                if (torpedoSpawnerRef.activeSelf == true)
                {
                    torpedoSpawnerRef.SetActive(false);
                    torpedoSlotRef.SetActive(false);
                }
                if (laserSpawnerRef.activeSelf == true)
                {
                    laserSpawnerRef.SetActive(false);
                    laserSlotRef.SetActive(false);
                }
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4) && laserUnlocked == true)
            {

                if (spaceShip2DRef.GetComponent<SpriteRenderer>().sprite != powerUpShip)
                    spaceShip2DRef.GetComponent<SpriteRenderer>().sprite = powerUpShip;

                if (laserSpawnerRef.activeSelf == false)
                {
                    spaceShip2DRef.GetComponent<PlayerMovements_V2>().reload = true;
                    laserSpawnerRef.SetActive(true);
                    laserSlotRef.SetActive(true);
                }
                if (bulletSpawnerRef.activeSelf == true)
                {
                    bulletSpawnerRef.SetActive(false);
                    bulletSlotRef.SetActive(false);
                }
                if (torpedoSpawnerRef.activeSelf == true)
                {
                    torpedoSpawnerRef.SetActive(false);
                    torpedoSlotRef.SetActive(false);
                }
                if (shotgunSpawnerRef.activeSelf == true)
                {
                    shotgunSpawnerRef.SetActive(false);
                    shotgunSlotRef.SetActive(false);
                }
            }
        }
        else
        {
            if (spaceShip2DRef.GetComponent<SpriteRenderer>().sprite != standardShip)
                spaceShip2DRef.GetComponent<SpriteRenderer>().sprite = standardShip;

            if (bulletSpawnerRef.activeSelf == false)
            {
                spaceShip2DRef.GetComponent<PlayerMovements_V2>().reload = true;
                bulletSpawnerRef.SetActive(true);
                bulletSlotRef.SetActive(true);
            }
            if (torpedoSpawnerRef.activeSelf == true)
            {
                torpedoSpawnerRef.SetActive(false);
                torpedoSlotRef.SetActive(false);
            }
            if (shotgunSpawnerRef.activeSelf == true)
            {
                shotgunSpawnerRef.SetActive(false);
                shotgunSlotRef.SetActive(false);
            }
            if (laserSpawnerRef.activeSelf == true)
            {
                laserSpawnerRef.SetActive(false);
                laserSlotRef.SetActive(false);
            }
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
        yield return new WaitForSeconds(10f);
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

    IEnumerator PlayerDeath()
    {
        fadeInDeath.SetActive(true);
        yield return new WaitForSeconds(0.9f);
        if (addCurrency == true && radiumCurrency < 1000000000)
        {
            Game_Manager.radiumCurrency += Game_Manager.score * Game_Manager.greenMinerals;
            addCurrency = false;
        }
        SceneManager.LoadScene("Score_Menu", LoadSceneMode.Single);
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

    IEnumerator EndGlitchEffect()
    {
        yield return new WaitForSeconds(0.5f);
        if (glitchEffectRef.activeSelf == true)
            glitchEffectRef.SetActive(false);
    }
}
