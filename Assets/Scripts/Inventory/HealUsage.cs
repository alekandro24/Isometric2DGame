using System;
using UnityEngine;

[CreateAssetMenu(menuName ="Inventory/Usages/Heal")]
public class HealUssage : ItemUsage
{
    [SerializeField] private int healAmount = 25;
    public override bool Use(GameObject user, ItemData itemData)
    {
        PlayerHealth health = user.GetComponent<PlayerHealth>();
        if (health != null)
        {
            health.Heal(healAmount);
            return true;
        }
        return false;
    }
}
