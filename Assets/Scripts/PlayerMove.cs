using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMove : MonoBehaviour
{
    [SerializeField] [Range(0f, 10f)] float speed = 1;
    [SerializeField] [Range(0f, 10f)] private float radius = 1;

    private float runningTime = 0;
    private Vector3 newPos = new Vector3();

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) == true)
        {
            runningTime += Time.deltaTime * speed;
            float x = radius * Mathf.Cos(runningTime);
            float y = radius * Mathf.Sin(runningTime);
            newPos = new Vector3(x, y, 0f);
            this.transform.position = newPos;
        }
        else if(Input.GetKey(KeyCode.RightArrow) == true)
        {
            runningTime -= Time.deltaTime * speed;
            float x = radius * Mathf.Cos(runningTime);
            float y = radius * Mathf.Sin(runningTime);
            newPos = new Vector3(x, y, 0f);
            this.transform.position = newPos;
        }
        else
        {
            this.transform.position = newPos;
        }
    }
}
