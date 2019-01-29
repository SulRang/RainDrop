using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveByTouch : MonoBehaviour
{

    public float speed = 2f;
    public float radius = 1.5f;

    private bool bLeft = false;
    private bool bRight = false;
    private bool bMovePlayer = false;
    private float runningTime = 0f;
    private Vector3 newPos = new Vector3();

    public float x = 0f;
    public float y = 1f;

    // Start is called before the first frame update
    void Start()
    {
        bLeft = false;
        bRight = false;
        bMovePlayer = false;
        runningTime = 0;
        speed = 5;
        radius = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Vector2 pos = Input.GetTouch(0).position;
            Vector3 theTouch = new Vector3(pos.x, pos.y, 0f);

            Ray ray = Camera.main.ScreenPointToRay(theTouch);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit, Mathf.Infinity))
            {
                if(Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    if(theTouch.x > 0)
                        bRight = true;
                    else if (theTouch.x < 0)
                        bLeft = true;
                }
                else if(Input.GetTouch(0).phase == TouchPhase.Moved)
                {
                    if(bRight)
                    {
                        runningTime += Time.deltaTime * speed;
                        x = radius * Mathf.Cos(runningTime);
                        y = radius * Mathf.Sin(runningTime);
                        newPos = new Vector3(x, y, 0f);
                        this.transform.position = newPos;
                    }
                    if(bLeft)
                    {
                        runningTime -= Time.deltaTime * speed;
                        x = radius * Mathf.Cos(runningTime);
                        y = radius * Mathf.Sin(runningTime);
                        newPos = new Vector3(x, y, 0f);
                        this.transform.position = newPos;
                    }
                    this.transform.position = newPos;
                }
                else if(Input.GetTouch(0).phase == TouchPhase.Ended)
                {
                    bRight = false;
                    bLeft = false;
                }
            }

        }

        if(bMovePlayer && bRight)
        {
            runningTime += Time.deltaTime * speed;
            x = radius * Mathf.Cos(runningTime);
            y = radius * Mathf.Sin(runningTime);
            newPos = new Vector3(x, y, 0f);
        }
        if(bMovePlayer && bLeft)
        {
            runningTime -= Time.deltaTime * speed;
            x = radius * Mathf.Cos(runningTime);
            y = radius * Mathf.Sin(runningTime);
            newPos = new Vector3(x, y, 0f);
        }

        this.transform.position = newPos;

    }
}
