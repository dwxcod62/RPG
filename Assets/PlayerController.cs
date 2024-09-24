using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    bool IsMoving
    {
        set
        {
            isMoving = value;
            animator.SetBool("isMoving", isMoving);
        }
    }
    public float moveSpeed = 100f;
    public float maxSpeed = 8f;
    public float idleFriction = 0.9f;

    public GameObject SwordHitbox;

    bool isMoving = false;
    bool canMove = true;

    Vector2 movementInput;
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {

        {
            if (canMove && movementInput != Vector2.zero)
            {
                // ClampMagnitude ensures that the vector will not exceed the given length
                rb.velocity = Vector2.ClampMagnitude(rb.velocity + (movementInput * moveSpeed * Time.deltaTime), maxSpeed);

                // Set direction of sprite to movement direction
                if (movementInput.x < 0)
                {
                    spriteRenderer.flipX = true;
                }
                else if (movementInput.x > 0)
                {
                    spriteRenderer.flipX = false;
                }
                IsMoving = true;

            }
            else
            {
                // rb.velocity = Vector2.Lerp(rb.velocity, Vector2.zero, idleFriction);
                IsMoving = false;
            }
        }
    }
    // --------------------------------------

    void LockMovement()
    {
        canMove = false;
    }

    void UnLockMovement()
    {
        canMove = true;
    }

    // --------------------------------------
    void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();
    }

    void OnFire()
    {
        animator.SetTrigger("isAttack");
    }
}
