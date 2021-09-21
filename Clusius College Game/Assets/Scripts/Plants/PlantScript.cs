using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantScript : MonoBehaviour
{
    //Enum to track the current PlantStage
    enum PlantStates
    {
        Sapling,
        Smallplant,
        Flowering,
        Produce
    }

    [SerializeField] [Tooltip("State that a plant is currenly in. Debug Only.")]
    PlantStates _PlantState = PlantStates.Sapling;
    [SerializeField] [Tooltip("Reference to Mesh Renderer on this Object")]
    MeshFilter _GameObjectMesh;
    [SerializeField] [Tooltip("Reference to Plant SO, This is for testing Only")]
    Plant _TestPlant;
    [SerializeField] [Tooltip("Reference to UI that has TimerScript on it")]
    TimerScript _Timer;

    Plant _CurrentlyGrowingPlant;
    Mesh[] _PlantStageMeshes;    
    int _OrderInMesh = 0;
    bool _IsHarvestReady = false;

    //Coroutine to Test Script. Will load in SO placed in _TestPlant 
    IEnumerator Start()
    {
        yield return new WaitForSeconds(2);
        StartPlantGrowth(_TestPlant);
    }

    /// <summary>
    /// Will Set up Timer and MeshData
    /// </summary>
    /// <param name="plantedPlant"> The SO that of the Type of Plant that was planted</param>
    public void StartPlantGrowth(Plant plantedPlant)
    {        
        SetUpTimer(plantedPlant);
        SetUpPlantData(plantedPlant);
    }

    /// <summary>
    /// Sets up Timer for this specific Plant, Also Subscribes NextPhase to Timer Event -> See Timer
    /// </summary>
    /// <param name="plantedPlant">The SO that of the Type of Plant that was planted</param>
    private void SetUpTimer(Plant plantedPlant)
    {
        _Timer.SetTimerValue(plantedPlant.TimeToGrow);
        _Timer.ToggleOnOffTimmer();
        _Timer.onTimerRunOut += NextPhase;
    }

    /// <summary>
    /// Adds Meshed from the SO to the _PlantMeshes so the meshes can change per plant growth cicle.
    /// </summary>
    /// <param name="plantedPlant">The SO that of the Type of Plant that was planted</param>
    private void SetUpPlantData(Plant plantedPlant)
    {
        _PlantStageMeshes = new Mesh[plantedPlant.PlantModels.Length];
        _GameObjectMesh = this.gameObject.GetComponent<MeshFilter>();

        for (int i = 0; i < _PlantStageMeshes.Length; i++)
        {
            _PlantStageMeshes[i] = plantedPlant.PlantModels[i];
        }
    }

    /// <summary>
    /// Will load in next plant Mesh
    /// </summary>
    private void NextPlantMesh()
    {
        _GameObjectMesh.mesh = _PlantStageMeshes[_OrderInMesh + 1];
        _OrderInMesh++;
    }

    /// <summary>
    /// Will use Enum to switch to next phase and execute behaviour
    /// </summary>
    void NextPhase()
    {       
        switch (_PlantState)
        {
            case PlantStates.Sapling:
                _PlantState = PlantStates.Smallplant;       
                break;

            case PlantStates.Smallplant:
                _PlantState = PlantStates.Flowering;              
                break;

            case PlantStates.Flowering:
                _PlantState = PlantStates.Produce;                
                _IsHarvestReady = true;
                _Timer.ToggleOnOffTimmer();
                break;     

            default:
                Debug.LogFormat("State not found: {0}", _PlantState);
                break;
        }

        NextPlantMesh();

    }



}
