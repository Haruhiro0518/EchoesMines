using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunMove : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKey("r")) {
            transform.Rotate(new Vector3(1, 0));
        //} else if(Input.GetKey("f")) {
            //transform.Rotate(new Vector3(0, 1));
        } else {
            // Y軸を中心に１秒につき－3度回転する
            transform.Rotate(new Vector3(1, 0) * Time.deltaTime);
        }
    }
}