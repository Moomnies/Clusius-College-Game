using Inventory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Growing : MonoBehaviour, IState
{
    Seed seedPlanted;
    PlantStateMachine plantState;
    TimerScript timer;

    public Growing(PlantStateMachine plantStateMachine, TimerScript timer)
    {
        plantState = plantStateMachine;
        this.timer = timer;
    }

    public void OnEnter()
    {
        seedPlanted = plantState.PlantedSeed;
        timer.SetTimerValue(seedPlanted.TimeToGrow);
        timer.ToggleOnOffTimmer();
    }

    public void OnExit()
    {
        throw new System.NotImplementedException();
    }

    public void Tick()
    {
        return;
    }
}
