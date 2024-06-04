using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            Debug.Log("¡The ball has gone into the hole!");
            EndGame();
        }
    }

    void EndGame()
    {
        Debug.Log("The game is over.");
        if (GameManager.Instance != null)
        {
            GameManager.Instance.YouWin();
        }

    }
}
