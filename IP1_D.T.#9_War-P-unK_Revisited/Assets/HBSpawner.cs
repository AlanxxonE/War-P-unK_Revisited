using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HBSpawner : MonoBehaviour
{
    public GameObject HitMarkerRef;

    public void HitMarkerPopUp(Transform ObjPos)
    {
        GameObject HMTemp = Instantiate(HitMarkerRef);
        HMTemp.transform.position = ObjPos.position;
        HMTemp.SetActive(true);
    }
}
