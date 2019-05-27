using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class TutorialManager : MonoBehaviour
{
    private static TutorialManager _instance = null;
    private int m_PageSize;
    public int m_NowPage = 1;
    public Sprite[] Tutorial_Imaage;
    public string[] Tutorial_Masseages;
    public string[] Tutorial_SceneName;
    public bool TutorialCheck;
    public bool TutorialMode = false;
    public Image ImageBox;
    public Text MasseageBox;
    public int Chapter = 0;
    
    public static TutorialManager Instance
    {
        get
        {
            _instance = FindObjectOfType<TutorialManager>();
            return _instance;
        }
    }

    public void NextPage()
    {
        if (m_NowPage == m_PageSize - 1)
            return;
        m_NowPage++;
        PanelUpdate();
    }

    // 
    public void PrevPage()
    {
        if (m_NowPage == 1)
            return;
        m_NowPage--;
        PanelUpdate();
    }

    // 현재 정보 업데이트
    public void PanelUpdate()
    {
        MasseageBox.text = Tutorial_Masseages[m_NowPage].Replace(',','\n');
        ImageBox.sprite = Tutorial_Imaage[m_NowPage];
    }

    //버튼 처리
    public void IntoScene()
    {
        SceneManager.LoadScene(Tutorial_SceneName[m_NowPage]);
    }

    public void NextScene()
    {
        SceneManager.LoadScene(Tutorial_SceneName[Chapter + 1]);
    }

    public void HomeScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void GotoMain()
    {
        SceneManager.LoadScene("MainScene");
    }

    // Start is called before the first frame update
    void Start()
    {
        PanelUpdate();
        m_PageSize = Tutorial_Masseages.Length;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
