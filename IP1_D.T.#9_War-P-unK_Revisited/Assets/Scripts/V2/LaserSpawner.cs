using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSpawner : MonoBehaviour
{
    public GameObject bulletReference;
    public Transform bulletPosition;
    public PlayerMovements_V2 playerReference;
    public GameObject bulletTempCover;

    public void SpawnLaser()
    {
        StartCoroutine("CreateBullet");
    }

    public void Update()
    {

        if (bulletTempCover != null && bulletTempCover.transform.localScale.x <= 24)
            bulletTempCover.transform.localScale += new Vector3(1f, 0, 0);

    }

    IEnumerator CreateBullet()
    {
        playerReference.reload = false;

        if(PlayerMovements_V2.laserBeamSprite == true)
        {
            bulletTempCover = Instantiate(bulletReference);
            bulletTempCover.SetActive(true);
            bulletTempCover.transform.position = bulletPosition.position;
            bulletTempCover.transform.parent = playerReference.gameObject.transform;
            bulletTempCover.GetComponent<Laser_Beam>().confirmDestroy = false;
            PlayerMovements_V2.laserBeamSprite = false;
        }

        GameObject bulletTemp = Instantiate(bulletReference);
        bulletTemp.SetActive(true);
        bulletTemp.transform.position = bulletPosition.position;
        bulletTemp.transform.parent = playerReference.gameObject.transform;

        yield return new WaitForSeconds(0.1f);

        playerReference.reload = true;
    }
}
