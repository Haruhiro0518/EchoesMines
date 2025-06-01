using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AroundCameraScript : MonoBehaviour
{
    private Vector3 StartPosition;
    private Quaternion StartRotation;
    private Vector3 BeforePosition;
    private Quaternion BeforeRotation;

    private GameObject targetObject;
    [SerializeField] private float UpDown = 0.1f;
    [SerializeField] private float FlontBack = 0.01f;
    [SerializeField] private float RightLeft = 0.01f;
    private Camera mainCamera;

    //flags
    [SerializeField] private bool CameraLock = false; //Camera lookat flag
    [SerializeField] private bool CameraMove = false; //Camera move flag

    private int SetCameraPosition = 0;

    // Start is called before the first frame update
    void Start()
    {
        //save reset position
        StartPosition = transform.position;
        StartRotation = transform.rotation;

        mainCamera = Camera.main;
        targetObject = GameObject.Find("Cassle");
    }

    // Update is called once per frame
    void Update()
    {
        BeforePosition = transform.position;
        BeforeRotation = transform.rotation;
        //change flags
        if(Input.GetKeyDown("m"))
        {
            if (CameraMove)
            {
                Debug.Log("Camera can't move");
                CameraMove = false;
            }
            else
            {
                Debug.Log("Camera can move");
                CameraMove = true;
            }
        }

        if(Input.GetKeyDown("l"))
        {
            if(CameraLock)
            {
                Debug.Log("Camera look at cassle");
                CameraLock = false;
            }
            else
            {
                Debug.Log("Camera unlook at cassle");
                CameraLock = true;
            }
        }

        //camera move
        if(CameraMove)
        {
            //camera UpDown
            var scroll = Input.mouseScrollDelta.y;
            transform.Translate(new Vector3(0, scroll * UpDown, 0));

            if (Input.GetKey("a"))
            {
                transform.Translate(new Vector3(-RightLeft, 0));
            }
            else if (Input.GetKey("d"))
            {
                transform.Translate(new Vector3(RightLeft, 0));
            }
            else if (Input.GetKey("w"))
            {
                transform.Translate(new Vector3(0, 0, FlontBack));
            }
            else if (Input.GetKey("s"))
            {
                transform.Translate(new Vector3(0, 0, -FlontBack));
            }

            if(Input.GetMouseButton(0))
            {
                transform.Rotate(new Vector3(0, -UpDown));
            }else if (Input.GetMouseButton(1))
            {
                transform.Rotate(new Vector3(0, UpDown));
            }

            if (CameraLock)
            {
                transform.LookAt(targetObject.transform.position);
            }
        }else
        {
            if (Input.GetKeyDown("n"))
            {
                if(SetCameraPosition < 1)
                {
                    SetCameraPosition++;
                }
                else
                {
                    SetCameraPosition = 0;
                }
                Debug.Log("Camera set at point" + SetCameraPosition);
            }

            switch (SetCameraPosition)
            {
                case 0:
                    transform.position = StartPosition;
                    transform.rotation = StartRotation;
                    break;
                case 1:
                    if (Input.GetKey("w"))
                    {
                        transform.Translate(new Vector3(0, 0, FlontBack));
                    }
                    else if (Input.GetKey("s"))
                    {
                        transform.Translate(new Vector3(0, 0, -FlontBack));
                    }
                    transform.Translate(new Vector3(RightLeft, 0));
                    transform.LookAt(targetObject.transform.position);
                    break;
            }
        }
        Vector3 callentPosition = transform.position;
        if(transform.position.x < 0 || 149.6094 < transform.position.x)
        {
            callentPosition.x = BeforePosition.x;
        }
        if(transform.position.y < 1.34 || 10 < transform.position.y)
        {
            callentPosition.y = BeforePosition.y;
        }
        if(transform.position.z < 0 || 137.1094 < transform.position.z)
        {
            callentPosition.z = BeforePosition.z;
        }
        transform.position = callentPosition;
    }

}
