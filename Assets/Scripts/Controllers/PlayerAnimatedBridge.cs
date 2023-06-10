using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatedBridge : MonoBehaviour
{
    private CharacterController controller;
    private Animator animator;

    public float speed;
    public float gravit;
    public float rotSpeed;

    private float rot;
    private Vector3 moveDirection;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if(controller.isGrounded)
        {
            if(Input.GetKey(KeyCode.W))
            {
                moveDirection = Vector3.forward * speed;
                animator.SetInteger("transiton", 1);
            }
            if(Input.GetKeyUp(KeyCode.W))
            {
                moveDirection = Vector3.zero;
                animator.SetInteger("transiton", 0);
            }
        }

        rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0,rot, 0);

        moveDirection.y -= gravit * Time.deltaTime;
        moveDirection = transform.TransformDirection(moveDirection);

        controller.Move(moveDirection * Time.deltaTime);
    }
}
