using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ArrowManager : MonoBehaviour
{
    [SerializeField] [Range(0f, 100)] private int speed = 10;
    [SerializeField] [Range(0f, 10f)] private float radius = 3;

    public int count = 0;
    public static int Level = 1;
    public GameObject Boom;
    public GameObject[] Arrows;
    public Transform ArrowHolder = null;
    public GameObject ArrowBoard = null;

    public void MakeArrowForBoard()
    {
        ArrowHolder = ArrowBoard.transform;
        float random = Random.Range(0, 100);
        float x = radius * Mathf.Cos(random);
        float y = radius * Mathf.Sin(random);

        GameObject ArrowType = (Random.Range(0, 50) == 5) ? Boom : Arrows[Random.Range(0, Arrows.Length)]; 
            
        GameObject instance = Instantiate(ArrowType, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;
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