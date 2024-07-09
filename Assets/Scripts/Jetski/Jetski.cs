using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Audio;

public class Jetski : MonoBehaviour
{

    public Rigidbody rb;
    public GameObject jetskiBody;

    public float speed, crashTime;


    public Transform right, left, straigt;

    //hoi doetsie
    public AudioSource NYOOOOOM;

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
            rb.velocity += transform.forward * speed * Time.deltaTime;
            NYOOOOOM.Play();
            print("saka");
        }

        if (Input.GetKey("s"))
        {
            rb.velocity -= transform.forward * speed * Time.deltaTime;
            NYOOOOOM.Play();
            print("bam");
        }

        if(Input.GetKey("a") && Input.GetKey("w"))
        {
            transform.Rotate(0, -30 * Time.deltaTime, 0);
            jetskiBody.transform.rotation = Quaternion.Lerp(jetskiBody.transform.rotation, left.rotation, 1.5f * Time.deltaTime);
            rb.velocity += jetskiBody.transform.forward * 45 * Time.deltaTime;
            rb.velocity -= transform.forward * 30 * Time.deltaTime;
            NYOOOOOM.Play();
            print("bas");
        }

        if(Input.GetKey("d") && Input.GetKey("w"))
        {
            transform.Rotate(0, 30 * Time.deltaTime, 0);
            jetskiBody.transform.rotation = Quaternion.Lerp(jetskiBody.transform.rotation, right.rotation, 1.5f * Time.deltaTime);
            rb.velocity += jetskiBody.transform.forward * 45 * Time.deltaTime;
            rb.velocity -= transform.forward * 30 * Time.deltaTime;
            NYOOOOOM.Play();
            print("pis");
        }


        if(!Input.GetKey("d") && !Input.GetKey("a"))
        {
            jetskiBody.transform.rotation = Quaternion.Lerp(jetskiBody.transform.rotation, straigt.rotation, 1.5f * Time.deltaTime);
  
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            if(rb.velocity.magnitude > 20)
            {
                Timer.time -= crashTime;
            }
        }
    }
}
