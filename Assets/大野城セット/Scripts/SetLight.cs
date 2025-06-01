using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLight : MonoBehaviour
{
    [SerializeField] private GameObject prefabGameObject;
    [SerializeField] private GameObject Sun;

    private GameObject LightObject;
    // Start is called before the first frame update
    void Start()
    {
        LightObject = Instantiate(prefabGameObject);
        Sun = GameObject.Find("Sun");
        LightObject.transform.position = Vector3.zero;
        //LightObject.transform.rotation = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if(Sun.transform.eulerAngles.x % 360 < 350 && Sun.transform.eulerAngles.x % 360 > 190)
        {
            LightObject.SetActive(true);
        }
        else
        {
            LightObject.SetActive(false);
        }
    }


}
