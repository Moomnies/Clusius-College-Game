using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    public event Action onTimerRunOut;   
    
    bool _IsTimerOn = false;
    bool _TimerIsRunning = false;
    float _TimeCount;
    float _CurrentTimer;

    public float CurrentTimer { get => _CurrentTimer; set => _CurrentTimer = value; }

    public void SetTimerValue(float timeCount) => _TimeCount = timeCount;

    void Update() => CountDownTimer();
    public void ResetTimer()
    {       
        _CurrentTimer = _TimeCount;
    }

    void CountDownTimer()
    {
        if (_TimerIsRunning && _CurrentTimer > -.1)
        {
            _CurrentTimer -= Time.deltaTime;            
        }
        else if (_TimerIsRunning && _CurrentTimer <= -.1)
        {            
            onTimerRunOut();            
        }
    }   

    public void ToggleOnOffTimmer()
    {
        _IsTimerOn = !_IsTimerOn;           

        if (_IsTimerOn)
        {          
            _TimerIsRunning = true;
            _CurrentTimer = _TimeCount;
            onTimerRunOut += ResetTimer;
        }
    }
    
   
}
