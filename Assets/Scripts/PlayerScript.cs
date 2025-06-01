using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField, Header("移動速度")]
    public float speed;

    [SerializeField, Header("重加速度")]
    public float gravity;

    [SerializeField, Header("跳躍速度")]
    public float jumpPower;

    private Vector3 moveDirection = Vector3.zero;

    private CharacterController controller;

    private GameObject MainSystem;

    private MainSystemScript mainSystemScript;

    private GameObject MainCamera;

    private CameraScript cameraScript;

    private GameObject Button;

    private ButtonScript buttonScript;

    private bool isOnce;

    [SerializeField, Header("再配置")]
    public bool isReady;

    [SerializeField, Header("トランスフォーム")]
    public Transform playerTransform;

    [SerializeField, Header("座標情報")]
    public Vector3 playerPosition;

    private float x;

    private float y;

    private float z;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        MainSystem = GameObject.Find("MainSystem");
        mainSystemScript = MainSystem.GetComponent<MainSystemScript>();
        MainCamera = GameObject.Find("MainCamera");
        cameraScript = MainCamera.GetComponent<CameraScript>();
        Button = GameObject.Find("Button");
        buttonScript = Button.GetComponent<ButtonScript>();
        
        isOnce = true;
        isReady = false;
    }

    void Update()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        playerTransform = gameObject.transform;
        playerPosition = playerTransform.position;

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

        PositionUpdate();
        ResetPosition();
    }

    private void PositionUpdate()
    {
        if(mainSystemScript.isMove == true)
        {
            switch(cameraScript.stateVector)
            {
                case 0:
                {
                    if (controller.isGrounded == true)
                    {
                        moveDirection.z = z * speed;
                        moveDirection.x = x * speed;
                        moveDirection = transform.TransformDirection(moveDirection);
                    }

                    break;
                }
                case 1:
                {
                    if (controller.isGrounded == true)
                    {
                        moveDirection.z = -x * speed;
                        moveDirection.x = z * speed;
                        moveDirection = transform.TransformDirection(moveDirection);
                    }

                    break;
                }
                case 2:
                {
                    if (controller.isGrounded == true)
                    {
                        moveDirection.z = -z * speed;
                        moveDirection.x = -x * speed;
                        moveDirection = transform.TransformDirection(moveDirection);
                    }

                    break;
                }
                case 3:
                {
                    if (controller.isGrounded == true)
                    {
                        moveDirection.z = x * speed;
                        moveDirection.x = -z * speed;
                        moveDirection = transform.TransformDirection(moveDirection);
                    }

                    break;
                }
                case 4:
                {
                    if (controller.isGrounded == true)
                    {
                        moveDirection.z = z * speed - x * speed;
                        moveDirection.x = x * speed + z * speed;
                        moveDirection = transform.TransformDirection(moveDirection);
                    }

                    break;
                }
                case 5:
                {
                    if (controller.isGrounded == true)
                    {
                        moveDirection.z = -x * speed - z * speed;
                        moveDirection.x = z * speed - x * speed;
                        moveDirection = transform.TransformDirection(moveDirection);
                    }

                    break;
                }
                case 6:
                {
                    if (controller.isGrounded == true)
                    {
                        moveDirection.z = -z * speed + x * speed;
                        moveDirection.x = -x * speed - z * speed;
                        moveDirection = transform.TransformDirection(moveDirection);
                    }

                    break;
                }
                case 7:
                {
                    if (controller.isGrounded == true)
                    {
                        moveDirection.z = x * speed + z * speed;
                        moveDirection.x = -z * speed + x * speed;
                        moveDirection = transform.TransformDirection(moveDirection);
                    }

                    break;
                }
            }
        }
        else
        {
            moveDirection.z = 0.0f;
            moveDirection.x = 0.0f;
            moveDirection = transform.TransformDirection(moveDirection);
        }
    }

    private void ResetPosition()
    {
        if(buttonScript.isPushed)
        {
            if(isOnce == true)
            {
                /* Transform myTrans = gameObject.GetComponent<Transform>();
                Vector3 myPos = myTrans.position;
                myPos.x = 0.0f;
                myPos.y = 1.0f;
                myPos.z = -1.0f;
                myTrans.position = myPos; */
                isOnce = false;
                isReady = true;
            }
        }
    }
}
