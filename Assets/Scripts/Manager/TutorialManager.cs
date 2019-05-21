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
    private int m_NowPage = 1;
    public Sprite[] Tutorial_Imaage;
    public string[] Tutorial_Masseages;
    public string[] Tutorial_SceneName;
    public Image ImageBox;
    public Text MasseageBox;
    

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
        if (m_NowPage + 1 > m_PageSize)
            return;
        m_NowPage++;
        PanelUpdate();
    }

    public void PrevPage()
    {
        if (m_NowPage - 1 < 1)
            return;
        m_NowPage--;
        PanelUpdate();
    }
    // 현재 정보 업데이트
    public void PanelUpdate()
    {

    }
    //버튼 처리
    public void IntoScene()
    {
        SceneManager.LoadScene(Tutorial_SceneName[m_NowPage]);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
