using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueMineralPickUp : MonoBehaviour
{

    public Game_Manager gMRef;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (gameObject != null)
            {
                Game_Manager.blueMinerals += 1;
                Game_Manager.score += 100;
                Destroy(gameObject);
            }
        }
    }
}