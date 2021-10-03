using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inventory;
using UnityEngine.UI;

namespace Inventory
{
    public class InventorySlot : MonoBehaviour
    {
        [SerializeField] InventoryIcon icon;

        int index;        
        Inventory inventory;

        public void Setup(Inventory inventory, int index)
        {
            this.inventory = inventory;
            this.index = index;            
            icon.SetItem(inventory.GetItemInSlot(index));            
        }
    }
}
