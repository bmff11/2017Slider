﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public int health = 100;
    public float speed = 5;
    public float jumpSpeed = 5;
    public float deadZone = -3;
    public bool canFly = false;
    private Animator anim;
    private SpriteRenderer sr;

    new Rigidbody2D rigidbody;
    GM _GM;
    private Vector3 startingPosition;

    //Use this for initialization
    void Start() {
        startingPosition = transform.position;
        rigidbody = GetComponent<Rigidbody2D>();
        _GM = FindObjectOfType<GM>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        }

    // Update is called once per frame
        void FixedUpdate() {

            float x = Input.GetAxisRaw("Horizontal");
            Vector2 v = rigidbody.velocity;
            v.x = x * speed;

            if (Input.GetButtonDown("Jump") && (v.y ==0 || canFly) ) {
            v.y = jumpSpeed;
            }

            if (v.x > 0)
            sr.flipX = false;
            else if (v.x < 0)
            sr.flipX = true;
            rigidbody.velocity = v;

        //Check for out
            if (transform.position.y < deadZone) {
                Debug.Log("Current Position " + transform.position.y + "is lower than " + deadZone);
                GetOut();
            }

        //rigidbody.AddForce(new Vector2(x * speed, 0))
        }

    public void GetOut() {
        _GM.SetLives( _GM.GetLives() - 1 );
        transform.position = startingPosition;
        Debug.Log("You're Out");

    }

    public void powerup()
    {
        anim.SetTrigger("Powered");
    }


}
