using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/Usages/Equip Armor")]
public class EquipArmorUsage : ItemUsage
{
    public override bool Use(GameObject user, ItemData itemData)
    {
        EquipmentManager equipmentManager = user.GetComponent<EquipmentManager>();
        if (equipmentManager != null)
        {
            equipmentManager.EquipArmor(itemData);
            return true;
        }
        return false;
    }
}
