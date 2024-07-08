using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Jetski : MonoBehaviour
{

    public Rigidbody rb;
    public GameObject jetskiBody;

    public float speed;


    public Transform right, left, straigt;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();


        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    private void Update()
    {
        if(Input.GetKey("w"))
        {
            rb.velocity += transform.forward * 60 * Time.deltaTime;
        }

        if (Input.GetKey("s"))
        {
            rb.velocity -= transform.forward * 60 * Time.deltaTime;
        }

        if(Input.GetKey("a") && Input.GetKey("w"))
        {
            transform.Rotate(0, -30 * Time.deltaTime, 0);
            jetskiBody.transform.rotation = Quaternion.Lerp(jetskiBody.transform.rotation, left.rotation, 1.5f * Time.deltaTime);
            rb.velocity += jetskiBody.transform.forward * 45 * Time.deltaTime;
            rb.velocity -= transform.forward * 30 * Time.deltaTime;
        }

        if(Input.GetKey("d") && Input.GetKey("w"))
        {
            transform.Rotate(0, 30 * Time.deltaTime, 0);
            jetskiBody.transform.rotation = Quaternion.Lerp(jetskiBody.transform.rotation, right.rotation, 1.5f * Time.deltaTime);
            rb.velocity += jetskiBody.transform.forward * 45 * Time.deltaTime;
            rb.velocity -= transform.forward * 30 * Time.deltaTime;
        }


        if(!Input.GetKey("d") && !Input.GetKey("a"))
        {
            jetskiBody.transform.rotation = Quaternion.Lerp(jetskiBody.transform.rotation, straigt.rotation, 1.5f * Time.deltaTime);
        }
    }
}
