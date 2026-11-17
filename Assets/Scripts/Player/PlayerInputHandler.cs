using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerInputHandler : MonoBehaviour
{
    private InputAction moveInput;
    //script that receives a vector2D and moves the character
    private PlayerMovement playerMovement;
    private Vector2 moveVector = new Vector2(0f, 0f);
    private void Awake()
    {
        moveInput = InputSystem.actions.FindAction("Player/Move");
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        //read the value of the movement input
        moveVector = moveInput.ReadValue<Vector2>();
    }
    void FixedUpdate()
    {
        //calls the movement function in player movement and sends the vector2D
        playerMovement.MovePlayer(moveVector);
    }
}
