using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using DG;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static bool BMainActive = true;
    public static bool BPauseActive = false;

    private float UI_duration = 0.5f;

    //  Main UI
    public RectTransform title, start, option, login, leaderboard;

    //  Option UI
    public RectTransform op_panel, back;

    //  Ingame UI
    public RectTransform score, pause, bomb;

    //  Pause UI 
    public RectTransform ps_panel;

    //  Result UI
    public RectTransform rs_panel, retry, home;

    void Start()
    {
        //BMainActive = true;
        //BPauseActive = false;
    }

    public bool CheckGamePause()
    {
        if (!BMainActive)
            return false;
        if (BPauseActive)
            return false; 
        return true;
    }


    public void StartBnt()
    {
        PlayerPrefs.DeleteAll();
        CloseMain();
        OpenIngame();
        BMainActive = false;
        BPauseActive = true;
    }

    public void OptionBnt()
    {
        CloseMain();
        OpenOption();
    }

    public void BackBnt()
    {
        OpenMenu();
        CloseOption();           
    }

    void PauseBnt()
    {
        CloseIngame();
        OpenPause();

        BPauseActive = false;   
    }

    public void ContinueBnt()
    {
        ClosePause();
        OpenIngame();

        BPauseActive = true;        
    }

    public void HomeBnt()
    {
        ArrowManager arrowManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<ArrowManager>();
        BMainActive = true;
        BPauseActive = false;
        arrowManager.speed = 13;
        LevelManager.Instance.gameLevel = 0;
        ScoreManager.CScore = 0f;
        SceneManager.LoadScene("MainScene");
    }
       
    public void Result()
    {
        CloseIngame();
        OpenResult();
    }

    public void RetryBnt()
    {
        GameObject arrowBoard = GameObject.Find("ArrowParent");
        ArrowManager arrowManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<ArrowManager>();
        foreach (Transform child in arrowBoard.transform)
        {
            Destroy(child.gameObject);
        }
        ScoreManager.CScore = 0f;
        arrowManager.speed = 13;
        LevelManager.Instance.gameLevel = 0;
        BPauseActive = true;

        CloseResult();
        OpenIngame();

    }


    public void MusicBnt()
    {
        foreach (var item in AudioManager.Instance.MusicSource)
        {
            item.mute = !(item.mute);
        }
    }

    public void EffectBnt()
    {
        AudioManager.Instance.EffectsSource.mute = !(AudioManager.Instance.EffectsSource.mute);
    }


    void CloseMain()
    {
        login.DOAnchorPos(new Vector2(850, -600), UI_duration);
        title.DOAnchorPos(new Vector2(0, 660), UI_duration);
        leaderboard.DOAnchorPos(new Vector2(850, -620), UI_duration);
        start.gameObject.SetActive(false);
        option.DOAnchorPos(new Vector2(855, 620), UI_duration);
    }

    void OpenMenu()
    {
        login.DOAnchorPos(new Vector2(850, -430), UI_duration);
        title.DOAnchorPos(new Vector2(0, 300), UI_duration);
        leaderboard.DOAnchorPos(new Vector2(850, -250), UI_duration);
        start.gameObject.SetActive(true);
        option.DOAnchorPos(new Vector2(855, 435), UI_duration);
    }

    void OpenOption()
    {
        AudioManager.Instance.InitAudioManager();
        op_panel.DOAnchorPos(new Vector2(0, 0), UI_duration);
        back.DOAnchorPos(new Vector2(855, 435), UI_duration);
    }

    void CloseOption()
    {
        op_panel.DOAnchorPos(new Vector2(0, 800), UI_duration);
        back.DOAnchorPos(new Vector2(855, 620), UI_duration);
    }

    void OpenIngame()
    {
        bomb.DOAnchorPos(new Vector2(850, -450), UI_duration);
        score.DOAnchorPos(new Vector2(-860, 495), UI_duration);
        pause.DOAnchorPos(new Vector2(855, 435), UI_duration);
    }

    void CloseIngame()
    {
        bomb.DOAnchorPos(new Vector2(850, -600), UI_duration);
        score.DOAnchorPos(new Vector2(-860, 585), UI_duration);
        pause.DOAnchorPos(new Vector2(855, 620), UI_duration);
    }

    void OpenPause()
    {
        ps_panel.DOAnchorPos(new Vector2(0, 0), UI_duration);
    }

    void ClosePause()
    {
        ps_panel.DOAnchorPos(new Vector2(0, 800), UI_duration);
    }

    void OpenResult()
    {
        rs_panel.DOAnchorPos(new Vector2(0, 0), UI_duration);
        retry.DOAnchorPos(new Vector2(-275, -400), UI_duration);
        home.DOAnchorPos(new Vector2(275, -400), UI_duration);
    }

    void CloseResult()
    {
        rs_panel.DOAnchorPos(new Vector2(0, 800), UI_duration);
        retry.DOAnchorPos(new Vector2(-275, -600), UI_duration);
        home.DOAnchorPos(new Vector2(275, -600), UI_duration);
    }
   
}
