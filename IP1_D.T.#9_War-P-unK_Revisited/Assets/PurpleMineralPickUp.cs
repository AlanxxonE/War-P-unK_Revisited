using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleMineralPickUp : MonoBehaviour
{

    public Game_Manager gMRef;

    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (gameObject != null)
            {
                Game_Manager.purpleMinerals += 1;
                Game_Manager.score += 200;
                Destroy(gameObject);
            }
        }
    }
}