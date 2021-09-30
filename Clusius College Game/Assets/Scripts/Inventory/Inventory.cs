using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public static class Inventory
{
    public static event Action ItemAddedToInventory;

    private static List<Item> _ItemsInInventory = new List<Item>();

    public static List<Item> GetAllItemsInInventory { get => _ItemsInInventory;}

    public static void AddItemToInventory(Item item)
    {        
        _ItemsInInventory.Add(item);
        ItemAddedToInventory();
    }    
}
