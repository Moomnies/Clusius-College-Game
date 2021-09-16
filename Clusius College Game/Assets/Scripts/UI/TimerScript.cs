using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    [SerializeField]
    float _TimeCount = 300;    

    [SerializeField]
    TextMeshProUGUI _TimerText;

    bool _TimerIsRunning = false;

    private void Start()
    {
        _TimerIsRunning = true;
    }

    private void Update()
    {
        if (_TimerIsRunning && _TimeCount > 0)
        {
            _TimeCount -= Time.deltaTime;
            DisplayTime(_TimeCount);
        } 
        else if(_TimerIsRunning && _TimeCount <= 0)
        {
            //Set Off Event in Plant Script

            _TimeCount = 10;
            _TimerIsRunning = false;
        }        
    }
    
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60); 
        
        _TimerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
