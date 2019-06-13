﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderActiveScript : MonoBehaviour
{
    BoxCollider2D bx;
    SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        bx = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (ButtonScript.active == true)
        {
            sr.enabled = false;
            bx.enabled=false;
        }
    }
}
