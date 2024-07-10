using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timeh : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Clusterfuck", 5.0f, 0.025f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Clusterfuck ()     
    {
        Vector3 scale = new Vector3(Random.Range(0f, 10f), Random.Range(0f, 10f), Random.Range(0f,10f));
        transform.localScale = scale;   
    }
}
