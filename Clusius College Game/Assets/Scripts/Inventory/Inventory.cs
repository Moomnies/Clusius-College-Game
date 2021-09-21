using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "Inventory")]
public class Inventory : ScriptableSingleton<Inventory>
{
    List<Item> _ItemsInInventory = new List<Item>();
}
