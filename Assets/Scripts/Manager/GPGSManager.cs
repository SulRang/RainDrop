using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class GPGSManager : MonoBehaviour

{

    //싱글톤 패턴
    private static GPGSManager _instance;

    public static GPGSManager Instance
    {
        get
        {
            if (_instance == null) _instance = FindObjectOfType<GPGSManager>() as GPGSManager;
            return _instance;
        }
    }

    private bool _authenticating = false;
    public bool Authenticated { get { return Social.Active.localUser.authenticated; } }

    //achievement increments we are accumulating locally, waiting to send to the games API
    private Dictionary<string, int> _pendingIncrements = new Dictionary<string, int>();

    //GooglePlayGames 초기화
    public void Initialize()
    {
        //PlayGamesPlatform 로그 활성화/비활성화
        PlayGamesPlatform.DebugLogEnabled = false;
        //Social.Active 초기화
        PlayGamesPlatform.Activate();
    }

    void Awake()
    {
        // 안드로이드 빌더 초기화
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.InitializeInstance(config);

        // 구글 플레이 로그를 확인할려면 활성화
        PlayGamesPlatform.DebugLogEnabled = true;

        PlayGamesPlatform.Activate();
        
    }
    // 로그인
    public void Login()
    {
        if (PlayGamesPlatform.Instance.IsAuthenticated() == false)
        {
            Social.localUser.Authenticate((bool success) =>
            {
                if (success)
                {
                    Debug.Log("Sign in successful!");
                }
                else
                {
                    Debug.LogWarning("Failed to sign in with Google Play");
                }
            });
        }
        else
        {
            PlayGamesPlatform.Instance.SignOut();
        }
    }
    public void ShowLeaderboardUI()
    {
        if (Authenticated)
        {
            Social.ShowLeaderboardUI();
        }
    }
}

