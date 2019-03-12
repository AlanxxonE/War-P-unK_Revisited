using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Showcase : MonoBehaviour
{
    public GameObject go1;
    public GameObject go2;
    public GameObject go3;
    public GameObject go4;
    public GameObject go5;
    public GameObject go6;

    // Use this for initialization
    void Start ()
    {
        StartCoroutine("showGO1");
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    IEnumerator showGO1()
    {
        yield return new WaitForSeconds(0.5f);
        showMethod(go1);
    }

    void showMethod(GameObject placeHolder)
    {
        placeHolder.SetActive(true);
    }
}
