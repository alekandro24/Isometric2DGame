using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerInputHandler : MonoBehaviour
{
    private InputAction moveInput;
    private InputAction interactInput;
    private InputAction inventoryInput;
    //script that receives a vector2D and moves the character
    private PlayerMovement playerMovement;
    private PlayerInteractor playerInteractor;
    [SerializeField]private InventoryUIManager inventoryUIManager;
    private Vector2 moveVector = new Vector2(0f, 0f);
    private void Awake()
    {
        moveInput = InputSystem.actions.FindAction("Player/Move");
        interactInput = InputSystem.actions.FindAction("Player/Interact");
        inventoryInput = InputSystem.actions.FindAction("Player/Inventory");
        playerMovement = GetComponent<PlayerMovement>();
        playerInteractor = GetComponent<PlayerInteractor>();
    }

    private void Update()
    {
        //read the value of the movement input
        moveVector = moveInput.ReadValue<Vector2>();
        //detects the input for interact, interacts with the selected item and updates inventory
        if (interactInput != null && interactInput.WasPressedThisFrame())
        {
            playerInteractor?.TryInteract();
            inventoryUIManager.RefreshInventory();
        }
        //detects the input to toggle the inventory and calls an event to open and close it
        if (inventoryInput != null && inventoryInput.WasPressedThisFrame())
        {
            inventoryUIManager?.ToggleInventory();
        }
    }
    void FixedUpdate()
    {
        //calls the movement function in player movement and sends the vector2D
        playerMovement.MovePlayer(moveVector);
    }
}
