using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantStateMachine : MonoBehaviour
{
    StateMachine _StateMachine;
    
    [Header("Plant Information")]
    [SerializeField] string plantID;

    [Header("Assign First Please")]
    [SerializeField] MeshFilter meshFilter;
    [SerializeField] GameObject seedSpawn;
    [SerializeField] Plant plant;

    [Header("DEBUG MODE")]
    [SerializeField]bool debugMode;
    [SerializeField] Item itemToAdd;


    public string GetID { get => plantID; }
    public IState currentPlantState { get => _StateMachine.GetCurrentState(); }
    public Plant Plant { get => plant; set => plant = value; }

    private void Awake()
    {       
        _StateMachine = new StateMachine(debugMode);

        var digging = new Digging(meshFilter);
        var beingPlanted = new BeingPlanted(meshFilter, seedSpawn, this);
        var growing = new Growing();
        var harvesting = new Harvesting(this);

        void At(IState to, IState from, Func<bool> condition) => _StateMachine.AddTransition(to, from, condition);

        At(digging, beingPlanted, HoleIsDug());
        At(beingPlanted, growing, SeedIsPlanted());
        At(growing, harvesting, plantIsGrown());

        Func<bool> HoleIsDug() => () => digging.IsHoleDug;
        Func<bool> SeedIsPlanted() => () => beingPlanted.IsPlantPlanted;
        Func<bool> plantIsGrown() => () => growing.isPlantGrown;
        Func<bool> plantIsHarvested() => () => harvesting.isPlantHarvested;

        _StateMachine.SetState(digging);        
    }

    private void Start()
    {
        plantID = Guid.NewGuid().ToString();
        FarmManager.AddMeToManager(this);

        Inventory.AddItemToInventory(itemToAdd);      
    }

    public void ExecuteBehaviourOnClick() => _StateMachine.Tick();
}
