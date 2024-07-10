using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayFabButtonManager : MonoBehaviour
{
    public PlayFabManager playFabManager;
    public Transform List;
    public TMP_InputField nameField;
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
