using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeingPlanted : MonoBehaviour, IState
{
    MeshFilter meshFilter;

    bool isPlantPlanted;
    GameObject seedSpawn;
    string plantID;
    PlantStateMachine plantReference;

    public bool IsPlantPlanted { get => isPlantPlanted; }

    public BeingPlanted(MeshFilter meshFilter, GameObject seedObject, PlantStateMachine plantReference)
    {
        this.meshFilter = meshFilter;
        this.seedSpawn = seedObject;
        this.plantReference = plantReference;     
    }

    public void OnEnter()
    {       
        plantID = plantReference.GetID;

        if (plantID != null)
        {
            FarmManager.PlayerNeedsToSelectPlant(plantID);            
        }
        else { Debug.Log("BEINGPLANTED.TICK(): PlantID is null!"); }        
    }

    public void Tick()
    {
          
    }

    public void OnExit()
    {
        //isPlantPlanted = false;       
    }

   
}
