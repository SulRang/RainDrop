﻿using System;
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
    private List<GameObject> ArrowTable;

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

    public GameObject RandomArrow()
    {
        int index = (LevelManager.Instance.gameLevel >= Arrows.Length) ? Arrows.Length - 1 : LevelManager.Instance.gameLevel - 1;
        return Arrows[index];
    }

    public void MakeArrow()
    {
        float random = Random.Range(0, 100);
        float x = radius * Mathf.Cos(random);
        float y = radius * Mathf.Sin(random);

        try
        {
            GameObject instance = Instantiate(RandomArrow(), new Vector3(x, y, 0f), Quaternion.identity);
            instance.transform.SetParent(ArrowHolder);
        }
        catch (NullReferenceException ex)
        {
            Debug.Log(ex.ToString());
        }
    }

    public void MakeBoom()
    {
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

    
}