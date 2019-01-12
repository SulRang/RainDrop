using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMove : MonoBehaviour
{
    [SerializeField] [Range(0f, 10f)] float speed = 3;
    [SerializeField] [Range(0f, 10f)] float radius = 3;

    private float runningTime = 0;
    private Vector3 newPos = new Vector3();

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
        this.transform.position = newPos;
    }
}
