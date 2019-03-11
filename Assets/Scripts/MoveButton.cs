using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveButton : MonoBehaviour
{

    public GameManager mGameManager = null;
    
    

    // Start is called before the first frame update
    void Start()
    {
        this.mGameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void MoveLeft()
    {

    }

    public void MoveRight()
    {
        
    }


}
