

using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUIManager : MonoBehaviour
{
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private Transform inventoryGrid;
    [SerializeField] private InventorySlotUI slotPrefab;

    [SerializeField] private InventoryManager inventoryManager;
    private List<InventorySlotUI> slots = new List<InventorySlotUI>();

    private bool isOpen = false;

    private void Awake()
    {
        inventoryPanel.SetActive(false);
        isOpen = false;

        // Create the UI slots once, based on the inventory's capacity.
        CreateSlots();
    }

    public void ToggleInventory()
    {
        isOpen = !isOpen;
        inventoryPanel.SetActive(isOpen);

        // Refresh the displayed items whenever the inventory is opened.
        if (isOpen)
        {
            RefreshInventory();
        }
    }

    private void CreateSlots()
    {
        for (int i = 0; i < inventoryManager.InventoryCapacity; i++)
        {
            InventorySlotUI slot = Instantiate(slotPrefab, inventoryGrid);

            // Store the slot's inventory index so its UI can report which item was clicked.
            slot.Initialize(i);

            slot.OnDoubleClick += HandleSlotDoubleClick;
            slots.Add(slot);
        }
    }

    private void HandleSlotDoubleClick(int index)
    {
        // Refresh the UI only when the item was successfully used.
        if (inventoryManager.UseItem(index))
        {
            RefreshInventory();
        }
    }

    public void RefreshInventory()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (i < inventoryManager.Items.Count)
            {
                InventoryItem item = inventoryManager.Items[i];

                // Display the item icon and its current stack quantity.
                slots[i].SetSlot(item.ItemData.Icon, item.Quantity);
            }
            else
            {
                // Clear slots that no longer contain an inventory item.
                slots[i].ClearSlot();
            }
        }
    }
}

