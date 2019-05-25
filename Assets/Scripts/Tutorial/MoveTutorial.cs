using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveTutorial : MonoBehaviour
{
    public GameObject m_Player;
    private bool m_Start = false;
    public bool m_Check = false;
    public string[] m_Message;
    public Text MessageBox;
    public GameObject Box;
    public int Chapter = 0;
    public GameObject Result;
    private float m_RunningTime = 0;
    public Sprite[] m_Sprites;
    public Image ImageBox;

    public void StartButton()
    {
        TutorialManager.Instance.TutorialCheck = false;
        m_Start = true;
    }

    private void MessageBoxOpen()
    {

        TutorialManager.Instance.TutorialCheck = true;
        if (Chapter == m_Message.Length)
        {
            Result.active = true;
            return;
        }
        Box.active = true;
        ImageBox.sprite = m_Sprites[Chapter];
        MessageBox.text = m_Message[Chapter];
    }

    private void Right_Tutorial()
    {
        if (m_Player.GetComponent<Player_tutorial>().bRight)
            m_Check = true;
        
        if (m_Check)
        {
            Chapter++;
            m_Check = false;
            Invoke("MessageBoxOpen", 1);

        }
    }

    private void Left_Tutorial()
    {
        if (m_Player.GetComponent<Player_tutorial>().bLeft)
            m_Check = true;

        if (m_Check)
        {
            Chapter++;
            m_Check = false;
            Invoke("MessageBoxOpen", 1);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Invoke("MessageBoxOpen", 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (!m_Start) return;
        if (Chapter == 0) Right_Tutorial();
        if (Chapter == 1) {Left_Tutorial();}
    }
}
