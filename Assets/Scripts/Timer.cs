using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timertext;

    public float time = 60;
    public Transform gameOver;


    // Update is called once per frame
    void Update()
    {
        timertext.text = time.ToString("F2");

        time -= Time.deltaTime;

        if (time <= 0)
        {
            //gameOver.gameObject.SetActive(true);
            Time.timeScale = 0;
        }

    }
}
