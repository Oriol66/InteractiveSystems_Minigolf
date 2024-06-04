using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Rigidbody rb;
    public float velocity = 5f;
    

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical"); 

        //Movement through axes X and Z
        Vector3 movimiento = new Vector3(-horizontal, 0f, -vertical); //

        //Apply a force to the rigidbody
        rb.AddForce(movimiento * velocity); 
    }
}