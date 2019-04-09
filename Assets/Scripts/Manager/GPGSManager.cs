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

    public Text stateText;                  // 상태 메세지
    private Action<bool> signInCallback;    // 로그인 성공 여부 확인을 위한 Callback 함수

    void Awake()
    {
        // 안드로이드 빌더 초기화
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.InitializeInstance(config);

        // 구글 플레이 로그를 확인할려면 활성화
        PlayGamesPlatform.DebugLogEnabled = true;

        PlayGamesPlatform.Activate();

        signInCallback = (bool success) =>
        {
            if (success)
            {
                stateText.text = "SignIn Success!";
            }
            else
            {
                stateText.text = "SignIn Fail!";

            }
        };
    }
    // 로그인
    public void Login()
    {
        
        if (PlayGamesPlatform.Instance.IsAuthenticated() == false)
        {

            if (Authenticated || _authenticating)
            {
                Debug.LogWarning("Ignoring repeated call to Authenticate().");
                return;
            }

            _authenticating = true;
            Social.localUser.Authenticate((bool success) =>
            {
                _authenticating = false;
                if (success)
                {
                    Debug.Log("Sign in successful!");
                }
                else
                {
                    Debug.LogWarning("Failed to sign in with Google Play");
                }
            });
            PlayGamesPlatform.Instance.Authenticate(signInCallback);
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

