using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jetski : MonoBehaviour
{
/*    private PlayerActionMap playerActionMap;
    private InputAction move;


    [HideInInspector] public Rigidbody rb;
    [SerializeField] float moveSpeed, normalSpeed;
    [SerializeField] float maxSpeed;

    public Vector3 forceDirection;

    private void Awake()
    {
        playerActionMap = new PlayerActionMap();


        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        normalSpeed = moveSpeed;

        //miss hier alle stats van de player aangeven ofzo
    }

    private void OnEnable()
    {
        move = playerActionMap.Character.Move;
        playerActionMap.Character.Enable();
    }

    private void OnDisable()
    {
        playerActionMap.Character.Disable();
    }

    private void FixedUpdate()
    {
        forceDirection += move.ReadValue<Vector2>().x * moveSpeed;
        forceDirection += move.ReadValue<Vector2>().y * moveSpeed;

        rb.AddForce(forceDirection, ForceMode.Impulse);
        forceDirection = Vector3.zero;


       *//* if (rb.velocity.y < 0)
        {
            if (gliding)
            {
                rb.velocity -= Vector3.down * Physics.gravity.y * 0.1f * Time.fixedDeltaTime;

            }
            else
            {
                rb.velocity -= Vector3.down * Physics.gravity.y * 3.5f * Time.fixedDeltaTime;
            }
        }*//*
        //als ik wil dat je soort van kunt gliden ofzo dan kun je net zoeits doen ^^

        Vector3 horizontalVel = rb.velocity;
        horizontalVel.y = 0;
        if (horizontalVel.sqrMagnitude > maxSpeed * maxSpeed)
        {
            rb.velocity = horizontalVel.normalized * maxSpeed + Vector3.up * rb.velocity.y;
        }
        //LayerMask layerMask = 1 << 9;
    }*/
}
