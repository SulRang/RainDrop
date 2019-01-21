using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ArrowManager : MonoBehaviour
{
    [SerializeField] [Range(0f, 100)] private int speed = 5;
    [SerializeField] [Range(0f, 10f)] private float radius = 3;

    public int count = 0;
    public static int Level = 1;
    public GameObject Boom;
    public GameObject[] Arrows;
    private Transform ArrowHolder = null;

    public void MakeArrowForBoard()
    {
        float random = Random.Range(0, 100);
        float x = radius * Mathf.Cos(random);
        float y = radius * Mathf.Sin(random);

        GameObject ArrowType = (Random.Range(0, 25) == 5) ? Boom : Arrows[Random.Range(0, Arrows.Length)]; 
            
        GameObject instance = Instantiate(ArrowType, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;
        instance.transform.SetParent(ArrowHolder);
    }

    private void Awake()
    {
        ArrowHolder = GameObject.Find("Canvas/ingame/ArrowParent").transform;
    }

    private void Update()
    {
        
        if (!(PauseButton.BPauseActive) && !(StartButton.BMainActive) && Random.Range(0,speed) == 0)
        {
            MakeArrowForBoard();
        }
    }

}