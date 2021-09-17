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
    TimerScript _Timer;

    private void Start()
    {
        _Timer.SetTimer(_Plant.TimeToGrow);
        _Timer.onTimerRunOut += nextPhase;
    }

    public void StartPlantGrowth(Plant plantedPlant)
    {
        _Plant = plantedPlant;
        _Timer.SetTimer(plantedPlant.TimeToGrow);
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
                break;

            case PlantStates.Produce:

                break;

            default:
                Debug.LogFormat("State not found: {0}", _PlantState);
                break;
        }

    }

}
