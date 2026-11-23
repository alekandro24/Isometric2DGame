using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float maxSpeed = 6f;
    [Tooltip("Use 0 for instant acceleration")]
    [SerializeField] private float acceleration = 0f;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }


    public void MovePlayer(Vector2 moveVector)
    {
        animator.SetBool("IsRunning", false);
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
        if (normalizedMoveInput.magnitude > 0f)
        {
            animator.SetBool("IsRunning", true);
        }
        if (normalizedMoveInput.x > 0.01f)
        {
            spriteRenderer.flipX = false;
        }
        else if (normalizedMoveInput.x < -0.01f)
        {
            spriteRenderer.flipX = true;
        }
    }
}
