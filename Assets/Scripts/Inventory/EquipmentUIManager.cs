
using UnityEngine;
using UnityEngine.UI;

public class EquipmentUIManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private EquipmentManager equipmentManager;

    [SerializeField] private Image weaponIcon;
    [SerializeField] private Image armorIcon;

    private void OnEnable()
    {
        // Subscribe to equipment changes so the UI updates automatically.
        equipmentManager.OnEquipmentChanged += RefreshEquipmentUI;

        // Update the UI immediately when this component becomes enabled.
        RefreshEquipmentUI();
    }

    private void OnDisable()
    {
        // Unsubscribe while disabled.
        equipmentManager.OnEquipmentChanged -= RefreshEquipmentUI;
    }

    public void RefreshEquipmentUI()
    {
        UpdateSlot(weaponIcon, equipmentManager.EquippedWeapon);
        UpdateSlot(armorIcon, equipmentManager.EquippedArmor);
    }

    private void UpdateSlot(Image slotIcon, ItemData item)
    {
        // Hide the icon when the equipment slot is empty or has no assigned sprite.
        if (item != null && item.Icon != null)
        {
            slotIcon.sprite = item.Icon;
            slotIcon.enabled = true;
        }
        else
        {
            slotIcon.sprite = null;
            slotIcon.enabled = false;
        }
    }
}

