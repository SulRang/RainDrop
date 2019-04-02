﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowChangeSpeedMove : MonoBehaviour
{
    public Vector3 target = new Vector3(0f, 0f, 0f);
    public float fArrowSpeed;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Respawn"))
        {
            if (fArrowSpeed >= 5)
                AudioManager.Instance.RandomSoundEffect(AudioManager.Instance.RainCol);
            Destroy(this.gameObject);
        }
    }

    private void RandomArrowSpeed(int val)
    {
        fArrowSpeed = Random.Range(2, val);
    }

    private void MoveArrow()
    {
        if (!UIManager.BPauseActive)
            return;
        float step = fArrowSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, step);
        float angle = GetAngle(transform.position, target);
        Vector3 euler = new Vector3(0f, 0f, angle);
        transform.rotation = Quaternion.Euler(euler);
    }

    private void ChangeSpeed()
    {
        fArrowSpeed = 7.5f;
    }

    void Start()
    {
        RandomArrowSpeed(5);
    }

    // Update is called once per frame
    void Update()
    {

        if(Mathf.Abs(this.transform.position.x) <= 5f && Mathf.Abs(this.transform.position.y) <= 3f)
        {
            ChangeSpeed();
        }
        MoveArrow();
        
    }
    public static float GetAngle(Vector3 vStart, Vector3 vEnd)
    {
        Vector3 v = vEnd - vStart;

        return Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
    }
}
