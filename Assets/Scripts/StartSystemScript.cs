using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSystemScript : MonoBehaviour
{
    [SerializeField, Header("タイトル")]
    private GameObject TitleSelect;

    [SerializeField, Header("プレイ")]
    private GameObject PlaySelect;

    [SerializeField, Header("ガイド")]
    private GameObject GuidSelect;
    
    private void Start()
    {
        TitleSelect.SetActive(true);
        PlaySelect.SetActive(false);
        GuidSelect.SetActive(false);
    }

    private void Update()
    {
        
    }

    public void SelectPlay()
    {
        TitleSelect.SetActive(false);
        PlaySelect.SetActive(true);
    }

    public void SelectGuid()
    {
        TitleSelect.SetActive(false);
        GuidSelect.SetActive(true);
    }

    public void SelectBack()
    {
        TitleSelect.SetActive(true);
        PlaySelect.SetActive(false);
        GuidSelect.SetActive(false);
    }
    
    public void SelectStage01()
    {
        SceneManager.LoadScene("Stage01");
    }

    public void SelectStage02()
    {
        SceneManager.LoadScene("Stage02");
    }

    public void SelectStage03()
    {
        SceneManager.LoadScene("Stage03");
    }

    public void SelectStage04()
    {
        SceneManager.LoadScene("Stage04");
    }
}
