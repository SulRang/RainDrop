using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ArrowRoundMove : MonoBehaviour
{
    public Vector3 target = new Vector3(0f, 0f, 0f);
    private Transform Arrow;
    public float speed;
    public float RoundSpeed;
    public float runningtime = 0;
    public float radius = 100;

    void Start()
    {
        if (this.tag.Equals("Arrow"))
            speed = Random.Range(2, 5);
        else
            speed = 2;

        RoundSpeed = 0.5f;
        radius = 10;
        runningtime = Random.Range(0, 100);
    }

    // Update is called once per frame
    void Update()
    {

        if (UIManager.BPauseActive)
        {
            runningtime += RoundSpeed * Time.deltaTime;
            radius -= speed * Time.deltaTime;
            float x = radius * Mathf.Cos(runningtime);
            float y = radius * Mathf.Sin(runningtime);
            transform.position = new Vector3(x, y, 0f); 
            float angle = GetAngle(transform.position, target);
            Vector3 euler = new Vector3(0f, 0f, angle);
            transform.rotation = Quaternion.Euler(euler);
        }
    }
    public static float GetAngle(Vector3 vStart, Vector3 vEnd)
    {
        Vector3 v = vEnd - vStart;

        return Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
    }
}
