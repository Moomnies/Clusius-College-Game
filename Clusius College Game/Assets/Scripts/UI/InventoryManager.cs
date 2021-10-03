using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory
{
    public class InventoryManager : MonoBehaviour
    {        
        [SerializeField]
        Transform _ContentFieldInventory;
        [SerializeField]
        Inventory playerInventory;

        [Header("Prefabs")]
        [SerializeField]
        InventorySlot itemPrefab = null;
               
        private void Awake()
        {
            if(playerInventory == null)
            {
                playerInventory = Inventory.GetPlayerInventory();
                playerInventory.inventoryUpdated += Redraw;
            }
        }

        private void Start()
        {
            Redraw();
        }       

        //PRIVATE
        private void Redraw()
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }

            for (int i = 0; i < playerInventory.GetSize; i++)
            {
                var itemUI = Instantiate(itemPrefab, transform);
                itemUI.Setup(playerInventory, i);
            }
        }        
    }
}
