using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
        // End the game in a Build
        Application.Quit();
        
        // End the Game in the editor
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
