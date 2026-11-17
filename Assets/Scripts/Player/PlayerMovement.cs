using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float maxSpeed = 6f;
    [Tooltip("Use 0 for instant acceleration")]
    [SerializeField] private float acceleration = 0f;
    private Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    public void MovePlayer(Vector2 moveVector)
    {
        //normalized vector to avoid faster movement diagonally
        Vector2 normalizedMoveInput = moveVector.normalized;
        Vector2 targetVelocity = normalizedMoveInput * maxSpeed;
        if (acceleration <= 0f)
        {
            //instant acceleration
            rb.linearVelocity = targetVelocity;
        }
        else
        {
            //gradual acceleration
            rb.linearVelocity = Vector2.MoveTowards(rb.linearVelocity, targetVelocity, acceleration * Time.fixedDeltaTime);
        }
    }
}
