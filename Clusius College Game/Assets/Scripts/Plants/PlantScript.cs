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

    [SerializeField]    PlantStates _PlantState = PlantStates.Sapling;
    [SerializeField]    Plant _Plant;
    [SerializeField]    Plant _TestPlant;
    [SerializeField]    TimerScript _Timer;
    [SerializeField]    Mesh[] _PlantMeshes;
    [SerializeField]    MeshFilter _GameObjectMesh;
    [SerializeField]    int _MeshOrder = 0;
    [SerializeField]    bool _HarvestReady = false;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(2);
        StartPlantGrowth(_TestPlant);
    }

    public void StartPlantGrowth(Plant plantedPlant)
    {        
        SetUpTimer(plantedPlant);
        SetUpPlantData(plantedPlant);
    }

    private void SetUpTimer(Plant plantedPlant)
    {
        _Timer.SetTimer(plantedPlant.TimeToGrow);
        _Timer.ToggleOnOffTimmer();
        _Timer.onTimerRunOut += NextPhase;
    }

    private void SetUpPlantData(Plant plantedPlant)
    {
        _PlantMeshes = new Mesh[plantedPlant.PlantModels.Length];
        _GameObjectMesh = this.gameObject.GetComponent<MeshFilter>();

        for (int i = 0; i < _PlantMeshes.Length; i++)
        {
            _PlantMeshes[i] = plantedPlant.PlantModels[i];
        }
    }

    private void NextPlantMesh()
    {
        _GameObjectMesh.mesh = _PlantMeshes[_MeshOrder + 1];
        _MeshOrder++;
    }

    private void Update()
    {
        if (_HarvestReady)
        {

        }
    }

    void NextPhase()
    {       
        switch (_PlantState)
        {
            case PlantStates.Sapling:

                _PlantState = PlantStates.Smallplant;
                NextPlantMesh();  
                
                break;

            case PlantStates.Smallplant:

                _PlantState = PlantStates.Flowering;
                NextPlantMesh();   
                
                break;

            case PlantStates.Flowering:
                _PlantState = PlantStates.Produce;
                NextPlantMesh();

                _HarvestReady = true;
                
                _Timer.ToggleOnOffTimmer();

                break;     

            default:
                Debug.LogFormat("State not found: {0}", _PlantState);
                break;
        }

    }



}
