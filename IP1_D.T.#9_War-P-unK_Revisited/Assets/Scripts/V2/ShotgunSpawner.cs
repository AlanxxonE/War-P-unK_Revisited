using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunSpawner : MonoBehaviour
{
    public GameObject bulletReference;
    public Transform bulletPosition;
    public PlayerMovements_V2 playerReference;

    public void SpawnShotgun()
    {
        StartCoroutine("CreateBullet");
    }

    IEnumerator CreateBullet()
    {
        playerReference.reload = false;

        GameObject bulletTemp = Instantiate(bulletReference);
        bulletTemp.SetActive(true);
        bulletTemp.GetComponent<Bullet_Shotgun>().wideAngle *= -4;
        bulletTemp.GetComponent<Bullet_Shotgun>().slope *= 1;
        bulletTemp.transform.position = bulletPosition.position;

        GameObject bulletTemp2 = Instantiate(bulletReference);
        bulletTemp2.SetActive(true);
        bulletTemp2.GetComponent<Bullet_Shotgun>().wideAngle *= -2;
        bulletTemp2.GetComponent<Bullet_Shotgun>().slope *= 0.5f;
        bulletTemp2.transform.position = bulletPosition.position;

        GameObject bulletTempSpecial = Instantiate(bulletReference);
        bulletTempSpecial.SetActive(true);
        bulletTempSpecial.GetComponent<Bullet_Shotgun>().wideAngle *= 0;
        bulletTempSpecial.GetComponent<Bullet_Shotgun>().slope *= 0;
        bulletTempSpecial.transform.position = bulletPosition.position;
        GameObject bulletTempSpecial2 = Instantiate(bulletReference);
        bulletTempSpecial2.SetActive(true);
        bulletTempSpecial2.GetComponent<Bullet_Shotgun>().wideAngle *= 0;
        bulletTempSpecial2.GetComponent<Bullet_Shotgun>().slope *= 0;
        bulletTempSpecial2.transform.position = bulletPosition.position;

        GameObject bulletTemp3 = Instantiate(bulletReference);
        bulletTemp3.SetActive(true);
        bulletTemp3.GetComponent<Bullet_Shotgun>().wideAngle *= -2;
        bulletTemp3.GetComponent<Bullet_Shotgun>().slope *= -0.5f;
        bulletTemp3.transform.position = bulletPosition.position;

        GameObject bulletTemp4 = Instantiate(bulletReference);
        bulletTemp4.SetActive(true);
        bulletTemp4.GetComponent<Bullet_Shotgun>().wideAngle *= -4;
        bulletTemp4.GetComponent<Bullet_Shotgun>().slope *= -1;
        bulletTemp4.transform.position = bulletPosition.position;

        yield return new WaitForSeconds(1f);

        playerReference.reload = true;
    }
}
