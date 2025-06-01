using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TileScript : MonoBehaviour
{
    [SerializeField, Header("地雷の判定")]
    private bool isMine;

    private bool isFlag;

    private bool isOnce;

    private GameObject MainSystem;

    private MainSystemScript mainSystemScript;

    private GameObject Player;

    private PlayerScript playerScript;

    private Transform tileTransform;

    private Vector3 tilePosition;

    private float distance;

    private AudioSource alertSE;

    private float volumeValue = 0.2f;

    [SerializeField, Header("爆破演出")]
    private GameObject explosionEffect;
    
    private void Start()
    {
        MainSystem = GameObject.Find("MainSystem");
        mainSystemScript = MainSystem.GetComponent<MainSystemScript>();
        Player = GameObject.Find("Player");
        playerScript = Player.GetComponent<PlayerScript>();

        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }

        alertSE = GetComponent<AudioSource>();
        alertSE.volume = 0.0f;
        alertSE.Play();

        isFlag = false;
        isOnce = true;
    }

    private void Update()
    {
        TileUpdate();
        DistanceUpdate();
        OnCheck();
        AlertUpdate();
    }

    private void TileUpdate()
    {
        if(mainSystemScript.isClear)
        {
            gameObject.SetActive(false);
        }
    }

    private void DistanceUpdate()
    {
        Transform tileTransform = gameObject.transform;
        Vector3 tilePosition = tileTransform.position;
        distance = (float)Math.Sqrt(Math.Pow((playerScript.playerPosition.x - tilePosition.x), 2) + Math.Pow((playerScript.playerPosition.z - tilePosition.z), 2));
    }

    private void OnCheck()
    {
        if(distance < 0.1f)
        {
            if(isFlag == false)
            {
                if(isMine == true)
                {
                    if(isOnce == true)
                    {
                        isOnce = false;
                        Instantiate(explosionEffect, new Vector3(playerScript.playerPosition.x, 0.0f, playerScript.playerPosition.z), Quaternion.identity);
                        mainSystemScript.GameOver();
                    }
                }
            }
        }
    }

    private void AlertUpdate()
    {
        if(mainSystemScript.isOver == false)
        {
            if(isMine == true)
            {
                if(isFlag == false)
                {
                    if(distance < 1.5f)
                    {
                        alertSE.volume = mainSystemScript.volumeZoom * volumeValue * (1.5f / distance);
                    }
                    else
                    {
                        alertSE.volume = 0.0f;
                    }
                }
                else
                {
                    alertSE.volume = 0.0f;
                }
            }
            else
            {
                alertSE.volume = 0.0f;
            }
        }
        else
        {
            alertSE.volume = 0.0f;
        }
    }

    public void OpenTile()
    {
        if(mainSystemScript.isMove == true)
        {
            if(mainSystemScript.isOpen == false)
            {
                foreach(Transform child in transform)
                {
                    if(isFlag == true)
                    {
                        child.gameObject.SetActive(false);
                    }
                    else
                    {
                        child.gameObject.SetActive(true);
                    }
                }
                isFlag = !isFlag;
            }
            else
            {
                if(isMine == true)
                {
                    if(isFlag == false)
                    {
                        if(isOnce == true)
                        {
                            isOnce = false;
                            Instantiate(explosionEffect, new Vector3(playerScript.playerPosition.x, 0.0f, playerScript.playerPosition.z), Quaternion.identity);
                            mainSystemScript.GameOver();
                        }
                    }
                }
                else
                {
                    mainSystemScript.SumUpdate();
                    gameObject.SetActive(false);
                }
            }   
        }
    }
}
