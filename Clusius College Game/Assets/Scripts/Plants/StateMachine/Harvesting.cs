using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harvesting : MonoBehaviour, IState
{
    PlantStateMachine plantReference;
    bool plantIsHarvested = false;

    public bool isPlantHarvested {get => plantIsHarvested;}
    public GameObject[] _produceList;
    public Harvesting(PlantStateMachine plantReference)
    {
        this.plantReference = plantReference;
        this._produceList = GameObject.FindGameObjectsWithTag("Produce");
    }
    public void OnEnter()
    {
        foreach(GameObject produce in _produceList)
        {
            produce.GetComponent<Renderer>().enabled = true;
        }
        plantIsHarvested = true;
    }
    public void Tick()
    {
        foreach (GameObject produce in _produceList)
        {
            produce.GetComponent<Renderer>().enabled = false;
        }
      //  Inventory.AddItemToInventory(plantReference.Plant);
    }

    public void OnExit()
    {
        plantIsHarvested = false;
    }
}
