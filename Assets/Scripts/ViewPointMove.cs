using UnityEngine;

public class ViewPointMove : MonoBehaviour
{
    public Camera MainCamera;
    private Vector3 lastMousePosition;
    private Vector3 newAngle = new Vector3(0, 0, 0);

    private void Start()
    {
        
    }
    
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            newAngle = MainCamera.transform.localEulerAngles;
            lastMousePosition = Input.mousePosition;
        }
        if(Input.GetMouseButton(0))
        {
            newAngle.y -= (Input.mousePosition.x - lastMousePosition.x) * 0.1f;
            newAngle.x -= (Input.mousePosition.y - lastMousePosition.y) * 0.1f;
            MainCamera.gameObject.transform.localEulerAngles = newAngle;

            lastMousePosition = Input.mousePosition;
        }

    }
}