﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureMovement_V1 : MonoBehaviour
{

    public float moveTextureSpeedX;
    public float moveTextureSpeedY;
    float moveX;
    float moveY;

    void Update()
    {
        moveX = (moveTextureSpeedX * Time.deltaTime) + moveX;
        moveY = (moveTextureSpeedY * Time.deltaTime) + moveY;
        if (moveX > 1) moveX = 0;
        if (moveY > 1) moveY = 0;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(moveX, moveY);
    }
}
