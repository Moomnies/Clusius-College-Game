using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FarmManager
{
    private static Dictionary<string, GameObject> _PlantInScene = new Dictionary<string, GameObject>();
    private static string _SelectedPlanted;

    static public void AddMeToManager(GameObject plantToAdd, string plantID)
    {
        if (plantToAdd.GetComponent<PlantManager>() && plantID != null)
        {
            _PlantInScene.Add(plantID, plantToAdd);
        }
        else { Debug.LogFormat("Tried to add {0} to PlantsInSceneArray while this is not a plant", plantToAdd.name); }
    }

    static public void PlantAPlant(Plant plantThatsPlanted)
    {
        _PlantInScene[_SelectedPlanted].GetComponent<PlantManager>().Plant = plantThatsPlanted;
    }
}
