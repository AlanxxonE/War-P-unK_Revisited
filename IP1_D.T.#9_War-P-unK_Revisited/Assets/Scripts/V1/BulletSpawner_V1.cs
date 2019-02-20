using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner_V1 : MonoBehaviour
{
    public GameObject bulletReference;
    public Transform spaceShipPosition;

    public void SpawnBullet()
    {
        GameObject bulletTemp = Instantiate(bulletReference);
        bulletTemp.SetActive(true);
        bulletTemp.transform.position = spaceShipPosition.position;
    }
}
