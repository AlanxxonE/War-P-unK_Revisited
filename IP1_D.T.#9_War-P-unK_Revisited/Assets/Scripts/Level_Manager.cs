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

    public Button unlockTorpedoRef;
    public Button unlockShotgunRef;
    public Image TPRef;
    public Image SGRef;

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

        if(unlockTorpedoRef != null && Game_Manager.radiumCurrency < 100)
        {
            unlockTorpedoRef.GetComponent<Image>().color = Color.grey;
        }
    }

    public void unlockTorpedo()
    {

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
}
