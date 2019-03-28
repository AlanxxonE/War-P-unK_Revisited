using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneTimer : MonoBehaviour
{
    public Pause_State pauseRef;
	// Use this for initialization
	void Start ()
    {
        StartCoroutine("StartCutScene");
    }

    private void Update()
    {
    }

    IEnumerator StartCutScene()
    {
        pauseRef.cutSceneCheck = true;
        yield return new WaitForSeconds(9f);
        Destroy(gameObject);
    }
}
