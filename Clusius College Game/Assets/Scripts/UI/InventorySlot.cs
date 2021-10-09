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
        GameManager gameManager;
        Button button;

        public void Setup(Inventory inventory, int index, GameManager gameManager)
        {
            this.gameManager = gameManager;
            this.inventory = inventory;
            this.index = index;            
            icon.SetItem(inventory.GetItemInSlot(index));  
        }
    }
}
