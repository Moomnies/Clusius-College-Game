using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Seed", menuName = "Item/Seed")]
public class Produce : Item
{
    [SerializeField] [Tooltip("Value of Produce so it can be displayed in Inventory")]
    float _ProduceValue;
    //[SerializeField] string _ProduceDiscription;

    private void Awake()
    {
        _Stackable = true;
    }
}
