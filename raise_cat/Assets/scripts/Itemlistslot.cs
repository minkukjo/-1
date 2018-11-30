using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Itemlistslot : MonoBehaviour {

    public Image icon;
    public Text itemName_text;
    public Text itemCount_text;
    public GameObject selected_Item;

    public void Additem(ToyandItem _item)
    {
        itemName_text.text = _item.itemName;
        icon.sprite = _item.itemIcon;
        if(ToyandItem.ItemType.Use == _item.itemType)
        {
            if (_item.itemCount > 0)
                itemCount_text.text = "x " + _item.itemCount.ToString();
            else
                itemCount_text.text = "";
            
        }
    }

    public void RemoveItem()
    {
        itemName_text.text = "";
        itemCount_text.text = "";
        icon.sprite = null;
    }

}
