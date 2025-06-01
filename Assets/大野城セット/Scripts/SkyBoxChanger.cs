using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] public class MaterialBoolPair
{
    public Material skyBox;
    public bool sunCanMove;
    public bool noonOrNight;
}

public class SkyBoxChanger : MonoBehaviour
{
    private int _Index = 0;

    public GameObject Sun;
    public MaterialBoolPair[] SkyBoxList;
    // Start is called before the first frame update
    void Start()
    {
        Sun = GameObject.Find("Sun");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(2))
        {
            _Index++;

            if(_Index >= SkyBoxList.Length)
                _Index = 0;

            RenderSettings.skybox = SkyBoxList[ _Index ].skyBox;
            
        }
        if (SkyBoxList[_Index].sunCanMove)
        {
            if (Input.GetKey("r"))
            {
                Sun.transform.Rotate(new Vector3(1, 0));
                //} else if(Input.GetKey("f")) {
                //transform.Rotate(new Vector3(0, 1));
            }
            else
            {
                // Yé≤ÇíÜêSÇ…ÇPïbÇ…Ç¬Ç´Å|3ìxâÒì]Ç∑ÇÈ
                Sun.transform.Rotate(new Vector3(1, 0) * Time.deltaTime);
            }
        }
        else if (SkyBoxList[_Index].noonOrNight)
        {
            Sun.transform.eulerAngles = new Vector3(30, 135, 0);
        }else if (!SkyBoxList[_Index].noonOrNight)
        {
            Sun.transform.eulerAngles = new Vector3(270, 135, 0);
        }
    }
}
