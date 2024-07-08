using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float time = 60;
    public Transform gameOver;


    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;

        if (time <= 0)
        {
            gameOver.gameObject.SetActive(true);
            Time.timeScale = 0;

        }

    }
}
