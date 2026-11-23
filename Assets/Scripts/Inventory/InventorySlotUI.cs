
using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour, IPointerClickHandler
{
    [Header("SlotReference")]
    [SerializeField] private Image itemIcon;
    [SerializeField] private TMP_Text quantityText;

    private int slotIndex;

    // Send the slot index to the inventory UI manager when the slot is double-clicked.
    public event Action<int> OnDoubleClick;

    public void Initialize(int index)
    {
        slotIndex = index;
        ClearSlot();
    }

    public void SetSlot(Sprite icon, int quantity)
    {
        itemIcon.sprite = icon;

        if (icon != null)
        {
            itemIcon.enabled = true;
            quantityText.text = quantity.ToString();
        }
        else
        {
            ClearSlot();
        }
    }

    public void ClearSlot()
    {
        itemIcon.sprite = null;
        itemIcon.enabled = false;
        quantityText.text = "";
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // Only respond to double-clicks with the left mouse button.
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (eventData.clickCount >= 2)
            {
                OnDoubleClick?.Invoke(slotIndex);
            }
        }
    }
}

