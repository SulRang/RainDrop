using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] [Range(0f, 10f)] public float speed;
    [SerializeField] [Range(0f, 10f)] public float radius;

    public GameObject ArrowBoard;
    private UIManager resultFnc;


    public static int BoomCount = 1;
    private float runningTime = 0f;
    private Vector3 newPos = new Vector3();

    private float x = 0f;
    private float y = 1f;



    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Arrow")
        {
            if (ScoreManager.CScore >= PlayerPrefs.GetFloat("BEST", 0))
            {
                PlayerPrefs.SetFloat("BEST", ScoreManager.CScore);
            }
            UIManager.BPauseActive = false;
            resultFnc.Result();
           
        }
        if (col.gameObject.tag == "Item")
        {
            BoomCount++;
            Destroy(col.gameObject);
        }
    }

    void Awake()
    {
        resultFnc = FindObjectOfType<UIManager>();
        runningTime = 0;
        speed = 5f;
        radius = 1f;
    }

    void Update()
    {
        if (UIManager.BMainActive)
        {
            runningTime += Time.deltaTime * speed;
            x = radius * Mathf.Cos(runningTime);
            y = radius * Mathf.Sin(runningTime);
            newPos = new Vector3(x, y, 0f);
        }

        
        if (Input.GetKey(KeyCode.LeftArrow) == true)
        {
            runningTime += Time.deltaTime * speed;
            x = radius * Mathf.Cos(runningTime);
            y = radius * Mathf.Sin(runningTime);
            newPos = new Vector3(x, y, 0f);
        }
        else if(Input.GetKey(KeyCode.RightArrow) == true)
        {
            runningTime -= Time.deltaTime * speed;
            x = radius * Mathf.Cos(runningTime);
            y = radius * Mathf.Sin(runningTime);
            newPos = new Vector3(x, y, 0f);            
        }
        if(Input.GetKey(KeyCode.Space) == true && BoomCount > 0)
        {
            BoomCount--;
            foreach(Transform child in ArrowBoard.transform)
            {
                Destroy(child.gameObject);
            }
        }
        this.transform.position = newPos;
    }
}


