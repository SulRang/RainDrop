using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance = null;

    private LevelManager levelManager;

    private void GameInit()
    {
        
    }

    void Start()
    {

        if (_instance == null)
            _instance = this;
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
        Run();
       
    }

    private void Game_Init()
    {

    }

    private void Run()
    {
        if(!UIManager.BMainActive && UIManager.BPauseActive)
            ArrowManager.Instance.SpawnArrow();
    }

}
