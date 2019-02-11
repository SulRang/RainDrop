using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameManager _instance = null;

    private LevelManager levelManager;

    private void GameInit()
    {
        
    }

    void Start()
    {
        DontDestroyOnLoad(this);

        if (_instance != this)
            Destroy(gameObject);

        levelManager = FindObjectOfType<LevelManager>();
        ScoreManager.CScore = 0f;
        ScoreManager.BScore = 0f;
        UIManager.BMainActive = true;
        UIManager.BPauseActive = false;
    }

    void Update()
    {
    }

    void Game_Init()
    {

    }

    void Game_Run()
    {
       // if ()
    }


}
