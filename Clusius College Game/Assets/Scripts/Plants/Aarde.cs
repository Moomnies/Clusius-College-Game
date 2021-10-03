using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aarde : MonoBehaviour
{
    public event Action onPlantPlanted;
    enum DigStates 
    { 
        Hole,
        SeedPlanted,
        HoleClosed
    }     
  
    [SerializeField] DigStates _CurrentState = DigStates.Hole;
    [SerializeField] Mesh[] _GroundMeshes;
    [SerializeField] MeshFilter _MeshRenderer;
    
    public void ExecuteDigBehaviour()
    {
        switch (_CurrentState)
        {
            case DigStates.Hole:                
                Debug.Log("Dug Hole");
                _MeshRenderer.mesh = _GroundMeshes[1];
                break;
            case DigStates.SeedPlanted:
                Debug.Log("Planted Seed");
                break;
            case DigStates.HoleClosed:                
                Debug.Log("Closed Hole");
                _MeshRenderer.mesh = _GroundMeshes[2];
                onPlantPlanted();
                break;
            default:
                break;
        };

        _CurrentState++;
    }   
}
