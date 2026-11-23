
using System;
using UnityEngine;

[RequireComponent(typeof(InventoryManager))]
public class EquipmentManager : MonoBehaviour
{
    private ItemData equippedWeapon;
    private ItemData equippedArmor;

    private InventoryManager inventory;

    // Notify UI components when the player's equipment changes.
    public event Action OnEquipmentChanged;

    public ItemData EquippedWeapon { get => equippedWeapon; }
    public ItemData EquippedArmor { get => equippedArmor; }

    private void Awake()
    {
        inventory = GetComponent<InventoryManager>();
    }

    public void EquipWeapon(ItemData weapon)
    {
        if (weapon != null)
        {
            // Return the previously equipped weapon to the inventory.
            if (equippedWeapon != null)
            {
                inventory?.AddItem(equippedWeapon, 1);
            }

            equippedWeapon = weapon;

            Debug.Log("Equipped Weapon: " + equippedWeapon);

            // Refresh any UI that displays the equipped weapon.
            OnEquipmentChanged?.Invoke();
        }
    }

    public void EquipArmor(ItemData armor)
    {
        if (armor != null)
        {
            // Return the previously equipped armor to the inventory.
            if (equippedArmor != null)
            {
                inventory?.AddItem(equippedArmor, 1);
            }

            equippedArmor = armor;

            Debug.Log("Equipped Armor: " + equippedArmor);

            // Refresh any UI that displays the equipped armor.
            OnEquipmentChanged?.Invoke();
        }
    }
}

