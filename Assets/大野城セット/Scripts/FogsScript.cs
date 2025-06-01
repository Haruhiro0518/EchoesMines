using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogsScript : MonoBehaviour
{

    private float FogUpDown = 1.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.y <= -1.2f) 
        {
            transform.Translate(new Vector3(0, FogUpDown / 4000, 0));
        }
    }

      
}