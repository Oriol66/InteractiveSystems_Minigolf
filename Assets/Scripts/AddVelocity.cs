using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddVelocity : MonoBehaviour
{

    public Rigidbody rb;
    public float initialForce = 5f; // Initial force
    public float additionalForce = 5f; // Additional force 

    void Start()
    {
        // Aplicar una fuerza hacia adelante al inicio del juego
        rb.AddForce(transform.forward * initialForce, ForceMode.Impulse);
    }
    void AddMoreForce()
    {
        // Añadir una fuerza adicional en la dirección actual de movimiento de la pelota
        rb.AddForce(rb.velocity.normalized*additionalForce, ForceMode.VelocityChange);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Press space for get more velocity
        {
            AddMoreForce();
        }
    }

    
}
