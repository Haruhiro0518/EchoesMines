using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermove1 : MonoBehaviour
{
    public float speed;
    public float gravity;

    public float JumpPower;

    private Vector3 moveDirection = Vector3.zero;

    CharacterController controller;

    float y;
    float x;
    float z;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        if (controller.isGrounded)
        {
            moveDirection.z = z * speed;
            moveDirection.x = x * speed;
            moveDirection = transform.TransformDirection(moveDirection);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                y = JumpPower;
                moveDirection.y = y;
            }
        }

        if(!controller.isGrounded)
        {
            moveDirection.z = z * speed * 2 / 3;
            moveDirection.x = x * speed * 2 / 3;
            moveDirection = transform.TransformDirection(moveDirection);
        }

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
}
