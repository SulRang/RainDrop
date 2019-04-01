using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowChangePositionMove : MonoBehaviour
{
    private Vector3 target = new Vector3(0f, 0f, 0f);
    private Transform Arrow;
    public float speed;
    private bool bChange = true;

    void Start()
    {
        if (this.tag.Equals("Arrow"))
            speed = Random.Range(2, 5);
        else
            speed = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(this.transform.position.x) <= 5f && Mathf.Abs(this.transform.position.y) <= 3f && bChange)
        {
            float x = this.transform.position.x;
            float y = this.transform.position.y;

            transform.position = new Vector3((-1) * x, (-1) * y, 0f);

            bChange = false;
        }


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
