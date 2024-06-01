using UnityEngine;
using System.Collections.Generic;

public class Driver : MonoBehaviour
{
    private Queue<Vector3> previousPositions = new Queue<Vector3>();
    private float positionRecordInterval = 0.01f; // positions interval
    private float timeToStore = 0.5f; // time of vector

    public float fixedYPosition = 8f; // Fixed position
    public Transform ballTransform;
    public Transform pivotPoint; 


    public 
    void Start()
    {
        InvokeRepeating("RecordPosition", 0f, positionRecordInterval);
        //GameObject ball = GameObject.FindGameObjectWithTag("Ball");
        //ballTransform = ball.transform;
    }

    void Update()
    {
        // set y position constant
        Vector3 newPosition = transform.position;
        newPosition.y = fixedYPosition;
        transform.position = newPosition;  
        
        if (ballTransform != null){

            Vector3 direccion = ballTransform.position - transform.position;
            direccion.y = 0f;
            if (direccion != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direccion);
                pivotPoint.rotation = Quaternion.Euler(0f, targetRotation.eulerAngles.y, 0f);
                       }
            /*
            Vector3 targetPosition = ballTransform.position;
            Vector3 direction = new Vector3(targetPosition.x - transform.position.x, 0, targetPosition.z - transform.position.z);
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Euler(0,targetRotation.eulerAngles.y, 0);
            *///transform.LookAt(ballTransform);
        }
    }

    void RecordPosition()
    {
        if (previousPositions.Count >= timeToStore / positionRecordInterval)
        {
            previousPositions.Dequeue(); // Eliminar la posición más antigua
        }
        previousPositions.Enqueue(transform.position); // Almacenar la posición actual
    }

    public Vector3 GetPreviousPosition(float timeAgo)
    {
        int index = Mathf.RoundToInt(timeAgo / positionRecordInterval);
        if (index < previousPositions.Count)
        {
            return previousPositions.ToArray()[previousPositions.Count - 1 - index];
        }
        else
        {
            Debug.LogWarning("No hay suficiente historial de posiciones, devolviendo la posición actual");
            return transform.position; // Si no hay suficiente historia, devuelve la posición actual
        }
    }
}