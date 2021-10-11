using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inventory;

public class PlantStateMachine : MonoBehaviour
{
    StateMachine _StateMachine;   
    
    string plantID;
    Seed _PlantedSeed = null;

    [Header("Assign First Please")]
    [SerializeField] MeshFilter meshFilter;    
    [SerializeField] TimerScript timer;   

    [Header("DEBUG MODE")]
    [SerializeField] bool debugMode; 
    public string GetID { get => plantID; }
    public IState currentPlantState { get => _StateMachine.GetCurrentState(); }
    public Seed PlantedSeed { get => _PlantedSeed; set => _PlantedSeed = value; }
    public TimerScript Timer { get => timer; set => timer = value; }

    private void Awake()
    {       
        _StateMachine = new StateMachine(debugMode);

        var digging = new Digging(meshFilter);
        var beingPlanted = new BeingPlanted(meshFilter, this);
        var growing = new Growing(this, Timer, meshFilter);
        var harvestingB = new HarvestingBehaviour(Timer, this);

        void At(IState to, IState from, Func<bool> condition) => _StateMachine.AddTransition(to, from, condition);

        At(digging, beingPlanted, HoleIsDug());
        At(beingPlanted, growing, SeedIsPlanted());
        At(growing, harvestingB, SeedIsDoneGrowing());

        Func<bool> HoleIsDug() => () => digging.IsHoleDug;
        Func<bool> SeedIsPlanted() => () => _PlantedSeed != null;
        Func<bool> SeedIsDoneGrowing() => () => growing.PlantIsDoneGrowing;

        _StateMachine.SetState(digging);        
    }

    private void Start()
    {
        plantID = Guid.NewGuid().ToString();
        FarmManager.AddMeToManager(this);
    }

    public void ExecuteBehaviourOnClick() => _StateMachine.Tick();  
}
