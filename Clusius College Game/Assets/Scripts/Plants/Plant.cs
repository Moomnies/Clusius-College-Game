using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Plant", menuName = "Plant")]
public class Plant : ScriptableObject
{
    [SerializeField]
    float _TimeToGrow;

    [SerializeField]
    GameObject[] _PlantModels = new GameObject[4];

    public float TimeToGrow { get => _TimeToGrow; set => _TimeToGrow = value; }
}