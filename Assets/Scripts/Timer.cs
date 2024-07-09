using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timertext;
    public TextMeshProUGUI pointText;

    public static float time = 60;

    public static int killCount;

    public GameObject gameOverUI;
    public TMP_Text endscore;


    // Update is called once per frame
    void Update()
    {
        timertext.text = time.ToString("F2");
        pointText.text = killCount.ToString();

        time -= Time.deltaTime;

        if (time <= 0)
        {
            PlayFabManager.SendLeaderBoard(killCount);
            gameOverUI.SetActive(true);
            endscore.SetText(killCount.ToString());
            Time.timeScale = 0;

        }

    }
}
