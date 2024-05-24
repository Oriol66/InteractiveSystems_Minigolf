using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    private RemoveCollider spawner;

    public void SetSpawner(RemoveCollider spawner)
    {
        this.spawner = spawner;
    }

    //    private void OnTriggerEnter(Collider other)
    //{
    //   if (other.CompareTag("Player") && spawner != null) 
    //    {
    //       Debug.Log("Burbujas tocadas por player");
    //       spawner.BubbleTouched(gameObject);
    //    }
    //}

    void Update()
    {
        // Detecci�n de toque en dispositivos m�viles
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                CheckTouch(touch.position);
            }
        }

        // Detecci�n de clic del rat�n en dispositivos de escritorio
        if (Input.GetMouseButtonDown(0))
        {
            CheckTouch(Input.mousePosition);
        }
    }

    private void CheckTouch(Vector3 screenPosition)
    {
        if (Camera.main == null)
        {
            Debug.LogError("No se encontr� una c�mara principal en la escena.");
            return;
        }

        Ray ray = Camera.main.ScreenPointToRay(screenPosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject == gameObject && spawner != null)
            {
                Debug.Log("Burbuja tocada");
                spawner.BubbleTouched(gameObject);
            }
        }
    }
}

