using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantScript : MonoBehaviour
{
    public event Action onHarvestReady;

    //Enum to track the current PlantStage
    enum PlantStates
    {
        Sapling,
        Smallplant,
        Flowering,
        Produce
    }
    
    PlantStates _PlantState = PlantStates.Sapling;    
    MeshFilter _GameObjectMesh;  
    Mesh[] _PlantStageMeshes;    
    int _OrderInMesh = 0; 

    /// <summary>
    /// Adds Meshed from the SO to the _PlantMeshes so the meshes can change per plant growth cicle.
    /// </summary>
    /// <param name="plantedPlant">The SO that of the Type of Plant that was planted</param>
    public void SetUpPlantData(Plant plantedPlant)
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
    public void NextPhase()
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
                onHarvestReady();         
                break;     

            default:
                Debug.LogFormat("State not found: {0}", _PlantState);
                break;
        }

        NextPlantMesh();
    }
}
