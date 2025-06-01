using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtScript : MonoBehaviour
{
    private GameObject MainSystem;

    private MainSystemScript mainSystemScript;

    private GameObject Player;

    private PlayerScript playerScript;

    private AudioSource Audio;

    private bool isPlay;

    private bool isOnce;
    
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
        Audio = gameObject.GetComponent<AudioSource>();
        isPlay = false;
        isOnce = true;
    }

    private void Update()
    {
        ArtUpdate();
    }

    private void ArtUpdate()
    {
        if(playerScript.isReady == true)
        {
            foreach(Transform child in transform)
            {
                child.gameObject.SetActive(true);
                isPlay = true;
            }

            mainSystemScript.ArtCheck();
        }

        if(isPlay == true)
        {
            if(isOnce == true)
            {
                isOnce = false;
                Audio.volume = 0.5f * mainSystemScript.volumeZoom;
                Audio.Play();
            }
        }
    }
}
