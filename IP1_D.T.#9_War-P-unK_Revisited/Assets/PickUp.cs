using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PickUp : MonoBehaviour
{
    public bool playerHit = false;

    public Minerals mineralReference;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (mineralReference.pickUpProbability < 0.5f)
            {
                playerHit = true;
                Destroy(gameObject);
            }

            if (mineralReference.pickUpProbability > 0.5f)
            {
                print("FMINERKLs");
                SceneManager.LoadScene("Main_Menu", LoadSceneMode.Single);
            }
        }
    }
}
