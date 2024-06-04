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
        Debug.Log("Something has touched the ball");
        //Check if the collider that touched the ball has the tag Player
        if (other.CompareTag("Player") && spawner != null)
        {
            Debug.Log("Bubbles touched by the player");
            spawner.BubbleTouched(gameObject);

            //Sound when the ball is touched and errased
            if (SoundManager.Instance != null)
            {
                SoundManager.Instance.PlayBubblePopSound();
            }

        }
    }

}

