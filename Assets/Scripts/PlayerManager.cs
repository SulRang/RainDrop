using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    private UIManager resultFnc;
    public GameObject ArrowBoard = null;
    public static int BoomCount = 0;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Arrow")
        {
            if (ScoreManager.CScore >= PlayerPrefs.GetFloat("BEST", 0))
            {
                PlayerPrefs.SetFloat("BEST", ScoreManager.CScore);
            }
            UIManager.BPauseActive = false;
            resultFnc.Result();
        }
        if (col.gameObject.tag.Equals("Item"))
        {
            BoomCount++;
            Destroy(col.gameObject);
        }
    }

    public void ActiveBoom()
    {
        if (BoomCount > 0)
        {
            BoomCount--;
            foreach (Transform child in ArrowBoard.transform)
            {
                AudioManager.Instance.RandomSoundEffect(AudioManager.Instance.Bomb);

                if (child.tag == "Arrow")
                    Destroy(child.gameObject);
            }
        }
    }

    private void Start()
    {
        resultFnc = FindObjectOfType<UIManager>();

        BoomCount = 0;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) == true && BoomCount > 0)
            ActiveBoom();
    }
}
