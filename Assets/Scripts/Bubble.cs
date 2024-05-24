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

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Algo ha tocado la burbuja");
        if (other.CompareTag("Player") && spawner != null)
        {
          Debug.Log("Burbujas tocadas por player");
          spawner.BubbleTouched(gameObject);
          //Destroy(this);
        }
    }


}

