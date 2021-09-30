using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


namespace Inventory
{
    public static class Inventory
    {
        public static event Action ItemAddedToInventory;

        private static Dictionary<string, Item> _ItemsInInventory = new Dictionary<string, Item>();

        private static List<Item> allItems = new List<Item>();

        public static Dictionary<string, Item> GetAllItemsInInventory { get => _ItemsInInventory; }
        public static List<Item> GetAllItems { get => allItems; }

        public static void AddItemToInventory(Item item)
        {
            if (_ItemsInInventory.ContainsValue(item))
            {
                _ItemsInInventory[item.ItemID].AmountInPlayerInventory += 1;
            }
            else { _ItemsInInventory.Add(item.ItemID, item); }            

            ItemAddedToInventory();
        }
    }

}
