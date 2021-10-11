using Inventory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Growing : MonoBehaviour, IState
{
    Seed seedPlanted;
    PlantStateMachine plantState;
    TimerScript timer;

    Mesh[] plantMeshes;
    MeshFilter thisPlantsMesh;
    int orderInPlantMeshes;

    bool plantIsDoneGrowing;
    public bool PlantIsDoneGrowing { get => plantIsDoneGrowing; }
    public Growing(PlantStateMachine plantStateMachine, TimerScript timer, MeshFilter thisPlantsMesh)
    {
        plantState = plantStateMachine;
        this.timer = timer;
        this.thisPlantsMesh = thisPlantsMesh;
    }   

    public void OnEnter()
    {
        seedPlanted = plantState.PlantedSeed;
        plantIsDoneGrowing = false;

        if (timer != null)
        {
            timer.SetTimerValue(seedPlanted.TimeToGrow);
            timer.ToggleOnOffTimmer();
            timer.onTimerRunOut += NextPlantStage;
        }
        else { Debug.LogFormat("GROWING.TICK(): Timer is null! Timer: {0} In Plant: {1}", timer, plantState.GetID); }

        if(seedPlanted.PlantModels != null)
        {
            plantMeshes = new Mesh[seedPlanted.PlantModels.Length];

            for (int i = 0; i < plantMeshes.Length; i++)
            {                
                plantMeshes[i] = seedPlanted.PlantModels[i];
            }

            orderInPlantMeshes = 0;
            thisPlantsMesh.mesh = plantMeshes[orderInPlantMeshes];
        }
    }

    public void OnExit()
    {
        timer.ToggleOnOffTimmer();
    }

    public void Tick()
    {
        FarmManager.ShowPlantData(plantState.GetID);
    }

    void NextPlantStage()
    {       
        orderInPlantMeshes++;
        thisPlantsMesh.mesh = plantMeshes[orderInPlantMeshes];      
      
        if (orderInPlantMeshes == plantMeshes.Length - 1)
        {
            plantIsDoneGrowing = true; 
            plantState.ExecuteBehaviourOnClick();
        }
    }
}
