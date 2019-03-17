using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PairedWalls : MonoBehaviour
{
    public float wallSpeed;
    public GameObject target1;
    public GameObject target2;
    public GameObject wall2DRef;
    public GameObject wall3DRef;
    public Pause_State pauseRef;

    // Use this for initialization
    void Start ()
    {
        StartCoroutine("AutoDeath");
        wallSpeed = Random.Range(-0.1f, -0.2f);

        wall2DRef.transform.position = target1.transform.position;
        wall3DRef.transform.position = target2.transform.position;
        wall3DRef.transform.position += new Vector3(-7f, 0f);
    }

    // Update is called once per frame
    void Update ()
    {
        if (pauseRef.checkPause == false)
        {
            if (wall2DRef != null)
                wall2DRef.transform.position += new Vector3(wallSpeed, 0);
            else
                Destroy(wall2DRef);
            if (wall3DRef != null)
                wall3DRef.transform.Translate(0, 0, wallSpeed);
            else
                Destroy(wall3DRef);
        }
    }

    IEnumerator AutoDeath()
    {
        yield return new WaitForSeconds(20f);
        Destroy(gameObject);
    }
}
