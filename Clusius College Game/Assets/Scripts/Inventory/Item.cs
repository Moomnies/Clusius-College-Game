using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : ScriptableObject
{

    [SerializeField] [Tooltip("Item Name to Be Displayed in Inventory")] 
    string _ItemName;
    [SerializeField] [Tooltip("Icon that item will be displayed with in Inventory")] 
    Image _ItemIcon;
    [SerializeField] [Tooltip("Can one slot hold Mutiple Items or just one. Should be False if item is a tool")] 
    protected bool _Stackable;
}
