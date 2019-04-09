using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ArrowRoundMove : MonoBehaviour
{
    public Vector3 vTarget = new Vector3(0f, 0f, 0f);
    public float fArrowSpeed = 2;
    public float RoundSpeed = 0.5f;
    public float fNowAngle = 0;
    public float fRandius = 10f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("DestroyArrow"))
        {
            if (fArrowSpeed >= 5)
                AudioManager.Instance.RandomSoundEffect(AudioManager.Instance.RainCol);
            Destroy(gameObject);
        }
    }

    private void RandomArrowSpeed(int val)
    {
        fArrowSpeed = Random.Range(2, val);
        fRandius = 10f;
    }

    private void CheckAngle()
    {
        fNowAngle = Random.Range(0f, 100f);
        //fNowAngle = Mathf.Atan2(transform.position.y, transform.position.x) * Mathf.Rad2Deg;
    }

    public float GetAngle(Vector3 vStart, Vector3 vEnd)
    {
        Vector3 v = vEnd - vStart;

        return Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
    }

    private void MoveArrow()
    {
        if (!GameManager.Instance.IsInGame)
            return;

        fNowAngle += RoundSpeed * Time.deltaTime;
        fRandius -= fArrowSpeed * Time.deltaTime;
        float x = fRandius * Mathf.Cos(fNowAngle);
        float y = fRandius * Mathf.Sin(fNowAngle);
        transform.position = new Vector3(x, y, 0f);
        float angle = GetAngle(transform.position, vTarget);
        Vector3 euler = new Vector3(0f, 0f, angle);
        transform.rotation = Quaternion.Euler(euler);
    }

    void Start()
    {
        RandomArrowSpeed(5);
        CheckAngle();
    }

    // Update is called once per frame
    void Update()
    {
        MoveArrow();
    }
}
