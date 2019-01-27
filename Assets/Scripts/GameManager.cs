using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private LevelManager levelManager;

    void Start()
    {
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
