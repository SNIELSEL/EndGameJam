using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Audio;
using static UnityEngine.InputSystem.LowLevel.InputStateHistory;
using TMPro;

public class Jetski : MonoBehaviour
{

    public Rigidbody rb;
    public GameObject jetskiBody;

    public float speed, slipAmmount, turnSpeed, crashTime;

    public TextMeshProUGUI minTime;
    public Animator minTimeAnimation;

    public Transform right, left, straigt;

    //hoi doetsie
    public AudioSource NYOOOOOM;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        minTimeAnimation = GameObject.Find("plus tijd5").GetComponent<Animator>();
        minTime = GameObject.Find("plus tijd5").GetComponent<TextMeshProUGUI>();
    }


    private void Update()
    {
        if(Input.GetKey("w"))
        {
            rb.velocity += transform.forward * speed * Time.deltaTime;
            NYOOOOOM.Play();
        }

        if (Input.GetKey("s"))
        {
            rb.velocity -= transform.forward * speed * Time.deltaTime;
            NYOOOOOM.Play();
        }

        if(Input.GetKey("a") && Input.GetKey("w"))
        {
            transform.Rotate(0, -30 * Time.deltaTime, 0);
            jetskiBody.transform.rotation = Quaternion.Lerp(jetskiBody.transform.rotation, left.rotation, 1.5f * Time.deltaTime);
            rb.velocity += jetskiBody.transform.forward * slipAmmount * Time.deltaTime;
            rb.velocity -= transform.forward * turnSpeed * Time.deltaTime;
            NYOOOOOM.Play();
        }

        if(Input.GetKey("d") && Input.GetKey("w"))
        {
            transform.Rotate(0, 30 * Time.deltaTime, 0);
            jetskiBody.transform.rotation = Quaternion.Lerp(jetskiBody.transform.rotation, right.rotation, 1.5f * Time.deltaTime);
            rb.velocity += jetskiBody.transform.forward * slipAmmount * Time.deltaTime;
            rb.velocity -= transform.forward * turnSpeed * Time.deltaTime;
            NYOOOOOM.Play();
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
            Timer.time -= crashTime;
            minTimeAnimation.SetTrigger("Plus");

            minTime.SetText("-" + crashTime.ToString());
            minTimeAnimation.Play("plustijd5");
            minTimeAnimation.SetTrigger("terug");
        }
    }
}
