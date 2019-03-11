using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PairPurpleMineral : MonoBehaviour
{
    public float purpleMineralSpeed;
    public GameObject target1;
    public GameObject target2;
    public GameObject purpleMineralRef;
    public GameObject purpleLightRef;
    public Pause_State pauseRef;

    // Use this for initialization
    void Start ()
    {
        StartCoroutine("AutoDeath");
        purpleMineralSpeed = Random.Range(-0.05f, -0.1f);

        purpleMineralRef.transform.position = target1.transform.position + new Vector3(0, +1, 0);
        purpleLightRef.transform.position = target2.transform.position;
    }

    // Update is called once per frame
    void Update ()
    {
        if (pauseRef.checkPause == false)
        {
            purpleMineralRef.transform.position += new Vector3(purpleMineralSpeed, 0);
            purpleLightRef.transform.Translate(0, 0, purpleMineralSpeed);
        }
    }
   
    IEnumerator AutoDeath()
    {
        yield return new WaitForSeconds(20f);
        Destroy(gameObject);
    }
}
