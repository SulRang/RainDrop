using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ArrowManager : MonoBehaviour
{
    [SerializeField] [Range(0f, 100)] int speed = 10;
    [SerializeField] [Range(0f, 10f)] float radius = 3;

    private Transform ArrowHolder = null;
    public static int count = 0;
    public GameObject[] ArrowType;
    public GameObject ArrowBoard;

    public void MakeArrowForBoard()
    {
        ArrowHolder = ArrowBoard.transform;
        float random = Random.Range(0, 100);
        float x = radius * Mathf.Cos(random);
        float y = radius * Mathf.Sin(random);

        GameObject instance = Instantiate(ArrowType[Random.Range(0, ArrowType.Length - 1)], new Vector3(x, y, 0f), Quaternion.identity) as GameObject;
        instance.transform.SetParent(ArrowHolder);
    }


    private void Update()
    {
        count++;
        
        if (!(StartButton.BMainActive) && count != 2)
        {
            MakeArrowForBoard();
            count = 0;
        }
    }

}