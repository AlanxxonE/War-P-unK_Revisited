using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircuitSpawner : MonoBehaviour
{
    public GameObject circuitRef;

    public void CircuitPopUp(Transform ObjPos)
    {
        GameObject CircuitTemp = Instantiate(circuitRef);
        CircuitTemp.transform.position = ObjPos.position + new Vector3(1f, 0, -0.2f);
        CircuitTemp.SetActive(true);
    }
}
