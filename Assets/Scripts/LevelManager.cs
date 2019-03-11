﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    
    [SerializeField] [Range(0f, 10f)] public float levelSection;
    [SerializeField] [Range(0f, 10f)] public int gameLevel;

    private static LevelManager _instance = null;

    public static LevelManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<LevelManager>();
                if (_instance == null)
                    Debug.Log("LevelManager is nowhere");
            }

            return _instance;
        }
    }

    void Start()
    {
        //arrowManager = FindObjectOfType<ArrowManager>();

        levelSection = 10f;
        gameLevel = 1;

    }
    
    void Update()
    {
        if (ScoreManager.CScore >= levelSection * gameLevel)
        {
            gameLevel++;
            ArrowManager.Instance.MakeBoom();
        }
    }
}
