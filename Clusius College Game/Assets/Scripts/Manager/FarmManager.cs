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
        else { Debug.LogFormat("FARMMANAGER.PLAYERNEEDSTOSELECTPLANT(): Something is null! PlantID: {0}", plantID); }
    }

    public static void PlantIsSelected(string plantID, Seed selectedPlant)
    {     
        if (plantID != null && selectedPlant != null)
        {           
            _PlantInScene[plantID].PlantedSeed = selectedPlant;

            //Execute StateMachine Tick so Behaviour is Switched to Growing. Needs to be done here because PlayerNeedToSelectAPlant is an Event. 
            _PlantInScene[plantID].ExecuteBehaviourOnClick();
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
        else { Debug.LogFormat("FARMMANAGER.ADDMETOMANAGER(): Tried to add {0} to PlantsInSceneArray while this is not a plant", plantToAdd.name); }
    }  

    public static void ThisPlantIsTouched(string plantID)
    {
        if (plantID != null && _PlantInScene.ContainsKey(plantID))
        {
            _PlantInScene[plantID].ExecuteBehaviourOnClick();
        }
        else { Debug.LogFormat("FARMMANAGER.THISPLANTISTOUCHED: PlantID is null or PlantID isn't found in Dictionary! PlantID: {0}", plantID); }
    }        
}
