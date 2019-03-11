using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimensionalMineral : MonoBehaviour
{
    public GameObject purpleMineralReference;
    public GameObject blueMineralReference;
    public Game_Manager gMRef;
    int tempScore = 1000;
    int iCounter = 1;
    bool spawnBlue = true;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Game_Manager.score >= tempScore * iCounter)
        {
            GameObject purpleTemp = Instantiate(purpleMineralReference);
            purpleTemp.SetActive(true);
            iCounter += 1;

            spawnBlue = !spawnBlue;
        }
        else if(Game_Manager.score >= ((tempScore * iCounter) - (tempScore / 2)) && spawnBlue == true)
        {
            GameObject blueTemp = Instantiate(blueMineralReference);
            blueTemp.SetActive(true);

            spawnBlue = !spawnBlue;
        }
    }
}
