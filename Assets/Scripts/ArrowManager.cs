using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ArrowManager : MonoBehaviour
{
    [SerializeField] [Range(0f, 100f)] public float speed = 5f;
    [SerializeField] [Range(0f, 100f)] private float radius = 3f;

    public GameObject Boom;
    public GameObject[] Arrows;
    public Transform ArrowHolder = null;

    private void MakeArrow()
    {
        float random = Random.Range(0, 100);
        float x = radius * Mathf.Cos(random);
        float y = radius * Mathf.Sin(random);
            
        GameObject instance = Instantiate(Arrows[Random.Range(0, Arrows.Length)], new Vector3(x, y, 0f), Quaternion.identity) as GameObject;
        instance.transform.SetParent(ArrowHolder);
    }

    private void MakeBoom()
    {
        float random = Random.Range(0, 100);
        float x = radius * Mathf.Cos(random);
        float y = radius * Mathf.Sin(random);

        GameObject instance = Instantiate(Boom, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;
        instance.transform.SetParent(ArrowHolder);
    }

    private void Awake()
    {
    }

    private void Update()
    {
        if (!(StartButton.BMainActive) && !(PauseButton.BPauseActive) && Random.Range(0, (int)speed) == 0)
            MakeArrow();   
    }
}