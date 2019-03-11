using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ArrowManager : MonoBehaviour
{
    [SerializeField] [Range(0f, 100f)] public float speed = 50f;
    [SerializeField] [Range(0f, 100f)] private float radius = 3f;

    private static ArrowManager _instance = null;


    public GameObject Boom;

    public GameObject[] Arrows;
    private Transform ArrowHolder = null;

    private int count = 0;

    public static ArrowManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType(typeof(ArrowManager)) as ArrowManager;

                if (_instance == null)
                    Debug.Log("ArrowManager is nowhere");
            }
            return _instance;
        }
    }

    public void MakeArrow()
    {
        float random = Random.Range(0, 100);
        float x = radius * Mathf.Cos(random);
        float y = radius * Mathf.Sin(random);

        int ArrowIndex = Random.Range(0, (Arrows.Length > LevelManager.Instance.gameLevel - 1) ? LevelManager.Instance.gameLevel : Arrows.Length);

        try
        {
            GameObject instance = Instantiate(Arrows[ArrowIndex], new Vector3(x, y, 0f), Quaternion.identity);
            instance.transform.SetParent(ArrowHolder);
        }
        catch (NullReferenceException ex)
        {
            Debug.Log(ex.ToString());
        }
    }

    public void MakeBoom()
    {
        ArrowHolder = ArrowBoard.transform;
        float random = Random.Range(0, 100);
        float x = radius * Mathf.Cos(random);
        float y = radius * Mathf.Sin(random);

        GameObject Object = Instantiate(Boom, new Vector3(x, y, 0f), Quaternion.identity);
        Object.transform.SetParent(ArrowHolder);
    }

    public void SpawnArrow()
    {

        if (count >= 100 / LevelManager.Instance.gameLevel)
        {
            count = 0;
            MakeArrow();
        }
        count++;
    }

    private void Awake()
    {
        ArrowHolder = GameObject.Find("ArrowParent").transform;

    }

    private void Update()
    {
        
    }

}