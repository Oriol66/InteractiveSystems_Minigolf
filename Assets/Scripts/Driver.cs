using UnityEngine;
using System.Collections.Generic;

public class Driver : MonoBehaviour
{
    private Queue<Vector3> previousPositions = new Queue<Vector3>();
    private float positionRecordInterval = 0.01f; // Intervalo de grabación de posiciones
    private float timeToStore = 0.5f; // Tiempo a almacenar en segundos

    public float fixedYPosition = 8f; // Fixed position
    void Start()
    {
        InvokeRepeating("RecordPosition", 0f, positionRecordInterval);
    }

    void Update()
    {
        // set y position constant
        Vector3 newPosition = transform.position;
        newPosition.y = fixedYPosition;
        transform.position = newPosition;  
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