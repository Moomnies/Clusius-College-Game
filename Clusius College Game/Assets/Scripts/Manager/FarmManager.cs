using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inventory;

public static class FarmManager
{    
    public static event Action<string> PlayerNeedToSelectAPlant;
    
    private static Dictionary<string, PlantStateMachine> _PlantInScene = new Dictionary<string, PlantStateMachine>();

    public static void PlayerNeedsToSelectPlant(string plantID)
    {
        if (plantID != null && PlayerNeedToSelectAPlant != null)
        {
            PlayerNeedToSelectAPlant(plantID);
        }
    }

    public static void PlantIsSelected(string plantID, Seed selectedPlant)
    {
        if (plantID != null && selectedPlant != null)
        {
            Debug.Log("Planting:" + selectedPlant);
            _PlantInScene[plantID].PlantedSeed = selectedPlant;
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
}
