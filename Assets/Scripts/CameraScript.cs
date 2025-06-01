using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{   
    [SerializeField, Header("メインカメラ")]
    public Camera MainCamera;

    private GameObject MainSystem;

    private MainSystemScript mainSystemScript;

    private Vector3 lastMousePosition;

    private Vector3 newAngle = new Vector3(0, 0, 0);

    [SerializeField, Header("方向情報")]
    public int stateVector;

    private void Start()
    {
        MainSystem = GameObject.Find("MainSystem");
        mainSystemScript = MainSystem.GetComponent<MainSystemScript>();

        stateVector = 0;
    }
    
    private void Update()
    {   
        CameraUpdate();
    }

    private void CameraUpdate()
    {
        if(mainSystemScript.isMove == true)
        {
            if(Input.GetMouseButtonDown(0))
            {
                newAngle = MainCamera.transform.localEulerAngles;
                lastMousePosition = Input.mousePosition;
            }
            if(Input.GetMouseButton(0))
            {
                newAngle.y -= (Input.mousePosition.x - lastMousePosition.x) * 0.1f;
                newAngle.x += (Input.mousePosition.y - lastMousePosition.y) * 0.1f;
                MainCamera.gameObject.transform.localEulerAngles = newAngle;

                lastMousePosition = Input.mousePosition;
            }
            if(Input.GetMouseButtonUp(0))
            {
                float lastVector;
                if(newAngle.y > 0.0f)
                {
                    lastVector = newAngle.y;
                }
                else
                {
                    lastVector = -newAngle.y;
                }

                while(lastVector > 360.0f)
                {
                    lastVector += -360.0f;
                }

                if((lastVector < 22.5f && lastVector > 0.0f) || (lastVector < 337.5f && lastVector > 360.0f))
                {
                    stateVector = 0;
                }
                else if(lastVector < 122.5f && lastVector > 67.5f)
                {
                    stateVector = 1;
                }
                else if(lastVector < 202.5f && lastVector > 157.5f)
                {
                    stateVector = 2;
                }
                else if(lastVector < 292.5f && lastVector > 247.5f)
                {
                    stateVector = 3;
                }
                else if(lastVector < 67.5f && lastVector > 22.5f)
                {
                    stateVector = 4;
                }
                else if(lastVector < 157.5f && lastVector > 122.5f)
                {
                    stateVector = 5;
                }
                else if(lastVector < 247.5f && lastVector > 202.5f)
                {
                    stateVector = 6;
                }
                else if(lastVector <337.5f && lastVector > 292.5f)
                {
                    stateVector = 7;
                }
            }
        }
    }
}
