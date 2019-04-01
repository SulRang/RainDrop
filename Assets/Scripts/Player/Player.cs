using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool bPlayerMove;
    private UIManager mUIManager;
    public GameObject ArrowBoard = null;
    public static int BoomCount = 0;

    public float fSpeed = 5f;
    public float fRadius = 1.5f;
    private float fRunningTime = 0f;

    private bool bLeft = false;
    private bool bRight = true;

    private Vector3 vNewPos = new Vector3();
    private float x = 0f;
    private float y = 1f;

    private float fMoveAngle = 0;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Arrow")
        {
            if (ScoreManager.CScore >= PlayerPrefs.GetFloat("BEST", 0))
            {
                PlayerPrefs.SetFloat("BEST", ScoreManager.CScore);
            }
            UIManager.BPauseActive = false;
            mUIManager.Result();
        }
        if (col.gameObject.tag.Equals("Item"))
        {
            BoomCount++;
            Destroy(col.gameObject);
        }
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

    public void ActiveBoom()
    {
        if (BoomCount > 0)
        {
            BoomCount--;
            foreach (Transform child in ArrowBoard.transform)
            {
                AudioManager.Instance.RandomSoundEffect(AudioManager.Instance.Bomb);

                if (child.tag == "Arrow")
                    Destroy(child.gameObject);
            }
        }
    }

    public static float GetAngle(Vector3 vStart, Vector3 vEnd)
    {
        Vector3 v = vEnd - vStart;

        return Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
    }

    private void PlayerIdle()
    {
        float angle = GetAngle(transform.position, new Vector3(0f, 0f, 0f));
        Vector3 euler = new Vector3(0f, 0f, angle + 90f + fMoveAngle);
        transform.rotation = Quaternion.Euler(euler);
    }

    private void MoveIdleAnimation()
    {
        if (fMoveAngle > 0)
            fMoveAngle -= Time.deltaTime * 200;
        else if (fMoveAngle < 0)
            fMoveAngle += Time.deltaTime * 200;
        else if (fMoveAngle == 0)
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
        if (fMoveAngle >= -80 && fMoveAngle <= 80) fMoveAngle -= Time.deltaTime * 500;
        CheckMoveAnimation();
    }

    private void MoveAnimationLeft()
    {
        if (fMoveAngle >= -80 && fMoveAngle <= 80) fMoveAngle += Time.deltaTime * 500;
        CheckMoveAnimation();
    }

    private void CheckMoveAnimation()
    {
        if (fMoveAngle < -80) fMoveAngle = -80;
        else if (fMoveAngle > 80) fMoveAngle = 80;
    }

    public bool GetbPlayerMove()
    {
        return bPlayerMove;
    }

    private void Start()
    {
        mUIManager = FindObjectOfType<UIManager>();
        BoomCount = 0;
    }

    private void Update()
    {
        PlayerIdle();

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
