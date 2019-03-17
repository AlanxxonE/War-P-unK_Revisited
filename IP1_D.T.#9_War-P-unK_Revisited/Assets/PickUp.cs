using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PickUp : MonoBehaviour
{
    public bool playerHit = false;

    public Minerals mineralReference;
    public Game_Manager gMRef;
    public HBSpawner hitBoxRef;
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
                    Game_Manager.greenMinerals += 1;
                    Game_Manager.score += 20;
                }
                hitBoxRef.HitMarkerPopUp(gameObject.transform);

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
