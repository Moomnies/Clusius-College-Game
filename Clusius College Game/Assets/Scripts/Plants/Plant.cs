using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Plant", menuName = "Plant")]
public class Plant : ScriptableObject
{
    [SerializeField]
    float _TimeToGrow;

    [SerializeField]
    Mesh[] _PlantModels = new Mesh[4];

    public float TimeToGrow { get => _TimeToGrow; set => _TimeToGrow = value; }
    public Mesh[] PlantModels { get => _PlantModels; set => _PlantModels = value; }
}