using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level_Manager : MonoBehaviour
{

    public Button startPrototypeV1;
    public Button startPrototypeV2;
    public Button exitPrototype;
    public Button controlPanel;
    public Button backMenu;
    public Button marketPlace;
    public GameObject currencyTextRef;

    public GameObject startImageRef;
    static bool canStart = false;

    bool boughtTorpedo = false;
    bool boughtShotgun = false;
    bool boughtLaser = false;
    public Button unlockTorpedoRef;
    public Button unlockShotgunRef;
    public Button unlockLaserRef;
    public Image TPRef;
    public Image SGRef;
    public Image LBRef;
    public GameObject torpedoPrice;
    public GameObject shotgunPrice;
    public GameObject LaserPrice;

    void Start ()
    {
        if (startPrototypeV1 != null)
            startPrototypeV1.onClick.AddListener(LoadV1);

        if (startPrototypeV2 != null && canStart)
            startPrototypeV2.onClick.AddListener(LoadCutScene);
        if (exitPrototype != null)
            exitPrototype.onClick.AddListener(ExitApp);

        if (controlPanel != null)
            controlPanel.onClick.AddListener(Controls);

        if (backMenu != null)
            backMenu.onClick.AddListener(ShowMenu);

        if (marketPlace != null)
            marketPlace.onClick.AddListener(loadShop);

        if(currencyTextRef != null)
        currencyTextRef.GetComponent<Text>().text = "RADIUM: " + Game_Manager.radiumCurrency.ToString() + " ¬";

        if (Game_Manager.torpedoUnlocked == true)
        {
            Destroy(torpedoPrice);
        }
        if (Game_Manager.shotgunUnlocked == true)
        {
            Destroy(shotgunPrice);
        }
        if (Game_Manager.laserUnlocked == true)
        {
            Destroy(LaserPrice);
        }
    }

	void Update ()
    {
		//if(Input.GetKeyDown(KeyCode.Escape))
  //      {
  //          SceneManager.LoadScene("Main_Menu",LoadSceneMode.Single);
  //      }

        if(SceneManager.GetActiveScene().name == "CutScene1" && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Prototype_V2", LoadSceneMode.Single);
        }

        if(SceneManager.GetActiveScene().name == "Controls_Panel")
        {
            canStart = true;
        }

        if(startImageRef != null && canStart == false)
        {
            startImageRef.GetComponent<Image>().color = Color.grey;
        }

        if(unlockTorpedoRef != null && Game_Manager.radiumCurrency < 10000)
        {
            unlockTorpedoRef.GetComponent<Image>().color = Color.grey;
        }

        if(unlockShotgunRef != null && Game_Manager.radiumCurrency < 20000)
        {
            unlockShotgunRef.GetComponent<Image>().color = Color.grey;
        }

        if (unlockLaserRef != null && Game_Manager.radiumCurrency < 50000)
        {
            unlockLaserRef.GetComponent<Image>().color = Color.grey;
        }

        if (TPRef != null && Game_Manager.torpedoUnlocked == false)
        {
            TPRef.color = Color.grey;
        }
        if(SGRef != null && Game_Manager.shotgunUnlocked == false)
        {
            SGRef.color = Color.grey;
        }
        if (LBRef != null && Game_Manager.laserUnlocked == false)
        {
            SGRef.color = Color.grey;
        }

        if (Game_Manager.radiumCurrency >= 10000 && Game_Manager.torpedoUnlocked == false && unlockTorpedoRef != null)
        {
            unlockTorpedoRef.onClick.AddListener(unlockTorpedo);
        }
        else if(Game_Manager.radiumCurrency < 10000 && Game_Manager.torpedoUnlocked == false && unlockTorpedoRef != null)
        {
            unlockTorpedoRef.onClick.RemoveAllListeners();
        }

        if (Game_Manager.radiumCurrency >= 20000 && Game_Manager.shotgunUnlocked == false && unlockShotgunRef != null)
        {
            unlockShotgunRef.onClick.AddListener(unlockShotgun);
        }
        else if (Game_Manager.radiumCurrency < 20000 && Game_Manager.shotgunUnlocked == false && unlockShotgunRef != null)
        {
            unlockShotgunRef.onClick.RemoveAllListeners();
        }

        if (Game_Manager.radiumCurrency >= 50000 && Game_Manager.laserUnlocked == false && unlockLaserRef != null)
        {
            unlockLaserRef.onClick.AddListener(unlockLaser);
        }
        else if (Game_Manager.radiumCurrency < 50000 && Game_Manager.laserUnlocked == false && unlockLaserRef != null)
        {
            unlockLaserRef.onClick.RemoveAllListeners();
        }

        if (Game_Manager.torpedoUnlocked == true && unlockTorpedoRef != null)
        {
            StartCoroutine("TorpedoPriceFade");
            unlockTorpedoRef.onClick.RemoveAllListeners();
            unlockTorpedoRef.GetComponentInChildren<Text>().text = "UNLOCKED";
            unlockTorpedoRef.GetComponent<Image>().color = Color.yellow;
        }
        if (Game_Manager.shotgunUnlocked == true && unlockShotgunRef != null)
        {
            StartCoroutine("ShotgunPriceFade");
            unlockShotgunRef.onClick.RemoveAllListeners();
            unlockShotgunRef.GetComponentInChildren<Text>().text = "UNLOCKED";
            unlockShotgunRef.GetComponent<Image>().color = Color.yellow;
        }
        if (Game_Manager.laserUnlocked == true && unlockLaserRef != null)
        {
            StartCoroutine("LaserPriceFade");
            unlockLaserRef.onClick.RemoveAllListeners();
            unlockLaserRef.GetComponentInChildren<Text>().text = "UNLOCKED";
            unlockLaserRef.GetComponent<Image>().color = Color.yellow;
        }
    }

    public void unlockTorpedo()
    {
        if (boughtTorpedo == false)
        {
            Game_Manager.radiumCurrency -= 10000;
            boughtTorpedo = true;
        }

        if (currencyTextRef != null)
            currencyTextRef.GetComponent<Text>().text = "RADIUM: " + Game_Manager.radiumCurrency.ToString() + " ¬";
        unlockTorpedoRef.GetComponentInChildren<Text>().text = "UNLOCKED";
        unlockTorpedoRef.GetComponent<Image>().color = Color.yellow;
        TPRef.color = Color.white;

        Game_Manager.torpedoUnlocked = true;
    }

    public void unlockShotgun()
    {
        if (boughtShotgun == false)
        {
            Game_Manager.radiumCurrency -= 20000;
            boughtShotgun = true;
        }

        if (currencyTextRef != null)
            currencyTextRef.GetComponent<Text>().text = "RADIUM: " + Game_Manager.radiumCurrency.ToString() + " ¬";
        unlockShotgunRef.GetComponentInChildren<Text>().text = "UNLOCKED";
        unlockShotgunRef.GetComponent<Image>().color = Color.yellow;
        SGRef.color = Color.white;

        Game_Manager.shotgunUnlocked = true;
    }

    public void unlockLaser()
    {
        if (boughtLaser == false)
        {
            Game_Manager.radiumCurrency -= 50000;
            boughtLaser = true;
        }

        if (currencyTextRef != null)
            currencyTextRef.GetComponent<Text>().text = "RADIUM: " + Game_Manager.radiumCurrency.ToString() + " ¬";
        unlockLaserRef.GetComponentInChildren<Text>().text = "UNLOCKED";
        unlockLaserRef.GetComponent<Image>().color = Color.yellow;
        LBRef.color = Color.white;

        Game_Manager.laserUnlocked = true;
    }

    public void StartFromCutScene()
    {
        SceneManager.LoadScene("Prototype_V2", LoadSceneMode.Single);
    }

    void LoadCutScene()
    {
        SceneManager.LoadScene("CutScene1", LoadSceneMode.Single);
    }
    void ShowMenu()
    {
        SceneManager.LoadScene("Main_Menu", LoadSceneMode.Single);
    }
    void LoadV2()
    {
        SceneManager.LoadScene("Prototype_V2", LoadSceneMode.Single);
    }
    void LoadV1()
    {
        SceneManager.LoadScene("Prototype_V1", LoadSceneMode.Single);
    }
    void ExitApp()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
    void Controls()
    {
        SceneManager.LoadScene("Controls_Panel", LoadSceneMode.Single);
    }
    void loadShop()
    {
        SceneManager.LoadScene("Market_Place", LoadSceneMode.Single);
    }

    IEnumerator TorpedoPriceFade()
    {
        if (torpedoPrice != null)
            torpedoPrice.GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(1f);
        if (torpedoPrice != null)
            Destroy(torpedoPrice);
    }

    IEnumerator ShotgunPriceFade()
    {
        if (shotgunPrice != null)
            shotgunPrice.GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(1f);
        if (shotgunPrice != null)
            Destroy(shotgunPrice);

    }

    IEnumerator LaserPriceFade()
    {
        if (LaserPrice != null)
            LaserPrice.GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(1f);
        if (LaserPrice != null)
            Destroy(LaserPrice);
    }
}
