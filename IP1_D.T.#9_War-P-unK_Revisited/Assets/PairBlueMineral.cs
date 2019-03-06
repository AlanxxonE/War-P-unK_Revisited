using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PairBlueMineral : MonoBehaviour
{
    public float blueMineralSpeed;
    public GameObject target1;
    public GameObject target2;
    public GameObject blueLightRef;
    public GameObject blueMineralRef;
    public Pause_State pauseRef;

    // Use this for initialization
    void Start ()
    {
        StartCoroutine("AutoDeath");
        blueMineralSpeed = Random.Range(-0.01f, -0.1f);

        blueLightRef.transform.position = target1.transform.position;
        blueMineralRef.transform.position = target2.transform.position;
    }

    // Update is called once per frame
    void Update ()
    {
        if (pauseRef.checkPause == false)
        {
            blueLightRef.transform.position += new Vector3(blueMineralSpeed, 0);
            blueMineralRef.transform.Translate(0, 0, blueMineralSpeed);
        }
    }

    IEnumerator AutoDeath()
    {
        yield return new WaitForSeconds(20f);
        Destroy(gameObject);
    }
}
