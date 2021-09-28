using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FarmManager
{
    public static event Action<dynamic> SelectAPlant;
    
    private static Dictionary<string, PlantStateMachine> _PlantInScene = new Dictionary<string, PlantStateMachine>();

    public static void PlantAPlant(string plantID) => SelectAPlant(plantID);
    public static void PlantIsSelected(string plantID, Plant selectedPlant)
    {
        if (plantID != null && selectedPlant != null)
        {
            _PlantInScene[plantID].Plant = selectedPlant;
        }
        else { Debug.LogFormat("FARMMANAGER.SELECTEDPLANT(): Something is null! PlantID: {0}, SelectedPlant: {1}.", plantID, selectedPlant); }
    }

    public static void AddMeToManager(PlantStateMachine plantToAdd)
    {
        if (plantToAdd.GetComponent<PlantStateMachine>() && plantToAdd.GetID != null)
        {
            _PlantInScene.Add(plantToAdd.GetID, plantToAdd);
            Debug.Log("ADDED PLANT: " + plantToAdd.GetID);
        }
        else { Debug.LogFormat("Tried to add {0} to PlantsInSceneArray while this is not a plant", plantToAdd.name); }
    }  

    public static void ThisPlantIsTouched(string plantID)
    {
        _PlantInScene[plantID].ExecuteBehaviourOnClick();
    }     
 
    public static void OpenPlantInformation(string plantID)
    {
        //Open Plant Information UI
        //Set UI Transform to Plant Position
    }    
}
