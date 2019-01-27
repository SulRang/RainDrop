using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class UIManager : MonoBehaviour
{
    public static bool BMainActive = true;
    public static bool BPauseActive = false;

    private float UI_duration = 0.25f;

    //  Main UI
    public RectTransform title, start, option;

    //  Option UI
    public RectTransform op_panel, back;

    //  Ingame UI
    public RectTransform score, pause;

    //  Pause UI 
    public RectTransform ps_panel;

    //  Result UI
    public RectTransform rs_panel;

    void Start()
    {
      //BMainActive = true;
      //BPauseActive = false;
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

    public void Result()
    {
        CloseIngame();
        OpenResult();
    }

    void CloseMain()
    {
        title.DOAnchorPos(new Vector2(0, 660), UI_duration);
        start.DOAnchorPos(new Vector2(0, -620), UI_duration);
        option.DOAnchorPos(new Vector2(855, 620), UI_duration);
    }

    void OpenMenu()
    {
        title.DOAnchorPos(new Vector2(0, 300), UI_duration);
        start.DOAnchorPos(new Vector2(0, -300), UI_duration);
        option.DOAnchorPos(new Vector2(855, 435), UI_duration);
    }

    void OpenOption()
    {
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
        score.DOAnchorPos(new Vector2(-860, 495), UI_duration);
        pause.DOAnchorPos(new Vector2(855, 435), UI_duration);
    }

    void CloseIngame()
    {
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
    }

    void CloseResult()
    {
        rs_panel.DOAnchorPos(new Vector2(0, 800), UI_duration);
    }
}
