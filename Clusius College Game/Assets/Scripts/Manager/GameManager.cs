using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{    
    [SerializeField] [Tooltip("Reference to the Player Settings Menu.")]
    GameObject _PlayerSettingsMenu;
    [SerializeField]
    [Tooltip("Reference to the Inventory UI.")]
    GameObject _InventoryMenu;

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
    public void OpenInventory()
    {
        if (_InventoryMenu != null && !_InventoryMenu.activeSelf)
        {
            _InventoryMenu.SetActive(true);
        }
    }

    public void CloseInventoryMenu()
    {
        if (_InventoryMenu != null && _InventoryMenu.activeSelf)
        {
            _InventoryMenu.SetActive(false);
        }
    }
}
