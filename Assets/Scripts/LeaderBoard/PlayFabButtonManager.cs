using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayFabButtonManager : MonoBehaviour
{
    public PlayFabManager playFabManager;
    public Transform List;
    public void GetLeaderBoard()
    {
        playFabManager.GetLeaderBoard();
    }

    public void SetName()
    {
        playFabManager.SubmitNameButton();
    }

    public void Start()
    {
        Time.timeScale = 1;
    }
}
