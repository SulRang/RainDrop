using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public int tutorialStep = 0;
    public float temp = 0f;

    public Sprite[] TutorialSprite;

    public GameObject TutorialPanel;
    public Image TutorialImage;
    public Text TutorialText;
    public bool TutorialCheck = false;

    public GameObject GamemanagerGO;
    public GameObject PlayerGO;

    private ArrowManager m_ArrowManager;
    private Player m_Player;

    private bool step2 = false;
    private bool step3 = false;
    private bool step4 = false;
    private bool step5 = false;
    private bool step6 = false;
    private bool step7 = false;
    private bool step8 = false;
    private bool step9 = false;
    private bool step10 = false;
    private bool step11 = false;

    // Start is called before the first frame update
    void Start()
    {
        TutorialCheck = false;
        m_ArrowManager = GamemanagerGO.GetComponent<ArrowManager>();
        m_Player = PlayerGO.GetComponent<Player>();
        StartCoroutine(TutorialStart());
    }

    public void Step2Button()
    {
        step2 = true;
    }

    IEnumerator TutorialStart()
    {
        StartTutorial();
        yield return new WaitWhile(() => tutorialStep < 1 || !TutorialCheck);       // false 여야  지나갈 수 있다 따라서 true값을 넣어주면 못지나간다.
        StartMoveTutorial();
        yield return new WaitWhile(() => tutorialStep < 2 || !TutorialCheck);
        RightMoveTutorial();
        yield return new WaitWhile(() => tutorialStep < 3 || !TutorialCheck || !step3);
        LeftMoveTutorial();
        yield return new WaitWhile(() => tutorialStep < 4 || !TutorialCheck || !step4);
        StartArrowTutorial();
        yield return new WaitWhile(() => tutorialStep < 5 || !TutorialCheck);
        NormalArrowTutorial();
        yield return new WaitWhile(() => tutorialStep < 6 || !TutorialCheck);
        RoundArrowTutorial();
        yield return new WaitWhile(() => tutorialStep < 7 || !TutorialCheck);
        PositionArrowTutorial();
        yield return new WaitWhile(() => tutorialStep < 8 || !TutorialCheck);
        StartBombTutorial();
        yield return new WaitWhile(() => tutorialStep < 9 || !TutorialCheck);
        GetBombTutorial();
        yield return new WaitWhile(() => tutorialStep < 10 || !TutorialCheck);
        UseBombTutorial();
        yield return new WaitWhile(() => tutorialStep < 11 || !TutorialCheck);
        GameManager.Instance.InGameStart();
    }

    public void SkipButton()
    {
        UIManager.Instance.HomeBnt();
    }

    public void NextButton()
    {
        GameManager.Instance.IsTutorial = true;
        TutorialCheck = true;
    }

    void StartTutorial()        // step.0
    {
        // Welcome To RainDrop!
        TutorialText.text = "Welcome To RainDrop!";
        TutorialImage.sprite = TutorialSprite[tutorialStep];
        TutorialPanel.active = true;
        GameManager.Instance.IsTutorial = false;
        TutorialCheck = false;
        tutorialStep++;
    }

    void StartMoveTutorial()    // step.1
    {
        // Users can move by bursting the screens on the left and right.
        TutorialText.text = "Users can move by bursting the screens on the left and right.";
        TutorialImage.sprite = TutorialSprite[tutorialStep];
        TutorialPanel.active = true;
        TutorialCheck = false;
        GameManager.Instance.IsTutorial = false;
        tutorialStep++;
    }

    void RightMoveTutorial()     // step.2
    {
        // You can move a clockwise direction by touch screen on right;
        TutorialText.text = "You can move a clockwise direction by touch screen on right, pause right";
        TutorialImage.sprite = TutorialSprite[tutorialStep];
        TutorialPanel.active = true;
        TutorialCheck = false;
        GameManager.Instance.IsTutorial = false;
        tutorialStep++;
    }

    void LeftMoveTutorial()    //step.3
    {
        // You can move a clockwise direction by touch screen on Left;
        TutorialText.text = "You can move a clockwise direction by touch screen on Left, pause left";
        TutorialImage.sprite = TutorialSprite[tutorialStep];
        TutorialPanel.active = true;
        TutorialCheck = false;
        GameManager.Instance.IsTutorial = false;
        tutorialStep++;
    }

    void StartArrowTutorial()   //step.4
    {
        // You have to avoid flying drops of water, if you can not avoid it, you die!.
        TutorialText.text = "You have to avoid flying drops of water, if you can not avoid it, you die!.";
        TutorialImage.sprite = TutorialSprite[tutorialStep];
        TutorialPanel.active = true;
        GameManager.Instance.IsTutorial = false;
        TutorialCheck = false;
        tutorialStep++;
    }

    void NormalArrowTutorial()  //step.5
    {
        TutorialText.text = "Normal drops of water has white color";
        TutorialImage.sprite = TutorialSprite[tutorialStep];
        TutorialPanel.active = true;
        GameManager.Instance.IsTutorial = false;
        TutorialCheck = false;
        tutorialStep++;
    }

    void SpeedArrowTutorial()   //step.6
    {
        TutorialText.text = "Normal drops of water has white color";
        //TutorialImage.sprite = TutorialSprite[tutorialStep];
        TutorialImage.sprite = TutorialSprite[tutorialStep];
        TutorialPanel.active = true;
        GameManager.Instance.IsTutorial = false;
        TutorialCheck = false;
        tutorialStep++;
    }

    void RoundArrowTutorial()   //step.7
    {
        TutorialText.text = "Normal drops of water has white color";
        //TutorialImage.sprite = TutorialSprite[tutorialStep];
        TutorialImage.sprite = TutorialSprite[tutorialStep];
        TutorialPanel.active = true;
        GameManager.Instance.IsTutorial = false;
        TutorialCheck = false;
        tutorialStep++;
    }

    void PositionArrowTutorial()    //step.8
    {
        TutorialText.text = "Normal drops of water has white color";
        //TutorialImage.sprite = TutorialSprite[tutorialStep];
        TutorialImage.sprite = TutorialSprite[tutorialStep];
        TutorialPanel.active = true;
        GameManager.Instance.IsTutorial = false;
        TutorialCheck = false;
        tutorialStep++;
    }

    void StartBombTutorial()        //step.9
    {
        TutorialText.text = "Normal drops of water has white color";
        //TutorialImage.sprite = TutorialSprite[tutorialStep];
        TutorialImage.sprite = TutorialSprite[tutorialStep];
        TutorialPanel.active = true;
        GameManager.Instance.IsTutorial = false;
        TutorialCheck = false;
        tutorialStep++;
    }

    void GetBombTutorial()          //step.10
    {
        TutorialText.text = "Normal drops of water has white color";
        //TutorialImage.sprite = TutorialSprite[tutorialStep];
        TutorialPanel.active = true;
        TutorialCheck = false;
        tutorialStep++;
    }

    void UseBombTutorial()          //step.11
    {
        TutorialText.text = "Normal drops of water has white color";
        //TutorialImage.sprite = TutorialSprite[tutorialStep];
        TutorialPanel.active = true;
        TutorialCheck = false;
        tutorialStep++;
        GameManager.Instance.InGameStart();
    }

    private void Update()
    {
        if(tutorialStep == 3)
        {
            if (m_Player.bLeft)
                temp += Time.deltaTime;
            if(temp >= 0.5f)
            {
                temp = 0f;
                step3 = true;
            }
        }
        if(tutorialStep == 4)
        {
            if (m_Player.bRight)
                temp += Time.deltaTime;
            if (temp >= 0.5f)
            {
                temp = 0f;
                step4 = true;
            }
        }
        if(tutorialStep == 6)
        {

        }
    }
}
