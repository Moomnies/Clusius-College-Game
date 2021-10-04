using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Growing : MonoBehaviour, IState
{

    bool plantIsGrown = false;

    public bool isPlantGrown { get => plantIsGrown; }

    public Growing()
    {

    }

    public void OnEnter()
    {
        plantIsGrown = true;
    }

    public void OnExit()
    {
        plantIsGrown = false;
    }

    public void Tick()
    {
        
    }
}
