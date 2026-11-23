using System;
using UnityEngine;
// Abstract base class for child ScriptableObject classes representing distinct item usages, ensuring scalability.
public abstract class ItemUsage : ScriptableObject
{
    public abstract bool Use(GameObject user, ItemData itemData);
}
