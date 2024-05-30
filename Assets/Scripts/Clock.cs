using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Clock : MonoBehaviour
{
    public Text clockTest;
    private float time;

    void Start()
    {
        
    }

    void Update()
    {
        time += Time.deltaTime;
        ActualizeClock();
    }

    void ActualizeClock()
    {
        int minutes = (int)(time / 60);
        int seconds = (int)(time % 60);
        int miliseconds = (int)((time * 1000) % 1000);

        clockTest.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, miliseconds);
    }
    


}

