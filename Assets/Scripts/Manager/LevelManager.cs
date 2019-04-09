using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public float levelSection = 10f;
    public int gameLevel = 1;
    public float fRunningTime = 0f;

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
        
    public void Initialize()
    {
        gameLevel = 1;
        fRunningTime = 0;
        levelSection = 10;
    }

    public int GetGameLevel()
    {
        return gameLevel;
    }

    public void UpdateLevel()
    {
        fRunningTime += Time.deltaTime;

        if(fRunningTime >= levelSection)
        {
            fRunningTime = 0;
            levelSection += 2;
            gameLevel++;
            ArrowManager.Instance.MakeBoom();
        }
    }

    void Start()
    {
        //arrowManager = FindObjectOfType<ArrowManager>();
        Initialize();
    }
    
    void Update()
    {
        
    }
}
