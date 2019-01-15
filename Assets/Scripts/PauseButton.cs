using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    public GameObject PauseGO;
    public static bool BPauseActive;

    public void CheckPauseBasic()
    {
        BPauseActive = !BPauseActive;
        PauseGO.SetActive(BPauseActive);
    }

    private void Awake()
    {
        BPauseActive = false;
    }

}
