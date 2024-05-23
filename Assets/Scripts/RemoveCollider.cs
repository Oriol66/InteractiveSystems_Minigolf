using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveCollider : MonoBehaviour
{
    public GameObject[] objects; // Los objetos que aparecerán al impactar con la caja
    public GameObject boxCollider; // El collider que desaparecerá al tocar los objetos
    public float time = 10f; // Tiempo límite para tocar los objetos
    private bool isObjectTouch = false; // Indica si los objetos han sido tocados

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball")) // Verifica si el objeto que colisionó es la pelota
        {
            // Activa los objetos que deben aparecer
            foreach(GameObject obj in objects)
            {
                obj.SetActive(true);
            }
            // Desactiva el collider de la caja
            boxCollider.SetActive(false);
            // Inicia el temporizador para tocar los objetos
            Invoke("DisapearObjects", time);
        }
    }

    private void DisapearObjects()
    {
        // Si los objetos no han sido tocados antes de que termine el tiempo, se desactivan
        if (!isObjectTouch)
        {
            foreach(GameObject obj in objects)
            {
                obj.SetActive(false);
            }
            // Activar nuevamente el collider de la caja
            boxCollider.SetActive(true);
        }
    }

    // Método llamado cuando se toca uno de los objetos
    public void objectTouch()
    {
        isObjectTouch = true;
        // Desactiva los objetos y activa nuevamente el collider de la caja
        foreach(GameObject obj in objects)
        {
            obj.SetActive(false);
        }
        boxCollider.SetActive(true);
        // Cancela la llamada al método DesaparecerObjetos
        CancelInvoke("DisaperObjects");
    }
}
