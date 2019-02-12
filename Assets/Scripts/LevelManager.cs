using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    
    [SerializeField] [Range(0f, 10f)] public float levelSection;
    [SerializeField] [Range(0f, 10f)] private float gameLevel;


    void Start()
    {
        //arrowManager = FindObjectOfType<ArrowManager>();

        levelSection = 10f;
        gameLevel = 1f;

    }
    
    void Update()
    {
        if (ScoreManager.CScore >= levelSection * gameLevel)
        {
            ArrowManager.Instance.speed--;
            gameLevel++;
            ArrowManager.Instance.MakeBoom();
        }
    }
}
