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
    if (other.CompareTag("Player") && spawner != null) 
    {
        Debug.Log("Burbujas tocadas por player");
        spawner.BubbleTouched(gameObject);
    }
}
}