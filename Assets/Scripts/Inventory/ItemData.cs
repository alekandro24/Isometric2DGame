using UnityEngine;

public enum ItemType
{
    Consumable, Weapon, Armor, Jewelry,
}

[CreateAssetMenu(menuName = "Inventory/InventoryItem")]
public class ItemData : ScriptableObject
{
    [Header("Item Information")]
    public string ItemName;
    public string ItemDescription;
    public int ItemValue;
    public Sprite Icon;

    [Header("Item Properties")]
    public ItemType ItemType;
    public bool IsStackable = true;
    [Min(1)]
    public int MaxStackSize = 10;
    
    public ItemUsage itemUsage;
}
