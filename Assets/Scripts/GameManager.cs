using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance = null;

    private LevelManager levelManager;


    void Start()
    {

        if (_instance == null)
            _instance = this;
        if (_instance != this)
            Destroy(gameObject);
        
        levelManager = FindObjectOfType<LevelManager>();

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
        //if (!UIManager.BMainActive && UIManager.BPauseActive)
        //    AudioManager.Instance.AudioRun();
    }

}
