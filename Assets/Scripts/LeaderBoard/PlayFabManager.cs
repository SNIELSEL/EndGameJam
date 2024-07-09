using PlayFab;
using PlayFab.ClientModels;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayFabManager : MonoBehaviour
{
    [Header("LeaderBoardNameStuff")]
    public GameObject nameWindow;
    public GameObject mainUI;
    public TMP_InputField nameField;

    [Header("ScoreBoard")]
    public GameObject rowPrefab;
    public Transform leaderboardTransform;
    public string leaderboardName;

    [Header("eventTriggersOrChecks")]
    public string playername;

    // Start is called before the first frame update
    void Start()
    {
        Login();
    }

    void Login()
    {
        var request = new LoginWithCustomIDRequest
        {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true,
            InfoRequestParameters = new GetPlayerCombinedInfoRequestParams
            {
                GetPlayerProfile = true
            }
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnLoginSucces, OnError);
    }

    void OnLoginSucces(LoginResult result)
    {
        playername = null;

        if (result.InfoResultPayload.PlayerProfile != null)
        {
            playername = result.InfoResultPayload.PlayerProfile.DisplayName;
        }

        Debug.Log("Logged in Succesfully as" + SystemInfo.deviceUniqueIdentifier);
    }

    public void SubmitNameButton()
    {
        var request = new UpdateUserTitleDisplayNameRequest
        {
            DisplayName = nameField.text
        };
        PlayFabClientAPI.UpdateUserTitleDisplayName(request, OnDisplayNameUpdate, OnError);
    }

    void OnDisplayNameUpdate(UpdateUserTitleDisplayNameResult result)
    {

    }

    public void SendLeaderBoard(int score)
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = leaderboardName,
                    Value = score
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderBoardUpdate, OnError);
    }

    void OnError(PlayFabError error)
    {
        Debug.Log("Couldnt Log In");
        Debug.Log(error.GenerateErrorReport());
    }

    void OnLeaderBoardUpdate(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("Successfull leaderboard sent to " + leaderboardName);
    }

    public void GetLeaderBoard()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = leaderboardName,
            StartPosition = 0,
            MaxResultsCount = 10
        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderBoardGet, OnError);
    }

    void OnLeaderBoardGet(GetLeaderboardResult result)
    {
        foreach (Transform item in leaderboardTransform)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in result.Leaderboard)
        {
            GameObject newRow = Instantiate(rowPrefab, leaderboardTransform);
            TextMeshProUGUI[] texts = newRow.GetComponentsInChildren<TextMeshProUGUI>();

            texts[0].text = (item.Position + 1).ToString();
            texts[1].text = item.DisplayName;
            texts[2].text = item.StatValue.ToString();

            Debug.Log(item.Position + " " + item.PlayFabId + " " + item.StatValue);
        }
    }
}
