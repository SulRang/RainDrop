using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ArrowManager : MonoBehaviour
{
    [SerializeField] [Range(0f, 100)] int speed = 10;
    [SerializeField] [Range(0f, 10f)] float radius = 3;

    public int count = 0;
    public GameObject Boom;
    public GameObject[] ArrowType;
    public static int BoomCount;
    public Transform ArrowHolder = null;
    public GameObject ArrowBoard = null;

    public void MakeArrowForBoard()
    {
        ArrowHolder = ArrowBoard.transform;
        float random = Random.Range(0, 100);
        float x = radius * Mathf.Cos(random);
        float y = radius * Mathf.Sin(random);

        GameObject instance = Instantiate(ArrowType[Random.Range(0,ArrowType.Length)], new Vector3(x, y, 0f), Quaternion.identity) as GameObject;
        instance.transform.SetParent(ArrowHolder);
    }


    void Update()
    {
        
        if (!(PauseButton.BPauseActive) && !(StartButton.BMainActive) && Random.Range(0,6) == 5)
        {
            MakeArrowForBoard();
        }
    }

}