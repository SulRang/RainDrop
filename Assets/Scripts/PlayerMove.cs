using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public float speed;
    public float radius;

    public GameObject ArrowBoard;
    private UIManager resultFnc;
    
    private float runningTime = 0f;
    private Vector3 newPos = new Vector3();

    public static float x = 0f;
    public static float y = 1f;

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
        else if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            runningTime -= Time.deltaTime * speed;
            x = radius * Mathf.Cos(runningTime);
            y = radius * Mathf.Sin(runningTime);
            newPos = new Vector3(x, y, 0f);
        }

        
        this.transform.position = newPos;

    }
}


