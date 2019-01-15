using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowepicMove : MonoBehaviour
{
    public Vector3 target = new Vector3(0f, 0f, 0f);
    public GameObject MyArrow;
    private Transform Arrow;
    public float speed = 3;
    public float radius;
    public float runningtime = 0;
    public bool turn;
    public float angle;

    void Start()
    {
        angle = GetAngle(transform.position, target);
        radius = 10;
        turn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseButton.BPauseActive)
        {
            float step = speed * Time.deltaTime;
            radius -= speed * Time.deltaTime;
            runningtime = GetAngle(transform.position, target);
            if(turn)
                runningtime += Time.deltaTime * 0.05f;
            else    
                runningtime -= Time.deltaTime * 0.05f;

            if(runningtime > angle + 0.05f)
            {
                turn = !turn;
            }
            if(runningtime < angle - 0.05f)
            {
                turn = !turn;
            }
            float x = radius * Mathf.Cos(runningtime / 1000);
            float y = radius * Mathf.Sin(runningtime / 1000);
            MyArrow.transform.position = new Vector3(x, y, 0f);
        }
    }
    public static float GetAngle(Vector3 vStart, Vector3 vEnd)
    {
        Vector3 v = vEnd - vStart;

        return Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
    }
}
