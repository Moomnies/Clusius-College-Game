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
    [SerializeField] Aarde _DigScript;
    [SerializeField] PlantState _CurrentPlantState = PlantState.Hole;


    enum PlantState
    {
        Hole,
        Growing,
        Ready
    }
   
    public string GetID { get => _PlantID; }
    public Plant Plant { get => _PlantToGrow; set => _PlantToGrow = value; }
    private void Awake()
    {
        _PlantID = Guid.NewGuid().ToString();
        //FarmManager.AddMeToManager(this);

        _TimerScript.onTimerRunOut += NextPlantPhase;
        _PlantScript.onHarvestReady += PlantIsReadyForHarvest;
        _DigScript.onPlantPlanted += StartPlantGrowth;
    }

    public void ExecuteBehaviourOnClick()
    {       
        switch (_CurrentPlantState)
        {
            case PlantState.Hole:
                _DigScript.ExecuteDigBehaviour();
                break;
            case PlantState.Growing:

                break;
            case PlantState.Ready:
                break;
            default:
                break;
        }
    }
    private void NextPlantPhase()
    {
        Debug.Log("Test");
        _PlantScript.NextPhase();
    }

    private void StartPlantGrowth()
    {
        _PlantScript.SetUpPlantData(_PlantToGrow);
        _TimerScript.SetTimerValue(_PlantToGrow.TimeToGrow);
        _TimerScript.ToggleOnOffTimmer();
        
    }
   
    private void PlantIsReadyForHarvest()
    {        
        _TimerScript.ToggleOnOffTimmer();       
    }

    private void ResetPlant() => _PlantToGrow = null; 
    
}
