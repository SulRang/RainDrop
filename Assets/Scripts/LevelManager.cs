using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private ArrowManager arrowManager;
   
    [SerializeField] [Range(0f, 10f)] private float levelSection;
    [SerializeField] [Range(0f, 10f)] private float gameLevel;


    void Start()
    {
        arrowManager = FindObjectOfType<ArrowManager>();

        levelSection = 10f;
        gameLevel = 1f;

    }
    
    void Update()
    {
        if (ScoreManager.Score >= levelSection * gameLevel)
        {
            arrowManager.speed--;
            gameLevel++;
        }
    }
}
