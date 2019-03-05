using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float speed = 2f;
    public float radius = 1.5f;

    private bool bLeft = false;
    private bool bRight = false;
    private float runningTime = 0f;
    private Vector3 newPos = new Vector3();

    private float x = 0f;
    private float y = 1f;

    private float MoveAngle = 0;

    // Start is called before the first frame update
    void Start()
    {
        bLeft = false;
        bRight = false;
        runningTime = 0;
        speed = 5;
        radius = 1.5f;
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

    public static float GetAngle(Vector3 vStart, Vector3 vEnd)
    {
        Vector3 v = vEnd - vStart;

        return Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
    }

    // Update is called once per frame
    void Update()
    {

        float angle = GetAngle(transform.position, new Vector3(0f,0f,0f));
        Vector3 euler = new Vector3(0f, 0f, angle + 90f + MoveAngle);
        transform.rotation = Quaternion.Euler(euler);

        if (UIManager.BMainActive)
        {
            if (MoveAngle > -80 && MoveAngle < 80)
                MoveAngle -= Time.deltaTime * 500;

            runningTime += Time.deltaTime * speed;
            x = radius * Mathf.Cos(runningTime);
            y = radius * Mathf.Sin(runningTime);
            newPos = new Vector3(x, y, 0f);
            this.transform.position = newPos;
        }

        if (!UIManager.BPauseActive)
            return;

#if UNITY_ANDROID
        if(bRight)
        {
            if (MoveAngle > -80 && MoveAngle < 80)
                MoveAngle -= Time.deltaTime * 500;

            runningTime += Time.deltaTime * speed;
            x = radius * Mathf.Cos(runningTime);
            y = radius * Mathf.Sin(runningTime);
            newPos = new Vector3(x, y, 0f);
            this.transform.position = newPos;
        }
        else if(bLeft)
        {
            if (MoveAngle > -80 && MoveAngle < 80)
                MoveAngle += Time.deltaTime * 500;

            runningTime -= Time.deltaTime * speed;
            x = radius * Mathf.Cos(runningTime);
            y = radius * Mathf.Sin(runningTime);
            newPos = new Vector3(x, y, 0f);
            this.transform.position = newPos;
        }
        else
        {
            if (MoveAngle > 0)
                MoveAngle -= Time.deltaTime * 200;
            else if (MoveAngle < 0)
                MoveAngle += Time.deltaTime * 200;
        }
#else
        if(Input.GetKey(KeyCode.LeftArrow) == true)
        {
            if(MoveAngle > -80 && MoveAngle < 80)
                MoveAngle += Time.deltaTime * 500;

            runningTime -= Time.deltaTime * speed;
            x = radius * Mathf.Cos(runningTime);
            y = radius * Mathf.Sin(runningTime);
            newPos = new Vector3(x, y, 0f);
            this.transform.position = newPos;
        }
        else if(Input.GetKey(KeyCode.RightArrow) == true)
        {
            if (MoveAngle > -80 && MoveAngle < 80)
                MoveAngle -= Time.deltaTime * 500;

            runningTime += Time.deltaTime * speed;
            x = radius * Mathf.Cos(runningTime);
            y = radius * Mathf.Sin(runningTime);
            newPos = new Vector3(x, y, 0f);
            this.transform.position = newPos;
        }
        else
        {
            if (MoveAngle > 0)
                MoveAngle -= Time.deltaTime * 200;
            else if (MoveAngle < 0)
                MoveAngle += Time.deltaTime * 200;
        }
#endif
    }
}
