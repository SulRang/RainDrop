using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{

    public static bool BMainActive;

    public void CheckStartBasic()
    {
        GameObject MainGO = GameObject.Find("main");
        MainGO.SetActive(false);
        BMainActive = false;
    }

    private void Awake()
    {
        BMainActive = true;
    }


}
