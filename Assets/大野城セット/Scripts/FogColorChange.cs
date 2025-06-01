using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogColorChange : MonoBehaviour
{
    private Color FogColor;
    private Color ColorChanger;
    private byte color;
    private float sun_rotationX;

    [SerializeField] private GameObject sun;
    // Start is called before the first frame update
    void Start()
    {
        sun = GameObject.Find("Sun");
        FogColor = GetComponent<Renderer>().material.color;
        ColorChanger = new Color32(color, color, color, 0);
    }

    // Update is called once per frame
    void Update()
    {
        sun_rotationX = sun.transform.rotation.x % 360;
        if (sun_rotationX >= 205 && sun_rotationX <= 335)
        {
            color = 200;
        }

        GetComponent<Renderer>().material.color = FogColor - ColorChanger;
    }
}
