using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowChangePositionMove : MonoBehaviour
{
    private Vector3 target = new Vector3(0f, 0f, 0f);
    public float fArrowSpeed = 3;
    private bool bChange = true;
    private Animator animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Respawn"))
        {
            if (fArrowSpeed >= 5)
                AudioManager.Instance.RandomSoundEffect(AudioManager.Instance.RainCol);
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Active")
        {
            float x = this.transform.position.x;
            float y = this.transform.position.y;
            transform.position = new Vector3((-1) * x, (-1) * y, 5f);
            animator.speed = 1.5f;
        }
    }

    private void nCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Active")
        {
            float x = this.transform.position.x;
            float y = this.transform.position.y;
            transform.position = new Vector3((-1) * x, (-1) * y, 5f);
        }
    }

    private void RandomArrowSpeed(int val)
    {
        fArrowSpeed = Random.Range(2, val);
    }

    private void MoveArrow()
    {
        if (!GameManager.Instance.IsInGame && !GameManager.Instance.IsTutorial)
            return;

        float step = fArrowSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, step);
        float angle = GetAngle(transform.position, target);
        Vector3 euler = new Vector3(0f, 0f, angle);
        transform.rotation = Quaternion.Euler(euler);
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        RandomArrowSpeed(4);
        animator.speed = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        MoveArrow();
    }
    public static float GetAngle(Vector3 vStart, Vector3 vEnd)
    {
        Vector3 v = vEnd - vStart;

        return Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
    }
}
