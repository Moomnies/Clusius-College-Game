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
        [SerializeField]
        GameObject inventory;       
      
        [Header("Prefabs")]
        [SerializeField]
        InventorySlot itemPrefab = null;
        [SerializeField]
        OpenUIComponent UIToggle;

        Item item;
        Seed itemToPlant;

        bool playerIsChoosing = false;              
        private void Start()
        {
            Redraw();

            FarmManager.PlayerNeedToSelectAPlant += PlayerIsSelectingAPlant;

            if (playerInventory == null)
            {
                playerInventory = Inventory.GetPlayerInventory();
                playerInventory.inventoryUpdated += Redraw;                
            }
        }  
        
        public void ItemSelected(Item item)
        {
            if (playerIsChoosing && item is Seed)
            {
                itemToPlant = item as Seed;                
                return;
            }
            
            this.item = item;          
        }      
        private void Redraw()
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }

            for (int i = 0; i < playerInventory.GetSize; i++)
            {
                var itemUI = Instantiate(itemPrefab, transform);
                itemUI.Setup(playerInventory, i, this);
            }
        }

        void PlayerIsSelectingAPlant(string plantID)
        {           
            playerIsChoosing = true;

            UIToggle.ToggleUIComponent();

            StartCoroutine(WaitTillPlantIsSelected());

            IEnumerator WaitTillPlantIsSelected()
            {                
                yield return new WaitUntil(() => itemToPlant != null);
                UIToggle.ToggleUIComponent();   
                FarmManager.PlantIsSelected(plantID, itemToPlant);
            }
        }
    }
}
