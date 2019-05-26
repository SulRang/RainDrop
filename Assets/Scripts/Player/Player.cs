﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    public bool bPlayerMove;
    public bool bPlayerControl;
    private UIManager mUIManager;
    public GameObject ArrowBoard = null;
    public static int BoomCount = 0;
    public GameObject BombEffect;

    public float fSpeed = 5f;
    public float fRadius = 1.5f;
    public float fRunningTime = 0f;

    private bool bLeft = false;
    private bool bRight = false;

    private Vector3 vNewPos = new Vector3();
    private float x = 0f;
    private float y = 1f;

    private float fAnimationAngle = 0;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Arrow")
        {
            if (ScoreManager.CScore >= PlayerPrefs.GetFloat("BEST", 0))
            {
                PlayerPrefs.SetFloat("BEST", ScoreManager.CScore);
                Social.Active.ReportScore(ScoreManager.CScore*1, GPGSIds.leaderboard_readerboard, bSuccess =>
                {
                    if (bSuccess)
                    {
                        Debug.Log($"{ScoreManager.CScore} reported");
                    }
                    else
                    {
                        Debug.Log("Authentication is required");
                    }
                });
            }
            mUIManager.Result();
            AdManager.Instance.IsShowAd();
        }
        if (col.gameObject.tag.Equals("Item"))
        {
            BoomCount++;
            Destroy(col.gameObject);
        }
    }

    public void MoveLeft()
    {
        bRight = true;
    }

    public void MoveRight()
    {
        bLeft = true;
    }

    public void MoveLeftDown()
    {
        bRight = false;
    }

    public void MoveRightDown()
    {
        bLeft = false;
    }

    public void ActiveBoom()
    {
        if (BoomCount > 0)
        {
            BoomCount--;
            GameObject instance = Instantiate(BombEffect, new Vector3(0f, 0f, 10f), Quaternion.identity) as GameObject;
            Destroy(instance, 0.25f);
            foreach (Transform child in ArrowBoard.transform)
            {
                AudioManager.Instance.RandomSoundEffect(AudioManager.Instance.Bomb);
                if (child.tag == "Arrow")
                    Destroy(child.gameObject);
            }
        }
    }

    public float GetAngle(Vector3 vStart, Vector3 vEnd)
    {
        Vector3 v = vEnd - vStart;

        return Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
    }

    private void ChangeAnimationAngle(float val)
    {
        fAnimationAngle += val * Time.deltaTime;
    }

    private void PlayerIdle()
    {
        float angle = GetAngle(transform.position, new Vector3(0f, 0f, 0f));
        Vector3 euler = new Vector3(0f, 0f, angle + 90f + fAnimationAngle);
        transform.rotation = Quaternion.Euler(euler);
    }

    private void MoveIdleAnimation()
    {
        if (fAnimationAngle > 0)
            ChangeAnimationAngle(-200);
        else if (fAnimationAngle < 0)
            ChangeAnimationAngle(200);
        else if (fAnimationAngle == 0)
            return;
    }

    private void MovePositionRight()
    {
        fRunningTime += Time.deltaTime * fSpeed;
        x = fRadius * Mathf.Cos(fRunningTime);
        y = fRadius * Mathf.Sin(fRunningTime);
        vNewPos = new Vector3(x, y, 0f);
        this.transform.position = vNewPos;
    }

    private void MovePositionLeft()
    {
        fRunningTime -= Time.deltaTime * fSpeed;
        x = fRadius * Mathf.Cos(fRunningTime);
        y = fRadius * Mathf.Sin(fRunningTime);
        vNewPos = new Vector3(x, y, 0f);
        this.transform.position = vNewPos;
    }

    private void MoveAnimationRight()
    {
        if (fAnimationAngle >= -80 && fAnimationAngle <= 80) ChangeAnimationAngle(-500);
        CheckMoveAnimation();
    }

    private void MoveAnimationLeft()
    {
        if (fAnimationAngle >= -80 && fAnimationAngle <= 80) ChangeAnimationAngle(500);
        CheckMoveAnimation();
    }

    private void CheckMoveAnimation()
    {
        if (fAnimationAngle < -80) fAnimationAngle = -80;
        else if (fAnimationAngle > 80) fAnimationAngle = 80;
    }

    public bool GetbPlayerMove()
    {
        return bPlayerMove;
    }

    //tutorial
    private void GoToMove()
    {
        fSpeed = 2f;
        if (transform.position.y <= 1.49f)
        {
            MovePositionRight();
            MoveAnimationRight();
        }
        else MoveIdleAnimation();
        fSpeed = 5f;
    }

    private void Start()
    {
        mUIManager = FindObjectOfType<UIManager>();
        transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
        BoomCount = 0;
    }

    private void Update()
    {
        PlayerIdle();

        //if (GameManager.Instance.IsTutorial)
        //{
        //    GoToMove();
        //    return;
        //}

        if (GameManager.Instance.IsStart)
        {
            MoveAnimationRight();
            MovePositionRight();
            return;
        }

        if (!GameManager.Instance.IsInGame)
            return;

        if (bRight)
        {
            MoveAnimationRight();
            MovePositionRight();
        }
        else if (bLeft)
        {
            MoveAnimationLeft();
            MovePositionLeft();
        }
        else MoveIdleAnimation();
    }
}
