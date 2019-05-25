using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombTutorial : MonoBehaviour
{
    public GameObject m_Player;
    public GameObject m_Bomb;
    public bool m_Start = false;
    public bool m_Check = false;
    public string[] m_Message;
    public Sprite[] m_Sprites;
    public Image ImageBox;
    public Text MessageBox;
    public GameObject Box;
    public int Chapter = 0;
    public GameObject Result;
    private float m_RunningTime = 0;

    public void StartButton()
    {
        TutorialManager.Instance.TutorialCheck = false;
        GameManager.Instance.IsInGame = true;
        Box.active = false;
        m_Start = true;
    }

    private void OpenResult()
    {
        TutorialManager.Instance.TutorialCheck = true;
        GameManager.Instance.IsInGame = false;
        Result.active = true;
    }

    private void MessageBoxOpen()
    {
        TutorialManager.Instance.TutorialCheck = true;
        GameManager.Instance.IsInGame = false;
        if (Chapter == m_Message.Length)
        {
            OpenResult();
            return;
        }
        Box.active = true;
        ImageBox.sprite = m_Sprites[Chapter];
        MessageBox.text = m_Message[Chapter];
    }

    private void BombMoveTutorial()
    {
        if (Player_tutorial.BoomCount != 0)
            m_Check = true;
        
        if (m_Check)
        {
            Chapter++;
            m_Check = false;
            MessageBoxOpen();
            for (int i = 0; i < 60; i++)
                ArrowManager.Instance.MakeArrowToSelect(0);
            Invoke("OpenResult", 3f);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        TutorialManager.Instance.TutorialMode = true;
        Invoke("MessageBoxOpen", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (!m_Start) return;
        if (Chapter == 0) BombMoveTutorial();
    }
}
