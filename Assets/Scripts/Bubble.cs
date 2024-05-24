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
        // Detección de toque en dispositivos móviles
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                CheckTouch(touch.position);
            }
        }

        // Detección de clic del ratón en dispositivos de escritorio
        if (Input.GetMouseButtonDown(0))
        {
            CheckTouch(Input.mousePosition);
        }
    }

    private void CheckTouch(Vector3 screenPosition)
    {
        if (Camera.main == null)
        {
            Debug.LogError("No se encontró una cámara principal en la escena.");
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

