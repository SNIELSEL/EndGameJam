using PlayFab;
using PlayFab.ClientModels;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayFabManager : MonoBehaviour
{
    [Header("LeaderBoardNameStuff")]
    public TMP_InputField nameField;

    [Header("ScoreBoard")]
    public GameObject rowPrefab;
    public Transform leaderboardTransform;
    public string leaderboardName;

    [Header("eventTriggersOrChecks")]
    public string playername;

    private int id;
    private GameObject[] managers;

    private int currentSceneID;
    // Start is called before the first frame update
    void Start()
    {
        managers = GameObject.FindGameObjectsWithTag("ConnectionManager");

        if (managers.Length != 1)
        {
            for (int i = 0; i < managers.Length; i++)
            {
                if (managers[i] != this.gameObject)
                {
                    if (managers[i].GetComponent<PlayFabManager>().id == 1)
                    {
                        Destroy(gameObject);
                    }
                }
            }
        }
        else
        {
            if(id == 0)
            {
                Debug.Log("Triggerd a Login Task");
                DontDestroyOnLoad(gameObject);

                StartCoroutine(LoginLoop());
            }
        }
    }

    public void Update()
    {
        if (currentSceneID != SceneManager.GetActiveScene().buildIndex) 
        {
            currentSceneID = SceneManager.GetActiveScene().buildIndex;

            if(SceneManager.GetActiveScene().buildIndex == 0)
            {
                nameField = GameObject.FindWithTag("ButtonManager").GetComponent<PlayFabButtonManager>().nameField;
                leaderboardTransform = GameObject.FindWithTag("ButtonManager").GetComponent<PlayFabButtonManager>().List;
                GameObject.FindWithTag("ButtonManager").GetComponent<PlayFabButtonManager>().playFabManager = this;
            }
        }
    }

    IEnumerator LoginLoop()
    {
        if (!PlayFabClientAPI.IsClientLoggedIn())
        {
            Login();
            yield return new WaitForSeconds(5);
            StartCoroutine(LoginLoop());
        }
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

        playername = result.InfoResultPayload.PlayerProfile.DisplayName;

        id++;

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
        PlayerPrefs.SetString("UserName", result.DisplayName);
        
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
        Debug.Log("Triggerd a GetLeaderBoard Task");

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
            if(item.DisplayName != null)
            {
                texts[1].text = item.DisplayName;
            }
            else
            {
                texts[1].text = item.PlayFabId.ToString();
            }
            texts[2].text = item.StatValue.ToString();

            Debug.Log(item.Position + " " + item.PlayFabId + " " + item.StatValue);
        }
    }
}
