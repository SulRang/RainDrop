using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] [Range(0f, 10f)] public float speed = 3f;
    [SerializeField] [Range(0f, 10f)] public float radius = 3f;

    public GameObject ArrowBoard;

    public static int BoomCount = 1;
    private float runningTime = 0;
    private Vector3 newPos = new Vector3();

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Arrow")
            SceneManager.LoadScene("ResultScene");
        if (col.gameObject.tag == "Item")
        {
            BoomCount++;
            Destroy(col.gameObject);
        }
    }

    void Awake()
    {
        runningTime = 0;       
    }

    void Update()
    {
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
