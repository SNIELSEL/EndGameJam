using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float time = 60;
    

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;


    }
}
