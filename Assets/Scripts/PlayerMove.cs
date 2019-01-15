using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMove : MonoBehaviour
{
    [SerializeField] [Range(0f, 10f)] float speed = 3;
    [SerializeField] [Range(0f, 10f)] float radius = 3;

    public static float Score;
    private float runningTime = 0;
    private Vector3 newPos = new Vector3();


    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Arrow")
            SceneManager.LoadScene("ResultScene");
        if (col.gameObject.tag == "Boom")
            ArrowManager.BoomCount++;
    }

    void Awake()
    {
        runningTime = 0;
        Score = 0;
    }

    void Update()
    {
        // 나중에 BMainActive 없에고 다른걸로 바꾸기

        if(!StartButton.BMainActive)
            Score += Time.deltaTime;

        if(StartButton.BMainActive)
        {
            runningTime += Time.deltaTime * speed;
            float x = radius * Mathf.Cos(runningTime);
            float y = radius * Mathf.Sin(runningTime);
            newPos = new Vector3(x, y, 0f);
        }
        if (Input.GetKey(KeyCode.LeftArrow) == true)
        {
            runningTime += Time.deltaTime * speed;
            float x = radius * Mathf.Cos(runningTime);
            float y = radius * Mathf.Sin(runningTime);
            newPos = new Vector3(x, y, 0f);
        }
        else if(Input.GetKey(KeyCode.RightArrow) == true)
        {
            runningTime -= Time.deltaTime * speed;
            float x = radius * Mathf.Cos(runningTime);
            float y = radius * Mathf.Sin(runningTime);
            newPos = new Vector3(x, y, 0f);
            
        }
        this.transform.position = newPos;
    }
}
