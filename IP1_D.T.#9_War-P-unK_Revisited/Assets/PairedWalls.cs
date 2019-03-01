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

    // Use this for initialization
    void Start ()
    {
        wallSpeed = Random.Range(-0.2f, -0.4f);

        wall2DRef.transform.position = target1.transform.position;
        wall3DRef.transform.position = target2.transform.position;
        wall3DRef.transform.position += new Vector3(-7f, 0f);
    }

    // Update is called once per frame
    void Update ()
    {
            wall2DRef.transform.position += new Vector3(wallSpeed, 0);
            wall3DRef.transform.Translate(0, 0, wallSpeed);
    }
}
