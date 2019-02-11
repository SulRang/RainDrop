using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveByTouch : MonoBehaviour
{

    public float speed = 2f;
    public float radius = 1.5f;

    private bool bLeft = false;
    private bool bRight = false;
    private float runningTime = 0f;
    private Vector3 newPos = new Vector3();

    private float x = 0f;
    private float y = 1f;

    // Start is called before the first frame update
    void Start()
    {
        bLeft = false;
        bRight = false;
        runningTime = 0;
        speed = 5;
        radius = 1;
    }

    public void MoveLeft()
    {
        bLeft = true;
    }

    public void MoveRight()
    {
        bRight = true;
    }

    public void MoveLeftDown()
    {
        bLeft = false;
    }

    public void MoveRightDown()
    {
        bRight = false;
    }


    // Update is called once per frame
    void Update()
    {

        if (UIManager.BMainActive)
        {
            runningTime += Time.deltaTime * speed;
            x = radius * Mathf.Cos(runningTime);
            y = radius * Mathf.Sin(runningTime);
            newPos = new Vector3(x, y, 0f);
            this.transform.position = newPos;
        }

        if (!UIManager.BPauseActive)
            return;

        if(bRight)
        {
            runningTime += Time.deltaTime * speed;
            x = radius * Mathf.Cos(runningTime);
            y = radius * Mathf.Sin(runningTime);
            newPos = new Vector3(x, y, 0f);
            this.transform.position = newPos;
        }

        if(bLeft)
        {
            runningTime -= Time.deltaTime * speed;
            x = radius * Mathf.Cos(runningTime);
            y = radius * Mathf.Sin(runningTime);
            newPos = new Vector3(x, y, 0f);
            this.transform.position = newPos;
        }

    }
}
