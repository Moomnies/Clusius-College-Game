using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    public event Action onTimerRunOut;

    [SerializeField] float _TimeCount = 300;
    [SerializeField] float _CurrentTimer;
    [SerializeField] TextMeshProUGUI _TimerText;

    bool _TimerIsRunning = false;  

    public void SetTimer(float timeCount)
    {
        _TimeCount = timeCount;
    }

    void Start()
    {
        _TimerIsRunning = true;
        _CurrentTimer = _TimeCount;
        onTimerRunOut += ResetTimer;
    }

    void Update()
    {
        CountTimer();
    }

    void CountTimer()
    {
        if (_TimerIsRunning && _CurrentTimer > 0)
        {
            _CurrentTimer -= Time.deltaTime;
            DisplayTime(_CurrentTimer);
        }
        else if (_TimerIsRunning && _CurrentTimer <= 0)
        {
            //Set Off Event in Plant Script
            onTimerRunOut();            
        }
    }

    void ResetTimer()
    {
        _CurrentTimer = _TimeCount;
    }

    public void TestStateSwitch()
    {
        onTimerRunOut();
    }
    
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60); 
        
        _TimerText.text = string.Format("{0:0}:{1:00}", minutes, seconds);
    }
}
