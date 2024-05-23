using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Rigidbody rb;
    public float velocity = 5f;
    
    void Start()
    {


    }


    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");


        Vector3 movimiento = new Vector3(-horizontal, 0f, -vertical);

        rb.AddForce(movimiento * velocity);
    }
}