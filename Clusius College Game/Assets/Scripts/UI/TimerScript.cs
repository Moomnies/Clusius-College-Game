using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    public event Action onTimerRunOut;
    
    [SerializeField] [Tooltip("Reference to UI Text of Timer")] 
    TextMeshProUGUI _TimerText;

    bool _IsTimerOn = false;
    bool _TimerIsRunning = false;
    float _TimeCount;
    float _CurrentTimer;

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
            DisplayTime(_CurrentTimer);
        }
        else if (_TimerIsRunning && _CurrentTimer <= -.1)
        {            
            onTimerRunOut();            
        }
    }   

    public void ToggleOnOffTimmer()
    {
        _IsTimerOn = !_IsTimerOn;
        this.gameObject.SetActive(_IsTimerOn);       

        if (_IsTimerOn)
        {          
            _TimerIsRunning = true;
            _CurrentTimer = _TimeCount;
            onTimerRunOut += ResetTimer;
        }
    }
    
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60); 
        
        _TimerText.text = string.Format("{0:0}:{1:00}", minutes, seconds);
    }
}
