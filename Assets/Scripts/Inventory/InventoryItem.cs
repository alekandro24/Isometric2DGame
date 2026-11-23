using System;
using UnityEngine;

[Serializable]
public class InventoryItem
{
    public ItemData ItemData;
    public int Quantity;

    public InventoryItem(ItemData itemData, int quantity)
    {
        this.ItemData = itemData;
        this.Quantity = quantity;
    }

}
