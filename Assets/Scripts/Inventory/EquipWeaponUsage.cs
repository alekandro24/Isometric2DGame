using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/Usages/Equip Weapon")]
public class EquipWeaponUsage : ItemUsage
{
    public override bool Use(GameObject user, ItemData itemData)
    {
        EquipmentManager equipmentManager = user.GetComponent<EquipmentManager>();
        if (equipmentManager != null)
        {
            equipmentManager.EquipWeapon(itemData);
            return true;
        }
        return false;
    }
}
