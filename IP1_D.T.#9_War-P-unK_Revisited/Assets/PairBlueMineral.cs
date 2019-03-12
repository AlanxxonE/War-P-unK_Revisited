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
        if(gameObject !=null)
        StartCoroutine("AutoDeath");

        blueMineralSpeed = Random.Range(-0.05f, -0.1f);

        blueLightRef.transform.position = target1.transform.position;
        blueMineralRef.transform.position = target2.transform.position - new Vector3(0, 3, 0);
    }

    // Update is called once per frame
    void Update ()
    {
        if (pauseRef.checkPause == false)
        {
            if (blueMineralRef != null)
            {
                blueLightRef.transform.position += new Vector3(blueMineralSpeed, 0);
                blueMineralRef.transform.Translate(0, 0, blueMineralSpeed);
            }
        }
    }

    IEnumerator AutoDeath()
    {
        yield return new WaitForSeconds(20f);
        Destroy(gameObject);
    }
}
