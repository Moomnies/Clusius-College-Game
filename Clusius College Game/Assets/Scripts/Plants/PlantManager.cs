using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantManager : MonoBehaviour
{
    [SerializeField] string _PlantID;
    [SerializeField] PlantScript _PlantScript;
    [SerializeField] TimerScript _TimerScript;
    [SerializeField] Plant _PlantToGrow;

    public string GetID { get => _PlantID; }
    public Plant Plant { get => _PlantToGrow; set => _PlantToGrow = value; }

    private void Awake()
    {
        _PlantID = Guid.NewGuid().ToString();
        FarmManager.AddMeToManager(this.gameObject, _PlantID);
        _TimerScript.onTimerRunOut += NextPlantPhase;
        _PlantScript.onHarvestReady += PlantIsReadyForHarvest;
    }

    private void StartPlantGrowth()
    {
        _PlantScript.SetUpPlantData(_PlantToGrow);
        _TimerScript.SetTimerValue(_PlantToGrow.TimeToGrow);
        _TimerScript.ToggleOnOffTimmer();
    }

    private void NextPlantPhase()
    {
        _PlantScript.NextPhase();
    }

    private void PlantIsReadyForHarvest()
    {
        _TimerScript.ToggleOnOffTimmer();
        //Spawn Produce at right Location
    }
}
