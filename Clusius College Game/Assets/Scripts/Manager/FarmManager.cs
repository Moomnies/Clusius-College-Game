using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FarmManager
{
    private static Dictionary<string, PlantManager> _PlantInScene = new Dictionary<string, PlantManager>();
    private static string _SelectedPlanted;

    public static void AddMeToManager(PlantManager plantToAdd)
    {
        if (plantToAdd.GetComponent<PlantManager>() && plantToAdd.GetID != null)
        {
            _PlantInScene.Add(plantToAdd.GetID, plantToAdd);
        }
        else { Debug.LogFormat("Tried to add {0} to PlantsInSceneArray while this is not a plant", plantToAdd.name); }
    }

    public static void PlantAPlant(Plant plantThatsPlanted)
    {
        _PlantInScene[_SelectedPlanted].Plant = plantThatsPlanted;
    }
    public static void ThisPlantIsTouched(string plantID)
    {
        _PlantInScene[plantID].ExecuteBehaviourOnClick();
    }
}
