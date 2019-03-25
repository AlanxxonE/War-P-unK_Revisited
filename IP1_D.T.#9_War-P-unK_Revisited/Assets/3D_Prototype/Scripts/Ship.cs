using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ship : MonoBehaviour
{
    public KeyCode moveLeftKey = KeyCode.LeftArrow;
    public KeyCode moveRightKey = KeyCode.RightArrow;
    public KeyCode moveUpKey = KeyCode.UpArrow;
    public KeyCode moveDownKey = KeyCode.DownArrow;
    public KeyCode SpaceKey = KeyCode.Space;

    //bool canMoveLeft = true;
    //bool canMoveUp = true;
    //bool canMoveRight = true;
    //bool canMoveDown = true;

    public bool checkActive3D = false;

    public float speed = 0.2f;
    public float bulletDelay = 0.1f;

    public GameObject Bullet;
    public Game_Manager gMRef;
    public CameraShake cameraRef;
    public CameraSwitcher cameraSwitcherReference;
    public GameObject explosionRef;

    public GameObject screenWipeRef;
    public GameObject screenWipe3DRef;
    private void Start()
    {
        InvokeRepeating("FireBullet", 0, bulletDelay);
    }

    private void FixedUpdate()
    {
        bool isLeftPressed = Input.GetKey(moveLeftKey);
        bool isRightPressed = Input.GetKey(moveRightKey);
        bool isUpPressed = Input.GetKey(moveUpKey);
        bool isDownPressed = Input.GetKey(moveDownKey);

        
        if ((isRightPressed && checkActive3D == true) && !Input.GetKey(KeyCode.W))
        {
            if (gameObject.transform.position.x < 7.0f)
                transform.Translate(speed, 0.0f, 0.0f);
        }
        else if ((isLeftPressed && checkActive3D == true) && !Input.GetKey(KeyCode.W))
        {
            if (gameObject.transform.position.x > -7.0f) 
            transform.Translate(-speed, 0.0f, 0.0f);
        }
        if (isUpPressed)
        {
            if(gameObject.transform.position.y < - 48f)
            transform.Translate(0.0f, speed, 0.0f);
        }
        else if (isDownPressed)
        {
            if(gameObject.transform.position.y > -54f)
            transform.Translate(0.0f, -speed, 0.0f);
        }
        
    }

    private void Update()
    {
        //if (gMRef.checkWarpDelay == false)
        //{
        //    if (Input.GetKeyDown(KeyCode.W) || checkActive3D == false)
        //    {
        //        checkActive3D = !checkActive3D;
        //        gameObject.GetComponent<BoxCollider>().enabled = !gameObject.GetComponent<BoxCollider>().enabled;
        //    }
        //}
    }

    //private void OnCollisionEnter(Collision other)
    //{
    //    switch (other.gameObject.name)
    //    {
    //        case "Right Wall":
    //            canMoveRight = false;
    //            break;
    //        case "Left Wall":
    //            canMoveLeft = false;
    //            break;
    //        case "Top Wall":
    //            canMoveUp = false;
    //            break;
    //        case "Bottom Wall":
    //            canMoveDown = false;
    //            break;
    //    }
    //}

    //private void OnCollisionExit(Collision other)
    //{
    //    switch (other.gameObject.name)
    //    {
    //        case "Right Wall":
    //            canMoveRight = true;
    //            break;
    //        case "Left Wall":
    //            canMoveLeft = true;
    //            break;
    //        case "Top Wall":
    //            canMoveUp = true;
    //            break;
    //        case "Bottom Wall":
    //            canMoveDown = true;
    //            break;
    //    }
    //}

    void FireBullet()
    {
        bool isSpacePressed = Input.GetKey(SpaceKey);

        if (isSpacePressed && cameraSwitcherReference.CameraControl == 0)
        {
            GameObject bulletClone = Instantiate(Bullet);
            bulletClone.transform.position = transform.position;
            bulletClone.gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Asteroid" && checkActive3D == true)
        {
            screenWipeRef.SetActive(true);
            screenWipe3DRef.SetActive(true);
            StartCoroutine("ExplosionAnim");
            cameraRef.shakeAmount = 0.6f;
            cameraRef.shakeDuration = 0;
            cameraRef.shakeDuration = 1;
            gMRef.hitPoints -= 1;
            gMRef.StartCoroutine("HitPointAnim");
            //SceneManager.LoadScene("Main_Menu", LoadSceneMode.Single);
            print("dieddied");
            Destroy(other.transform.parent.gameObject);
        }
    }

    IEnumerator ExplosionAnim()
    {
        explosionRef.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        explosionRef.SetActive(false);
    }
}
