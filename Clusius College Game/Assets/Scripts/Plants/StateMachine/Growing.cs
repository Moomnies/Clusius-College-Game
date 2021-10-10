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

        if (timer != null)
        {
            timer.SetTimerValue(seedPlanted.TimeToGrow);
            timer.ToggleOnOffTimmer();
        }
        else { Debug.LogFormat("GROWING.TICK(): Timer is null! Timer: {0} In Plant: {1}", timer, plantState.GetID); }
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
