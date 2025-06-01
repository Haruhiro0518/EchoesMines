using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MainSystemScript : MonoBehaviour
{
    [SerializeField, Header("ゲームクリア")]
    public bool isClear;
    
    [SerializeField, Header("ゲームオーバー")]
    public bool isOver;

    private bool isOnce;

    private bool isCommand;

    [SerializeField, Header("操作の可否")]
    public bool isMove;

    [SerializeField, Header("操作の状態")]
    public bool isOpen;

    [SerializeField, Header("立体アートの状態")]
    private bool isArt;

    [SerializeField, Header("タイルの総数")]
    public int sumTile;
    
    [SerializeField, Header("地雷の総数")]
    public int sumMine;

    private int sumMustOpen;

    [SerializeField, Header("フラッグ")]
    private GameObject openFalse;

    [SerializeField, Header("オープン")]
    private GameObject openTrue;

    [SerializeField, Header("テキスト")]
    private GameObject mustOpenText;

    private TMPro.TMP_Text text;

    [SerializeField, Header("ポーズ")]
    private GameObject menuSelect;

    [SerializeField, Header("メニュー")]
    private GameObject menuScreen;

    [SerializeField, Header("タイトル")]
    private GameObject titleSelect;

    [SerializeField, Header("リトライ")]
    private GameObject restartSelect;

    [SerializeField, Header("音量スライダー")]
    private GameObject volumeSlider;

    [SerializeField, Header("音量倍率")]
    public float volumeZoom;

    private AudioSource bombSE;

    private void Start()
    {
        mustOpenText = GameObject.Find("Text");
        text = mustOpenText.GetComponent<TMPro.TMP_Text>();
        bombSE = GetComponent<AudioSource>();
        
        isClear = false;
        isOver = false;
        isMove = true;
        isOpen = false;
        isArt = false;
        sumMustOpen = sumTile - sumMine;

        openFalse.SetActive(true);
        openTrue.SetActive(false);
        mustOpenText.SetActive(true);
        menuSelect.SetActive(true);
        menuScreen.SetActive(false);
        titleSelect.SetActive(false);
        restartSelect.SetActive(false);
    }

    
    private void Update()
    {
        OpenUpdate();
        TextUpdate();
        CommandUpdate();
    }

    public void GameClear()
    {
        isClear = true;
    }

    public void GameOver()
    {
        isOver = true;
        isMove = false;

        menuSelect.SetActive(false);
        restartSelect.SetActive(true);

        bombSE.volume = 0.5f * volumeZoom;
        bombSE.Play();
    }

    public void ArtCheck()
    {
        isArt = true;
        menuSelect.SetActive(false);
        titleSelect.SetActive(true);
    }

    private void TextUpdate()
    {
        string sumText;

        if(isClear == true)
        {
            if(isArt == true)
            {
                text.SetText("GAME CLEAR!");
            }
            else
            {
                text.SetText("PUSH IT!");
            }
        }
        else if(isOver == true)
        {
            text.SetText("GAME OVER!");
        }
        else
        {
            sumText = sumMustOpen.ToString();
            text.SetText("MUST OPEN : " + sumText);
        }
    }

    public void SumUpdate()
    {
        sumMustOpen = sumMustOpen - 1;
        SumCheck();
    }

    private void SumCheck()
    {
        if(sumMustOpen == 0)
        {
            GameClear();
        }
    }

    private void OpenUpdate()
    {
        if(Input.GetKey(KeyCode.Return))
        {
            if(isMove == true && isOnce == true)
            {
                isOnce = false;
                isOpen = !isOpen;
                if(isOpen == true)
                {
                    openFalse.SetActive(false);
                    openTrue.SetActive(true);
                }
                else
                {
                    openFalse.SetActive(true);
                    openTrue.SetActive(false);
                }
            }   
        }
        else
        {
            isOnce = true;
        }
    }

    private void CommandUpdate()
    {
        if(Input.GetKey(KeyCode.Q))
        {
            if(isMove == true && isCommand == true)
            {
                isCommand = false;
                isClear = true;
            }   
        }
        else
        {
            isCommand = true;
        }
    }

    public void MenuSelect()
    {
        isMove = false;
        
        mustOpenText.SetActive(false);
        menuSelect.SetActive(false);
        menuScreen.SetActive(true);
    }

    public void BackSelect()
    {
        isMove = true;
        
        mustOpenText.SetActive(true);
        menuSelect.SetActive(true);
        menuScreen.SetActive(false);
    }

    public void TitleSelect()
    {
        SceneManager.LoadScene("Start");
    }

    public void RestartSelect()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SetVolume(float value)
    {
        volumeZoom = value;
    }
}
