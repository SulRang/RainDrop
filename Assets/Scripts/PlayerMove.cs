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

    private void PlayerIdle()
    {
        float angle = GetAngle(transform.position, new Vector3(0f, 0f, 0f));
        Vector3 euler = new Vector3(0f, 0f, angle + 90f + MoveAngle);
        transform.rotation = Quaternion.Euler(euler);
    }

    private void MoveIdleAnimation()
    {
        if (MoveAngle > 0)
            MoveAngle -= Time.deltaTime * 200;
        else if (MoveAngle < 0)
            MoveAngle += Time.deltaTime * 200;
        else if (MoveAngle == 0)
            return;
    }

    private void MovePositionRight()
    {
        runningTime += Time.deltaTime * speed;
        x = radius * Mathf.Cos(runningTime);
        y = radius * Mathf.Sin(runningTime);
        newPos = new Vector3(x, y, 0f);
        this.transform.position = newPos;
    }

    private void MovePositionLeft()
    {
        runningTime -= Time.deltaTime * speed;
        x = radius * Mathf.Cos(runningTime);
        y = radius * Mathf.Sin(runningTime);
        newPos = new Vector3(x, y, 0f);
        this.transform.position = newPos;
    }

    private void MoveAnimationRight()
    {
        if (MoveAngle >= -80 && MoveAngle <= 80) MoveAngle -= Time.deltaTime * 500;
        CheckMoveAnimation();
    }

    private void MoveAnimationLeft()
    {
        if (MoveAngle >= -80 && MoveAngle <= 80) MoveAngle += Time.deltaTime * 500;
        CheckMoveAnimation();
    }

    private void CheckMoveAnimation()
    {
        if (MoveAngle < -80) MoveAngle = -80;
        else if (MoveAngle > 80) MoveAngle = 80;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerIdle();
        
        if (UIManager.BMainActive)
        {
            MoveAnimationRight();
            MovePositionRight();
        } 

        if (!UIManager.BPauseActive)
            return;

#if UNITY_ANDROID
        if(bRight)
        {
            MoveAnimationRight();
            MovePositionRight();
        }
        else if(bLeft)
        {
            MoveAnimationLeft();
            MovePositionLeft();
        }
        else MoveIdleAnimation();
#else
        if (Input.GetKey(KeyCode.LeftArrow) == true)
        {
            MoveAnimationLeft();
            MovePositionLeft();
        }
        else if(Input.GetKey(KeyCode.RightArrow) == true)
        {
            MoveAnimationRight();
            MovePositionRight();
        }
        else MoveIdleAnimation();
#endif
    }
}
