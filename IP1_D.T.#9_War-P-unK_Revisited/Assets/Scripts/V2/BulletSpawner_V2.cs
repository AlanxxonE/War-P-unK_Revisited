using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner_V2 : MonoBehaviour
{
    public GameObject bulletReference;
    public Transform bulletPosition;
    public PlayerMovements_V2 playerReference;

    public void SpawnBulletV2()
    {
        StartCoroutine("CreateBullet");
    }

    IEnumerator CreateBullet()
    {
        playerReference.reload = false;

        GameObject bulletTemp = Instantiate(bulletReference);
        bulletTemp.SetActive(true);
        bulletTemp.transform.position = bulletPosition.position;

        yield return new WaitForSeconds(0.15f);

        playerReference.reload = true;
    }
}
