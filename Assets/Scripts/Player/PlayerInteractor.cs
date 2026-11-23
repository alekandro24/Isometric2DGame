
using UnityEngine;

[RequireComponent(typeof(InventoryManager))]
[RequireComponent(typeof(CircleCollider2D))]
public class PlayerInteractor : MonoBehaviour
{
    private InventoryManager inventory;
    private PickupItem nearbyPickup;
    private SpriteRenderer nearbyRenderer;

    private CircleCollider2D circleCollider2D;

    [SerializeField] private float interactRange = 5f;

    private void Awake()
    {
        inventory = GetComponent<InventoryManager>();
        circleCollider2D = GetComponent<CircleCollider2D>();

        circleCollider2D.isTrigger = true;
        circleCollider2D.radius = interactRange;
    }

    public void TryInteract()
    {
        if (inventory != null)
        {
            // Attempt to collect the currently selected nearby pickup.
            nearbyPickup?.Pickup(inventory);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PickupItem pickUp = collision.GetComponent<PickupItem>();

        if (pickUp != null)
        {
            // Highlight the most recently entered pickup and restore the previous one.
            ClearHighLight();

            nearbyRenderer = pickUp.GetComponent<SpriteRenderer>();
            nearbyPickup = pickUp;

            if (nearbyRenderer != null)
            {
                nearbyRenderer.color = new Color32(255, 235, 4, 255);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PickupItem pickUp = collision.GetComponent<PickupItem>();

        // Only clear the selection if the pickup leaving is the currently selected one.
        if (pickUp != null && nearbyPickup == pickUp)
        {
            ClearHighLight();
            nearbyPickup = null;
            nearbyRenderer = null;
        }
    }

    private void ClearHighLight()
    {
        if (nearbyRenderer != null)
        {
            // Restore the sprite default white tint.
            nearbyRenderer.color = new Color32(255, 255, 255, 255);
        }
    }
}

