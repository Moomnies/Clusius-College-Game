using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantScript : MonoBehaviour
{
    enum PlantStates
    {
        Sapling,
        Smallplant,
        Flowering,
        Produce
    }

    [SerializeField]
    PlantStates _PlantState = PlantStates.Sapling;
    [SerializeField]
    Plant _Plant;
    [SerializeField]
    Plant _TestPlant;
    [SerializeField]
    TimerScript _Timer;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(2);
        StartPlantGrowth(_TestPlant);
    }

    public void StartPlantGrowth(Plant plantedPlant)
    {
        _Plant = plantedPlant;
        _Timer.SetTimer(plantedPlant.TimeToGrow);
        _Timer.ToggleOnOffTimmer();        
        _Timer.onTimerRunOut += nextPhase;
    }

    void nextPhase()
    {       
        switch (_PlantState)
        {
            case PlantStates.Sapling:
                _PlantState = PlantStates.Smallplant;
                Debug.Log(_PlantState);
                break;

            case PlantStates.Smallplant:
                _PlantState = PlantStates.Flowering;
                Debug.Log(_PlantState);
                break;

            case PlantStates.Flowering:
                _PlantState = PlantStates.Produce;
                Debug.Log(_PlantState);
                _Timer.ToggleOnOffTimmer();
                break;

            case PlantStates.Produce:
               
                break;

            default:
                Debug.LogFormat("State not found: {0}", _PlantState);
                break;
        }

    }

}
