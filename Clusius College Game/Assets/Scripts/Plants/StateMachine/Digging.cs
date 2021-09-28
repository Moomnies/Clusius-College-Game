using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Digging : MonoBehaviour, IState
{
    MeshFilter meshFilter;
    bool holeIsDug = false;

    public bool IsHoleDug { get => holeIsDug; }

    public Digging(MeshFilter meshFilter)
    {
        this.meshFilter = meshFilter;
    }

    public void OnEnter()
    {
        holeIsDug = true;
    }
    public void Tick()
    {
        
    }

    public void OnExit()
    {
        holeIsDug = false; 
    }    
}
