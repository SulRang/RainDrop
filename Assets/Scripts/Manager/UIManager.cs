﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using DG;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance = null;
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<UIManager>();
            return _instance;
        }
    }

    private float UI_duration = 0.5f;

    //  Main UI
    public RectTransform title, start, option, login, leaderboard;

    // Tutorial UI
    public RectTransform tutorial, tutorialbtn,tutorialBack;

    //  Option UI
    public RectTransform op_panel, back;

    //  Ingame UI
    public RectTransform score, pause, bomb, level,leveltext;

    //  Pause UI 
    public RectTransform ps_panel;

    //  Result UI
    public RectTransform rs_panel, retry, home;

    void Start()
    {

    }

    public void StartBnt()
    {
        CloseMain();
        OpenIngame();
        GameManager.Instance.IsStart = false;
        GameManager.Instance.IsInGame = true;
    }

    public void TutorialBnt()
    {
        CloseMain();
        OpenTutorial();
        GameManager.Instance.IsTutorial = true;
        GameManager.Instance.IsStart = false;
    }
    
    public void TutorialBackBnt()
    {
        OpenMenu();
        CloseTutorial();
        GameManager.Instance.IsTutorial = false;
        GameManager.Instance.IsStart = true;
    }

    public void OptionBnt()
    {
        CloseMain();
        OpenOption();
        GameManager.Instance.IsStart = false;
        GameManager.Instance.IsOption = true;
    }

    public void BackBnt()
    {
        OpenMenu();
        CloseOption();
        GameManager.Instance.IsStart = true;
        GameManager.Instance.IsOption = false;
    }

    void PauseBnt()
    {
        CloseIngame();
        OpenPause();
        GameManager.Instance.IsInGame = false;
        GameManager.Instance.IsPause = true;
    }

    public void ContinueBnt()
    {
        ClosePause();
        OpenIngame();
        GameManager.Instance.IsInGame = true;
        GameManager.Instance.IsPause = false;
    }

    public void HomeBnt()
    {
        ArrowManager arrowManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<ArrowManager>();
        LevelManager.Instance.Initialize();
        GameManager.Instance.IsStart = true;
        GameManager.Instance.IsTutorial = false;
        GameManager.Instance.IsOption = false;
        GameManager.Instance.IsInGame = false;
        GameManager.Instance.IsPause = false;
        GameManager.Instance.IsResult = false;
        arrowManager.speed = 13;
        LevelManager.Instance.gameLevel = 0;
        ScoreManager.CScore = 0;
        SceneManager.LoadScene("MainScene");
    }
       
    public void Result()
    {
        ScoreManager.Instance.ScoreUpdate();
        CloseIngame();
        OpenResult();
        GameManager.Instance.IsInGame = false;
        GameManager.Instance.IsResult = true;
    }

    public void RetryBnt()
    {
        GameObject arrowBoard = GameObject.Find("ArrowParent");
        ArrowManager arrowManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<ArrowManager>();
        foreach (Transform child in arrowBoard.transform)
        {
            Destroy(child.gameObject);
        }
        ScoreManager.CScore = 0;
        arrowManager.speed = 13;
        LevelManager.Instance.gameLevel = 1;
        GameManager.Instance.IsInGame = true;
        GameManager.Instance.IsResult = false;
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
        tutorialbtn.DOAnchorPos(new Vector2(-855, -620), UI_duration);
    }

    void OpenMenu()
    {
        login.DOAnchorPos(new Vector2(850, -430), UI_duration);
        title.DOAnchorPos(new Vector2(0, 300), UI_duration);
        leaderboard.DOAnchorPos(new Vector2(850, -250), UI_duration);
        start.gameObject.SetActive(true);
        option.DOAnchorPos(new Vector2(855, 435), UI_duration);
        tutorialbtn.DOAnchorPos(new Vector2(-855, -420), UI_duration);
    }

    void OpenTutorial()
    {
        tutorial.DOAnchorPos(new Vector2(0, 0), UI_duration);
        tutorialbtn.DOAnchorPos(new Vector2(-834, -620), UI_duration);
        tutorialBack.DOAnchorPos(new Vector2(855, 420), UI_duration);
    }

    void CloseTutorial()
    {
        tutorial.DOAnchorPos(new Vector2(0,1200), UI_duration);
        tutorialbtn.DOAnchorPos(new Vector2(-834, -430), UI_duration);
        tutorialBack.DOAnchorPos(new Vector2(855, 620), UI_duration);
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
        level.DOAnchorPos(new Vector2(-889, 423), UI_duration);
        leveltext.DOAnchorPos(new Vector2(-788, 423), UI_duration);
    }

    void CloseIngame()
    {
        bomb.DOAnchorPos(new Vector2(850, -600), UI_duration);
        score.DOAnchorPos(new Vector2(-860, 585), UI_duration);
        pause.DOAnchorPos(new Vector2(855, 620), UI_duration);
        level.DOAnchorPos(new Vector2(-889, 647), UI_duration);
        leveltext.DOAnchorPos(new Vector2(-788, 647), UI_duration);
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
