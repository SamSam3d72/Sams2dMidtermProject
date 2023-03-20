using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 7f;
    public float jumpForce = 14f;
    public float jumpDelay = 0.2f; // Add a small delay before the player can jump again after landing
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private float moveInput;
    private bool canJump = true; // Add a boolean variable to track whether the player can jump

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        if (moveInput < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (moveInput > 0)
        {
            spriteRenderer.flipX = false;
        }

        if (Input.GetButton("Jump") && canJump) // Use GetButton instead of GetButtonDown
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, 0);
            canJump = false; // Set the canJump variable to false when the player jumps
            Invoke("ResetJump", jumpDelay); // Reset the canJump variable after a small delay
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = true; // Set the canJump variable to true when the player lands on the ground
        }
    }

    private void ResetJump()
    {
        canJump = true; // Reset the canJump variable after the jumpDelay time has passed
    }
}
