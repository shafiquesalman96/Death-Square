using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI timerText;

    [SerializeField] private float initialTime = 60f;
    private float currentTime;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = initialTime;
    }

    // timer begin with 60
    void Update()
    {
        if(currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            TimeSpan span = TimeSpan.FromSeconds(currentTime);
            timerText.text = span.ToString(@"mm\:ss");
            return;

        }
     // contdition for killing the rest of players  
     Debug.Log("Kill the players");
    }
}
