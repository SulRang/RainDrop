using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance = null;

    public static GameManager Instance
    {
        get
        {
            _instance = FindObjectOfType<GameManager>();
            if (_instance == null)
                Debug.Log("GameManager is not Find.");
            return _instance;
        }
    }

    public float fGameSpeed = 1f;

    void Start()
    {

        if (_instance == null)
            _instance = this;
        if (_instance != this)
            Destroy(gameObject);

        Screen.orientation = ScreenOrientation.LandscapeLeft;
        Screen.SetResolution(1920, 1080, false);

        AudioManager.Instance.PlayMusic(AudioManager.Instance.Background);
        AudioManager.Instance.PlayMusic(AudioManager.Instance.RainDrop);
        AudioManager.Instance.PlayMusic(AudioManager.Instance.Fire);


        ScoreManager.CScore = 0f;
        ScoreManager.BScore = 0f;
        UIManager.BMainActive = true;
        UIManager.BPauseActive = false;
    }

    void Update()
    {
        Run();

        if (Input.GetKey(KeyCode.Escape))
            Application.Quit();
    }

    private void GameInit()
    {
        
    }

    private void Run()
    {
        if(!UIManager.BMainActive && UIManager.BPauseActive)
            ArrowManager.Instance.SpawnArrow();
        AudioManager.Instance.AudioRun();
    }

}
