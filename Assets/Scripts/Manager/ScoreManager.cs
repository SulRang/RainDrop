﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms;
using GooglePlayGames.BasicApi;
using GooglePlayGames;


public class ScoreManager : MonoBehaviour
{
    public Text scoreLabel;
    public Text levelLabel;
    public Text currentScore, BestScore;
    public static float CScore;
    public static float BScore;

    public static void CheckScore()
    {
        Social.LoadScores(GPGSIds.leaderboard_1, Scores =>
        {
            if (Scores.Length > 0)
            {
                foreach (IScore score in Scores)
                {
                    if (score.value <= CScore)
                    {
                        BScore = CScore;
                        Social.Active.ReportScore((long)BScore, GPGSIds.leaderboard_1, null);
                    }
                }
            }
        });
    }

    public void ScoreUpdate()
    {
        if (!UIManager.BMainActive && UIManager.BPauseActive)
            CScore += Time.deltaTime;

        if (!(UIManager.BMainActive))
            scoreLabel.text = CScore.ToString("N2");

        currentScore.text = CScore.ToString("N2");
        //bestscore value 불러오기
        BestScore.text = PlayerPrefs.GetFloat("BEST", 0).ToString("N2");
    }

    void Start()
    {

    }

    void Update()
    {
        if (!UIManager.BMainActive && UIManager.BPauseActive)
            CScore += Time.deltaTime;

        if (!(UIManager.BMainActive))
            scoreLabel.text = CScore.ToString("N2");

        currentScore.text = CScore.ToString("N2");
        //bestscore value 불러오기
        BestScore.text = PlayerPrefs.GetFloat("BEST", 0).ToString("N2");
        if (BScore != CScore)
            Social.Active.ReportScore((long)BScore, GPGSIds.leaderboard_1, null);


    }
}