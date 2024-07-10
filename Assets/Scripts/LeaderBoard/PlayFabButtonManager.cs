using PlayFab;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayFabButtonManager : MonoBehaviour
{
    public PlayFabManager playFabManager;
    public Transform List;
    public TMP_InputField nameField;
    public GameObject leaderBoard;
    public LeaderBoardHeightAdjuster heightAdjuster;
    public void GetLeaderBoard()
    {
        if (PlayFabClientAPI.IsClientLoggedIn())
        {
            playFabManager.GetLeaderBoard();
        }
        else
        {
            playFabManager.Login(leaderBoard);
        }
    }

    public void SetName()
    {
        //playFabManager.SubmitNameButton();
    }

    public void Login(string sceneName)
    {
        playFabManager.Login(sceneName);
    }

    public void Start()
    {
        Time.timeScale = 1;
    }
}
