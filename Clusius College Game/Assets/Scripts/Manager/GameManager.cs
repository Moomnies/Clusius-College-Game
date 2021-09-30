using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] [Tooltip("Reference to the Inventory UI.")]
    GameObject _InventoryMenu;
    [SerializeField]
    Transform _ContentFieldInventory;
    [SerializeField] [Tooltip("Reference to the Player Settings Menu.")]
    GameObject _PlayerSettingsMenu;

    [Header("Prefabs")]
    [SerializeField]
    GameObject _ItemPrefab;  


    private void Start()
    {
        FarmManager.SelectAPlant += PlayerIsSelectingPlant;
        Inventory.ItemAddedToInventory += UpdateInventory;
    }

    public void OpenInventory()
    {
        if(_InventoryMenu != null && !_InventoryMenu.activeSelf)
        {
            _InventoryMenu.SetActive(true);            
        }
    }

    void UpdateInventory()
    {           
        foreach (Item item in Inventory.GetAllItemsInInventory)
        {           
            GameObject choiceInstane = Instantiate(_ItemPrefab, _ContentFieldInventory);          

            choiceInstane.GetComponent<Image>().sprite = item.ItemBorder;
            GameObject child = choiceInstane.transform.GetChild(0).gameObject;
            child.GetComponent<Image>().sprite = item.ItemIcon;            
        }
    }
    
    public void PlayerIsSelectingPlant(dynamic plantID)
    {
        dynamic plant = plantID;

        StartCoroutine(WaitTillPlantIsSelected());

        IEnumerator WaitTillPlantIsSelected()
        {
            Plant plantedPlant = null;

            OpenInventory();         

            yield return new WaitUntil(() => plantedPlant != null);

            FarmManager.PlantIsSelected(plantID, plantedPlant);
        }        
    }

    public void CloseInventoryMenu()
    {
        if (_InventoryMenu != null && _InventoryMenu.activeSelf)
        {
            _InventoryMenu.SetActive(false);
        }
    }

    public void OpenPlayerSettings()
    {
        if (_PlayerSettingsMenu != null && !_PlayerSettingsMenu.activeSelf)
        {
            _PlayerSettingsMenu.SetActive(true);
        }
    }

    public void ClosePlayerSettings()
    {
        if (_PlayerSettingsMenu != null && _PlayerSettingsMenu.activeSelf)
        {
            _PlayerSettingsMenu.SetActive(false);
        }
    }

    
}
