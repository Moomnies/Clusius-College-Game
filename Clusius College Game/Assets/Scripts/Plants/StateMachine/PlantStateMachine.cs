using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inventory;

public class PlantStateMachine : MonoBehaviour
{
    StateMachine _StateMachine;
    
    [Header("Plant Information")]
    [SerializeField] string plantID;

    [Header("Assign First Please")]
    [SerializeField] MeshFilter meshFilter;
    [SerializeField] GameObject seedSpawn;
    [SerializeField] Seed _PlantedSeed;
    [SerializeField] TimerScript timer;

    [Header("DEBUG MODE")]
    [SerializeField] bool debugMode;
    [SerializeField] Item itemToAdd;


    public string GetID { get => plantID; }
    public IState currentPlantState { get => _StateMachine.GetCurrentState(); }
    public Seed PlantedSeed { get => _PlantedSeed; set => _PlantedSeed = value; }

    private void Awake()
    {       
        _StateMachine = new StateMachine(debugMode);

        var digging = new Digging(meshFilter);
        var beingPlanted = new BeingPlanted(meshFilter, seedSpawn, this);
        var growing = new Growing(this, timer);

        void At(IState to, IState from, Func<bool> condition) => _StateMachine.AddTransition(to, from, condition);

        At(digging, beingPlanted, HoleIsDug());
        At(beingPlanted, growing, SeedIsPlanted());

        Func<bool> HoleIsDug() => () => digging.IsHoleDug;
        Func<bool> SeedIsPlanted() => () => beingPlanted.IsPlantPlanted;

        _StateMachine.SetState(digging);        
    }

    private void Start()
    {
        plantID = Guid.NewGuid().ToString();
        FarmManager.AddMeToManager(this);
    }

    public void ExecuteBehaviourOnClick() => _StateMachine.Tick();
}
