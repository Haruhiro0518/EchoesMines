using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    [SerializeField, Header("起動")]
    public bool isPushed;

    private GameObject MainSystem;

    private MainSystemScript mainSystemScript;
    
    private void Start()
    {
        MainSystem = GameObject.Find("MainSystem");
        mainSystemScript = MainSystem.GetComponent<MainSystemScript>();

        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }

        isPushed = false;
    }

    private void Update()
    {
        ButtonUpdate();
    }

    private void ButtonUpdate()
    {
        if(mainSystemScript.isClear == true)
        {
            foreach(Transform child in transform)
            {
                child.gameObject.SetActive(true);
            }
        }
    }
    
    public void ButtonPush()
    {
        /*foreach(Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }*/

        isPushed = true;
        Destroy(gameObject);
    }
}
