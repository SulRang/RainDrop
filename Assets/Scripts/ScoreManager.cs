using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public Text scoreLabel;

    // Start is called before the first frame update
    void Awake()
    {
        scoreLabel = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!(StartButton.BMainActive))
            scoreLabel.text = "Score : " + PlayerMove.Score.ToString();
    }
}
