using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarvestingBehaviour : MonoBehaviour, IState
{
    TimerScript timer;
    PlantStateMachine plantReference;
    Seed seed;

    bool harvested = false;
    PlayerInventory inventory;

    public bool Harvested { get => harvested; set => harvested = value; }

    public HarvestingBehaviour(TimerScript timer, PlantStateMachine plantState)
    {
        this.timer = timer;
        plantReference = plantState;
        inventory = PlayerInventory.GetPlayerInventory();
    }

    public void OnEnter()
    {
        seed = plantReference.PlantedSeed;
        plantReference.FruitSpawn.SetActive(true);
    }

    public void Tick()
    {
        Harvested = inventory.AddToFirstEmptySlot(seed.TypeOfProduce);
    }

    public void OnExit()
    {
        
    }    
}
