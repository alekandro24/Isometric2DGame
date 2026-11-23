using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PickupItem : MonoBehaviour
{
    [SerializeField] private ItemData itemData;
    [SerializeField] private int quantity = 1;
    private SpriteRenderer spriteRenderer;
    public ItemData ItemData { get => itemData; }
    public int Quantity { get => quantity; }


    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = itemData.Icon;
    }

    public void Pickup(InventoryManager inventory) 
    {
        if (inventory.AddItem(itemData, quantity)) 
        {
            Destroy(this.gameObject);
        }
    }
}
