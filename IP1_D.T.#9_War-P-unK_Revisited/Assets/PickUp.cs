using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PickUp : MonoBehaviour
{
    public bool playerHit = false;

    public Minerals mineralReference;
    public Game_Manager gMRef;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (mineralReference.pickUpProbability < 0.75f)
            {
                playerHit = true;
                if(mineralReference.fuelProbability > 0.5f)
                {
                    if (gMRef.fuel < 100)
                    {
                        gMRef.fuel += 10;
                    }
                }
                else
                {
                    gMRef.greenMinerals += 1;
                    gMRef.score += 20;
                }
                Destroy(gameObject);
                Destroy(mineralReference.mineralTarget2);
            }

            if (mineralReference.pickUpProbability > 0.75f)
            {
                print("FMINERKLs");
                //SceneManager.LoadScene("Main_Menu", LoadSceneMode.Single);
                //gMRef.hitPoints -= 1;
            }
        }
    }
}
