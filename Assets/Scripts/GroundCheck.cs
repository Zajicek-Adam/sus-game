﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField]
    private PlayerController2D playerController;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("A");
        if (col.gameObject.CompareTag("Ground") || col.gameObject.CompareTag("Wall") || col.gameObject.CompareTag("Player"))
        {
            playerController.isGrounded = true;
            playerController.myRigidbody.gravityScale = playerController.originalGravity;
            playerController.jumpsLeft = playerController.maxJumps;
        }
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag != "Bullet" && col.gameObject.tag != "Wall")
        {
            playerController.isGrounded = false;
        }
    }
}
