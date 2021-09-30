using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{    
    [SerializeField] [Tooltip("Reference to the Player Settings Menu.")]
    GameObject _PlayerSettingsMenu;    

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
