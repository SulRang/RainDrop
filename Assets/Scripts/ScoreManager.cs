using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreLabel;
    public Text currentScore, BestScore;
    public static float CScore;
    public static float BScore;
    
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
        BestScore.text = PlayerPrefs.GetFloat("BEST", 0).ToString("N2");
    }
}
