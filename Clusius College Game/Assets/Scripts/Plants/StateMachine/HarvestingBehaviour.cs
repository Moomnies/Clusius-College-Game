using Inventory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarvestingBehaviour : MonoBehaviour, IState
{
    TimerScript timer;
    PlantStateMachine plantReference;
    Seed seed;
    public HarvestingBehaviour(TimerScript timer, PlantStateMachine plantState)
    {
        this.timer = timer;
        plantReference = plantState;
        seed = plantState.PlantedSeed;
    }
    public void OnEnter()
    {
        throw new System.NotImplementedException();
    }

    public void OnExit()
    {
        throw new System.NotImplementedException();
    }

    public void Tick()
    {
        throw new System.NotImplementedException();
    }   
}
