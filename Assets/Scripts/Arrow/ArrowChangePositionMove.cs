using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowChangePositionMove : MonoBehaviour
{
    private bool bCanArrowMove;
    private Vector3 target = new Vector3(0f, 0f, 0f);
    private Transform Arrow;
    public float fArrowSpeed;
    private bool bChange = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("DestroyArrow"))
        {
            if (fArrowSpeed >= 5)
                AudioManager.Instance.RandomSoundEffect(AudioManager.Instance.RainCol);
            Destroy(gameObject);
        }
    }

    private void MoveArrow()
    {
        
        float step = fArrowSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, step);
        float angle = GetAngle(transform.position, target);
        Vector3 euler = new Vector3(0f, 0f, angle);
        transform.rotation = Quaternion.Euler(euler);
    }

    void Start()
    {
        
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
        MoveArrow();
    }
    public static float GetAngle(Vector3 vStart, Vector3 vEnd)
    {
        Vector3 v = vEnd - vStart;

        return Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
    }
}
