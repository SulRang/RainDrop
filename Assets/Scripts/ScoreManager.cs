using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreLabel;
    public static float Score;

    // Start is called before the first frame update
    void Awake()
    {
        Score = 0f;
        scoreLabel = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!StartButton.BMainActive)
            Score += Time.deltaTime;

        if (!(StartButton.BMainActive))
            scoreLabel.text = "Score : " + Score.ToString();
    }
}
