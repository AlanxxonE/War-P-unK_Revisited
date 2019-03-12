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

	void Start ()
    {
        if (startPrototypeV1 != null)
            startPrototypeV1.onClick.AddListener(LoadV1);

        if (startPrototypeV2 != null)
            startPrototypeV2.onClick.AddListener(LoadV2);
        if (exitPrototype != null)
            exitPrototype.onClick.AddListener(ExitApp);

        if (controlPanel != null)
            controlPanel.onClick.AddListener(Controls);

        if (backMenu != null)
            backMenu.onClick.AddListener(ShowMenu);
	}

	void Update ()
    {
		//if(Input.GetKeyDown(KeyCode.Escape))
  //      {
  //          SceneManager.LoadScene("Main_Menu",LoadSceneMode.Single);
  //      }
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
}
