using UnityEngine;
using System.Collections.Generic;

public class Driver : MonoBehaviour
{
    private Queue<Vector3> previousPositions = new Queue<Vector3>();
    private float positionRecordInterval = 0.01f; 
    private float timeToStore = 0.5f; 

    public float fixedYPosition = 8f;
    public Transform ballTransform;
    public Transform pivotPoint; 


    void Start()
    {
        //Implements the RecordPosition method for each interval of time
        InvokeRepeating("RecordPosition", 0f, positionRecordInterval);

    }

    void Update()
    {
        // set y position as a constant
        Vector3 newPosition = transform.position;
        newPosition.y = fixedYPosition;
        transform.position = newPosition;  
        
        if (ballTransform != null){

            //Calculate the direction from the object to the ball
            Vector3 direccion = ballTransform.position - transform.position;
            direccion.y = 0f;
            if (direccion != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direccion);
                pivotPoint.rotation = Quaternion.Euler(0f, targetRotation.eulerAngles.y, 0f);
            }
        }
    }

    void RecordPosition()
    {
        if (previousPositions.Count >= timeToStore / positionRecordInterval)
        {
            //Remove the oldest position
            previousPositions.Dequeue(); 
        }

        //Store the actual position
        previousPositions.Enqueue(transform.position); 
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
            //If there isn't enough position history, return the current position
            return transform.position; 
        }
    }
}