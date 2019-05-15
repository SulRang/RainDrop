using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    private static TutorialManager _instance = null;
    private bool m_bTutorialMode = false;

    public static TutorialManager Instance
    {
        get
        {
            _instance = FindObjectOfType<TutorialManager>();
            return _instance;
        }
    }


    public void TutorialBtn()
    {
        m_bTutorialMode = true;
    }

    public void AvoidArrowTutorial()
    {

    }

    public void ViewArrow()
    {

    }

    public void BombTutorial()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
