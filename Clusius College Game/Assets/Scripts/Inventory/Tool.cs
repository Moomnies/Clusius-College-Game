using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Seed", menuName = "Item/Tool")]
public class Tool : Item
{
    private void Awake()
    {
        _Stackable = false;
    }
}
