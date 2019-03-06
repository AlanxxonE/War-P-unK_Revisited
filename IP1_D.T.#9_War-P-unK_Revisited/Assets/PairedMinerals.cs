using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PairedMinerals : MonoBehaviour
{
    public float mineralSize;
    public float mineralSpeed;
    public float offSetX;
    public float offSetY;

    //public Animator animatorReference;
    public GameObject asteroidTarget1;
    public GameObject asteroidTarget2;
    public GameObject mineralTarget1Reference;
    public GameObject mineralTarget2Reference;

    // Use this for initialization
    void Start()
    {
        //mineralSize = Random.Range(0.5f, 2.0f);
        mineralSpeed = Random.Range(-0.05f, -0.15f);
        offSetX = Random.Range(-0.3f, 0.3f);
        offSetY = Random.Range(-0.2f, 0.5f);

        transform.localScale = new Vector3(mineralSize, mineralSize, mineralSize);

        mineralTarget1Reference.transform.position = asteroidTarget1.transform.position;
        mineralTarget2Reference.transform.position = asteroidTarget2.transform.position;

        mineralTarget1Reference.transform.Translate(0, offSetY, 0);
        mineralTarget2Reference.transform.Translate(offSetX, offSetY, 0);
    }

    // Update is called once per frame
    void Update()
    {
        mineralTarget1Reference.transform.position += new Vector3(mineralSpeed, 0);
        mineralTarget2Reference.transform.Translate(0, 0, mineralSpeed);
    }
}