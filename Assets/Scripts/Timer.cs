using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timertext;
    public TextMeshProUGUI pointText;

    public static float time = 60;
    public Transform gameOver;

    public static int killCount;


    // Update is called once per frame
    void Update()
    {
        timertext.text = time.ToString("F2");
        pointText.text = killCount.ToString();

        time -= Time.deltaTime;

        if (time <= 0)
        {
            //gameOver.gameObject.SetActive(true);
            Time.timeScale = 0;
        }

    }
}
