using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory
{
    public class InventoryIcon : MonoBehaviour
    {     
        public void SetItem(Item item)
        {
            var iconImage = GetComponent<Image>();
            if (item == null)
            {
                iconImage.enabled = false;
            }
            else
            {
                iconImage.enabled = true;
                iconImage.sprite = item.ItemIcon;
                transform.parent.GetComponent<Image>().sprite = item.ItemBorder;
            }
        }
    }
}
