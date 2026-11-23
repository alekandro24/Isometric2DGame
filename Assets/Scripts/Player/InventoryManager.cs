
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [Header("Inventory Settings")]
    [SerializeField] private int inventoryCapacity = 20;

    private List<InventoryItem> items = new List<InventoryItem>();

    public int InventoryCapacity { get => inventoryCapacity; }
    public List<InventoryItem> Items { get => items; }

    public bool AddItem(ItemData newItem, int quantity = 1)
    {
        if (newItem != null && quantity > 0)
        {
            if (inventoryCapacity > items.Count)
            {
                if (newItem.IsStackable)
                {
                    InventoryItem existingItem = FindItem(newItem);

                    if (existingItem != null)
                    {
                        // Add the quantity to the existing stack if it does not exceed the maximum stack size.
                        if (existingItem.ItemData.MaxStackSize >=
                            (existingItem.Quantity + quantity))
                        {
                            existingItem.Quantity += quantity;
                            return true;
                        }
                    }
                }

                // Create new inventory slots if the item cannot fit into an existing stack.
                while (inventoryCapacity > items.Count && quantity > 0)
                {
                    if (quantity >= newItem.MaxStackSize)
                    {
                        items.Add(new InventoryItem(newItem, newItem.MaxStackSize));
                        quantity -= newItem.MaxStackSize;
                    }
                    else
                    {
                        items.Add(new InventoryItem(newItem, quantity));
                        return true;
                    }
                }

                return true;
            }

            return false;
        }

        return false;
    }

    public bool RemoveItem(ItemData itemToRemove, int quantity)
    {
        if (itemToRemove != null && quantity > 0)
        {
            InventoryItem existingItem = FindItem(itemToRemove);

            // Only remove the item if the stack contains enough quantity.
            if (existingItem != null && existingItem.Quantity >= quantity)
            {
                existingItem.Quantity -= quantity;

                // Remove the inventory entry when its quantity reaches zero.
                if (existingItem.Quantity <= 0)
                {
                    items.Remove(existingItem);
                }

                return true;
            }

            return false;
        }

        return false;
    }

    public InventoryItem FindItem(ItemData itemToSearch)
    {
        foreach (InventoryItem item in items)
        {
            // Compare itemData references to find the matching item in the list.
            if (itemToSearch == item.ItemData &&
                item.Quantity <= item.ItemData.MaxStackSize)
            {
                return item;
            }
        }

        return null;
    }

    public bool UseItem(int index)
    {
        // Validate the index to prevent accessing an invalid inventory entry.
        if (index >= 0 && index < items.Count)
        {
            Debug.Log("use item");

            InventoryItem itemToUse = items[index];

            // Execute the item's assigned behaviour.
            // The item is consumed only if its usage returns true.
            if (itemToUse.ItemData.itemUsage.Use(gameObject, itemToUse.ItemData))
            {
                RemoveItem(itemToUse.ItemData, 1);
                return true;
            }

            return false;
        }
        else
        {
            return false;
        }
    }
}

