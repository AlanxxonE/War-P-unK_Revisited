using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision_V1 : MonoBehaviour 
{
    public Camera playerCamera;
    public GameObject uiFinishReference;

    void Start () {
		
	}
    void FixedUpdate()
    {
        Vector3 pos = playerCamera.WorldToViewportPoint(transform.position);
        pos.y = Mathf.Clamp01(pos.y);
        if(pos.y > 0.95f)
        transform.position = playerCamera.ViewportToWorldPoint(pos - new Vector3(0,0.05f,0));
        else if (pos.y < 0.15f)
        transform.position = playerCamera.ViewportToWorldPoint(pos + new Vector3(0,0.05f,0));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Goal")
        {
            uiFinishReference.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
