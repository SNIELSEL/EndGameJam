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
            rb.velocity += transform.forward * 100 * Time.deltaTime;
        }

        if (Input.GetKey("s"))
        {
            rb.velocity -= transform.forward * 100 * Time.deltaTime;
        }

        if(Input.GetKey("a") && Input.GetKey("w"))
        {
            transform.Rotate(0, -30 * Time.deltaTime, 0);
            jetskiBody.transform.rotation = Quaternion.Lerp(jetskiBody.transform.rotation, left.rotation, 2 * Time.deltaTime);
            rb.velocity += jetskiBody.transform.forward * 70 * Time.deltaTime;
            rb.velocity -= transform.forward * 70 * Time.deltaTime;
        }

        if(Input.GetKey("d") && Input.GetKey("w"))
        {
            transform.Rotate(0, 30 * Time.deltaTime, 0);
            jetskiBody.transform.rotation = Quaternion.Lerp(jetskiBody.transform.rotation, right.rotation,2 * Time.deltaTime);
            rb.velocity += jetskiBody.transform.forward * 70 * Time.deltaTime;
            rb.velocity -= transform.forward * 70 * Time.deltaTime;
        }


        if(!Input.GetKey("d") && !Input.GetKey("a"))
        {
            jetskiBody.transform.rotation = Quaternion.Lerp(jetskiBody.transform.rotation, straigt.rotation, 2 * Time.deltaTime);
        }
    }

    /* private JetskiInputActions input;
     public Rigidbody rb;
     public GameObject camHold;
     public float speed, sprint;

     private Vector2 move, look;

     private InputAction movew, rotate;
     private float x, y;

     private void Awake()
     {
         input = new JetskiInputActions();
         rb = GetComponent<Rigidbody>();

         Cursor.lockState = CursorLockMode.Locked;
         Cursor.visible = false;
     }

     private void OnEnable()
     {
         movew = input.JetskiMap.Move;
         movew.Enable();


     }

     private void OnDisable()
     {
         movew.Disable();
     }

     private void Update()
     {
         Rotate();
     }

     private void FixedUpdate()
     {
         Move();
     }

     private void Move()
     {
         move = movew.ReadValue<Vector2>() * (speed * Time.deltaTime);

         transform.Translate(move.x, 0, move.y);
     }

     private void Rotate()
     {
         //look = rotate.ReadValue<Vector2>();


         *//*   x += look.x * sens;
            y -= look.y * sens;*//*

         //y = Mathf.Clamp(y, -85, 85);
         transform.LookAt(transform.position, transform.forward);
         //transform.localRotation = Quaternion.Euler(0, x, 0 * Time.deltaTime);
         //camHold.transform.localRotation = Quaternion.Euler(y, 0, 0 * Time.deltaTime);
     }*/
}
