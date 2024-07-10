using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public PlayFabManager manager;

    public TextMeshProUGUI timertext;
    public TextMeshProUGUI pointText;

    public GameObject HUD;

    public static float time = 60;

    public static int killCount;

    public GameObject gameOverUI;
    public TMP_Text endscore;

    // Update is called once per frame

    private void Start()
    {
        time = 60;
    }
    void Update()
    {
        timertext.text = time.ToString("F2");
        pointText.text = killCount.ToString();

        time -= Time.deltaTime;

        if (time <= 0 && !gameOverUI.activeInHierarchy)
        {
            HUD.SetActive(false);
            time = 0;
            gameOverUI.SetActive(true);
            endscore.SetText(killCount.ToString());
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            manager = GameObject.FindGameObjectWithTag("ConnectionManager").GetComponent<PlayFabManager>();
            manager.SendLeaderBoard(killCount);

        }

    }
}
