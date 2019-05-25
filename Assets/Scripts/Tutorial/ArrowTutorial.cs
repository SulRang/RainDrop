using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowTutorial : MonoBehaviour
{
    public GameObject m_Player;
    public GameObject[] m_Arrows;
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

    private void ArrowSpeedChanage()
    {
        m_Arrows[0].GetComponent<ArrowMove>().fArrowSpeed = 2;
        m_Arrows[1].GetComponent<ArrowMove>().fArrowSpeed = 2;
        m_Arrows[2].GetComponent<ArrowChangePositionMove>().fArrowSpeed = 2;
        m_Arrows[3].GetComponent<ArrowChangeSpeedMove>().fArrowSpeed = 2;
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

    private void ArrowMoveTutorial()
    {
        if (m_Arrows[0].transform.position.y < 4)
            m_Check = true;
        
        if (m_Check)
        {
            Chapter++;
            m_Check = false;
            MessageBoxOpen();
        }
    }

    private void DestroyTutorial()
    {
        if (m_Arrows[0].transform.position.y < 1)
            m_Check = true;

        if (m_Check)
        {
            Chapter++;
            m_Check = false;
            MessageBoxOpen();
        }
    }

    private void ArrowKindTutorial()
    {
        if (Chapter == 5) return;
        if (m_Arrows[Chapter - 1].transform.position.y < 4)
            m_Check = true;

        if (m_Check)
        {
            Chapter++;
            m_Check = false;
            MessageBoxOpen();
            if(m_Arrows[3].transform.position.y < 4)
                Invoke("OpenResult", 2);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        TutorialManager.Instance.TutorialMode = true;
        Invoke("ArrowSpeedChanage", 2);
    }

    // Update is called once per frame
    void Update()
    {
        if (!m_Start) return;
        if (Chapter == 0) ArrowMoveTutorial();
        if (Chapter == 1) { DestroyTutorial();}
        if (Chapter > 1) ArrowKindTutorial();
    }
}
