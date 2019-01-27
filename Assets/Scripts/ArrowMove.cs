using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMove : MonoBehaviour
{
    public  Vector3 target = new Vector3(0f,0f,0f);
    private Transform Arrow;
    public float speed;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (UIManager.BPauseActive)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target, step);
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
