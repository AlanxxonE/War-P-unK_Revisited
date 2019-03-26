using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorpedoSpawner : MonoBehaviour
{
    public GameObject bulletReference;
    public Transform bulletPosition;
    public PlayerMovements_V2 playerReference;

    public void SpawnTorpedo()
    {
        StartCoroutine("CreateBullet");
    }

    IEnumerator CreateBullet()
    {
        playerReference.reload = false;

        GameObject bulletTemp = Instantiate(bulletReference);
        bulletTemp.SetActive(true);
        bulletTemp.transform.position = bulletPosition.position;
        bulletTemp.transform.localRotation = Quaternion.Euler(0, 0, 5);

        GameObject bulletTemp2 = Instantiate(bulletReference);
        bulletTemp2.SetActive(true);
        bulletTemp2.GetComponent<Bullet_Torpedo>().slope *= -1;
        bulletTemp2.transform.position = bulletPosition.position;
        bulletTemp2.transform.localRotation = Quaternion.Euler(0, 0, -5);

        yield return new WaitForSeconds(0.1f);

        playerReference.reload = true;
    }
}
