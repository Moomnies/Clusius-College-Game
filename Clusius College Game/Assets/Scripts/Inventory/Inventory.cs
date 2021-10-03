using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Inventory
{
    public class Inventory : MonoBehaviour
    {
        public event Action inventoryUpdated;

        [SerializeField] int inventorySize = 24;

        Item[] slots;     
        public int GetSize { get => slots.Length; }       
        public static Inventory GetPlayerInventory()
        {
            var player = GameObject.FindWithTag("Player");
            return player.GetComponent<Inventory>();
        }

        public bool AddToFirstEmptySlot(Item itemToAdd)
        {
            int i = FindSlot(itemToAdd);

            if(i < 0)
            {
                return false;
            }

            slots[i] = itemToAdd;
            if(inventoryUpdated != null)
            {
                inventoryUpdated();
            }

            return true;
        }
        
        public bool HasItem(Item item)
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if(object.ReferenceEquals(slots[i], item))
                {
                    return true;
                }
            }

            return false;
        }

        public Item GetItemInSlot(int slot)
        {
            return slots[slot];
        }

        public void RemoveFromSlot(int slot)
        {
            slots[slot] = null;
            if (inventoryUpdated != null)
            {
                inventoryUpdated();
            }
        }

        public bool AddItemToSlot(int slot, Item itemToAdd)
        {
            if(slots[slot] != null)
            {
                return AddToFirstEmptySlot(itemToAdd);
            }

            slots[slot] = itemToAdd;
            if (inventoryUpdated != null)
            {
                inventoryUpdated();
            }

            return true;
        }
      
        //PRIVATE
        private void Awake()
        {
            slots = new Item[inventorySize];
            slots[1] = Item.GetFromID("5d158303-0d62-458f-8c15-ddf689c6581d");
        }

        private int FindSlot(Item itemToAdd)
        {
            return FindEmptySlot();
        }

        private int FindEmptySlot()
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if(slots[i] = null)
                {
                    return i; 
                }
            }

            return -1;
        }
    }
}
