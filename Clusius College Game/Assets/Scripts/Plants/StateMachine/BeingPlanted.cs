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
        
    }

    public void Tick()
    {
        plantID = plantReference.GetID;
        Debug.Log(plantID);

        if (plantID != null)
        {
            FarmManager.PlayerNeedsToSelectPlant(plantID);
            isPlantPlanted = true;
            plantReference.ExecuteBehaviourOnClick();
        }        
    }

    public void OnExit()
    {
        isPlantPlanted = false;
        //seedSpawn.SetActive(false);
    }

   
}
