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
    public GameObject ArrowParent;

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
        yield return new WaitWhile(() => tutorialStep < 5 || !TutorialCheck || !step5);
        NormalArrowTutorial();
        yield return new WaitWhile(() => tutorialStep < 6 || !TutorialCheck || !step6);
        RoundArrowTutorial();
        yield return new WaitWhile(() => tutorialStep < 7 || !TutorialCheck || !step7);
        PositionArrowTutorial();
        yield return new WaitWhile(() => tutorialStep < 8 || !TutorialCheck || !step8);
        StartBombTutorial();
        yield return new WaitWhile(() => tutorialStep < 9 || !TutorialCheck || !step9);
        GetBombTutorial();
        yield return new WaitWhile(() => tutorialStep < 10 || !TutorialCheck || !step10);
        UseBombTutorial();
        yield return new WaitWhile(() => tutorialStep < 11 || !TutorialCheck || !step11);
        LastTutorial();
        yield return new WaitWhile(() => tutorialStep < 12 || !TutorialCheck);
        GameManager.Instance.InGameStart();
        PlayerGO.GetComponent<Player>().PlayerReset();
        Destroy(this.gameObject);
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
        //TutorialText.text = "Welcome To RainDrop!";
        TutorialText.text = "RainDrop 튜토리얼입니다.";
        TutorialImage.sprite = TutorialSprite[tutorialStep];
        TutorialPanel.active = true;
        GameManager.Instance.IsTutorial = false;
        TutorialCheck = false;
        tutorialStep++;
    }

    void StartMoveTutorial()    // step.1
    {
        // Users can move by bursting the screens on the left and right.
        //TutorialText.text = "Users can move by bursting the screens on the left and right.";
        TutorialText.text = "플레이어는 오른쪽과 왼쪽화면을 터치하여 움직일 수 있습니다.";
        TutorialImage.sprite = TutorialSprite[tutorialStep];
        TutorialPanel.active = true;
        TutorialCheck = false;
        GameManager.Instance.IsTutorial = false;
        tutorialStep++;
    }

    void RightMoveTutorial()     // step.2
    {
        // You can move a clockwise direction by touch screen on right;
        //TutorialText.text = "You can move a clockwise direction by touch screen on right, pause right";
        TutorialText.text = "오른쪽화면을 터치하면 플레이어는 시계방향으로 움직입니다.";
        TutorialImage.sprite = TutorialSprite[tutorialStep];
        TutorialPanel.active = true;
        TutorialCheck = false;
        GameManager.Instance.IsTutorial = false;
        tutorialStep++;
    }

    void LeftMoveTutorial()    //step.3
    {
        // You can move a clockwise direction by touch screen on Left;
        //TutorialText.text = "You can move a clockwise direction by touch screen on Left, pause left";
        TutorialText.text = "왼쪽화면을 터치하면 플레이어는 반시계방향으로 움직입니다.";
        TutorialImage.sprite = TutorialSprite[tutorialStep];
        TutorialPanel.active = true;
        TutorialCheck = false;
        GameManager.Instance.IsTutorial = false;
        tutorialStep++;
    }

    void StartArrowTutorial()   //step.4
    {
        // You have to avoid flying drops of water, if you can not avoid it, you die!.
        //ㅆutorialText.text = "You have to avoid flying drops of water, if you can not avoid it, you die!.";
        TutorialText.text = "날아오는 물방울에 맞으면 플레이어는 게임오버됩니다.";
        TutorialImage.sprite = TutorialSprite[tutorialStep];
        TutorialPanel.active = true;
        GameManager.Instance.IsTutorial = false;
        TutorialCheck = false;
        tutorialStep++;
    }

    void NormalArrowTutorial()  //step.5
    {
        TutorialText.text = "기본 물방울은 아무 특징이 없습니다.";
        TutorialImage.sprite = TutorialSprite[tutorialStep];
        TutorialPanel.active = true;
        ArrowManager.Instance.MakeArrowToVector(0, new Vector3(0f, 10f, 0f));
        GameManager.Instance.IsTutorial = false;
        TutorialCheck = false;
        tutorialStep++;
    }

    void SpeedArrowTutorial()   //step.6
    {
        TutorialText.text = "속도가 빠른 물방울은 일정순간에 빨라지고 길어집니다.";
        //TutorialImage.sprite = TutorialSprite[tutorialStep];
        TutorialImage.sprite = TutorialSprite[tutorialStep];
        ArrowManager.Instance.MakeArrowToVector(2, new Vector3(0f, 10f, 0f));
        TutorialPanel.active = true;
        GameManager.Instance.IsTutorial = false;
        TutorialCheck = false;
        tutorialStep++;
    }

    void RoundArrowTutorial()   //step.7
    {
        TutorialText.text = "회전하여 오는 물방울은 회오리모양을 하며 회전하여 날아옵니다.";
        //TutorialImage.sprite = TutorialSprite[tutorialStep];
        TutorialImage.sprite = TutorialSprite[tutorialStep];
        ArrowManager.Instance.MakeArrowToVector(1, new Vector3(0f, 10f, 0f));
        TutorialPanel.active = true;
        GameManager.Instance.IsTutorial = false;
        TutorialCheck = false;
        tutorialStep++;
    }

    void PositionArrowTutorial()    //step.8
    {
        TutorialText.text = "순간이동을 하는 물방울은 일정순간에 사라집니다.";
        //TutorialImage.sprite = TutorialSprite[tutorialStep];
        TutorialImage.sprite = TutorialSprite[tutorialStep];
        ArrowManager.Instance.MakeArrowToVector(3, new Vector3(0f, 10f, 0f));
        TutorialPanel.active = true;
        GameManager.Instance.IsTutorial = false;
        TutorialCheck = false;
        tutorialStep++;
    }

    void StartBombTutorial()        //step.9
    {
        TutorialText.text = "만약에 레벨이 오르면 우산이 생성됩니다.";
        TutorialImage.sprite = TutorialSprite[tutorialStep];
        TutorialPanel.active = true;
        GameManager.Instance.IsTutorial = false;
        TutorialCheck = false;
        tutorialStep++;
    }

    void GetBombTutorial()          //step.10
    {
        TutorialText.text = "우산에 다가가서 우산을 획득하세요.";
        TutorialImage.sprite = TutorialSprite[tutorialStep];
        ArrowManager.Instance.MakeBoom();
        GameManager.Instance.IsTutorial = false;
        TutorialPanel.active = true;
        TutorialCheck = false;
        tutorialStep++;
    }

    void UseBombTutorial()          //step.11
    {
        TutorialText.text = "위험한 순간에 우산을 사용하여 위기를 넘겨보세요.";
        TutorialImage.sprite = TutorialSprite[tutorialStep];
        TutorialPanel.active = true;
        GameManager.Instance.IsTutorial = false;
        for (int i = 0; i < 30; i++)
            ArrowManager.Instance.MakeArrowToSelect(0,10f);
        TutorialCheck = false;
        tutorialStep++;
    }

    void LastTutorial()
    {
        TutorialText.text = "튜토리얼을 끝났습니다. 직접 플레이 보세요!!";
        TutorialImage.sprite = TutorialSprite[tutorialStep];
        TutorialPanel.active = true;
        GameManager.Instance.IsTutorial = false;
        TutorialCheck = false;
        tutorialStep++;
    }

    private void Update()
    {
        if(tutorialStep == 3)
        {
            if (m_Player.bLeft)
                temp += Time.deltaTime;
            if(temp >= 0.75f)
            {
                temp = 0f;
                step3 = true;
            }
        }
        if(tutorialStep == 4)
        {
            if (m_Player.bRight)
                temp += Time.deltaTime;
            if (temp >= 0.75f)
            {
                temp = 0f;
                step4 = true;
            }
        }
        if(tutorialStep == 5)
        {
            if (ArrowParent.transform.childCount == 0)
                step5 = true;
        }
        if(tutorialStep == 6)
        {
            if (ArrowParent.transform.childCount == 0)
                step6 = true;
        }
        if(tutorialStep == 7)
        {
            if (ArrowParent.transform.childCount == 0)
                step7 = true;
        }
        if(tutorialStep == 8)
        {
            if (ArrowParent.transform.childCount == 0)
                step8 = true;
        }
        if (tutorialStep == 8)
        {
            if (ArrowParent.transform.childCount == 0)
                step9 = true;
        }
        if (tutorialStep == 10)
        {
            if (ArrowParent.transform.childCount == 0)
                step10 = true;
        }
        if (tutorialStep == 11)
        {
            if (ArrowParent.transform.childCount == 0)
                step11 = true;
        }
    }
}
