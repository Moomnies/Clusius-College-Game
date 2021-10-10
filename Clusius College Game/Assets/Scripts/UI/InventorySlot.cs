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
        [SerializeField] Button button;       

        int index;        
        Inventory inventory;
        InventoryManager inventoryManager;
        

        public void Setup(Inventory inventory, int index, InventoryManager gameManager)
        {
            this.inventoryManager = gameManager;
            this.inventory = inventory;
            this.index = index;  
            
            icon.SetItem(inventory.GetItemInSlot(index), button);

            if (button.IsActive())
            {
                button.onClick.AddListener(BeenClicked);
            }
        }

        public void BeenClicked()
        {
            inventoryManager.ItemSelected(inventory.GetItemInSlot(index));
        }
    } 
}
