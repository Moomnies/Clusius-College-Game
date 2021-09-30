using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : ScriptableObject
{
    [SerializeField] [Tooltip("ID from Item will be automaticly Generated")]
    string _ItemID;
    [SerializeField] [Tooltip("Item Name to Be Displayed in Inventory")] 
    string _ItemName;
    [SerializeField]
    [Tooltip("Item Discription to show in Menu")]
    string _ItemDiscription;
    [SerializeField] [Tooltip("Icon that item will be displayed with in Inventory")] 
    Sprite _ItemIcon;
    [SerializeField]
    Sprite _ItemBorder;
    [SerializeField] [Tooltip("Can one slot hold Mutiple Items or just one. Should be False if item is a tool")] 
    protected bool _Stackable;

    public Sprite ItemBorder { get => _ItemBorder; }
    public Sprite ItemIcon { get => _ItemIcon;}
}
