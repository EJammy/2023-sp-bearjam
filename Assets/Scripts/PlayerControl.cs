using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float controlForce = 5;
    [SerializeField] private float maxSpeed = 10;
    [SerializeField] private BoxCollider2D waterCheck;
    [SerializeField] private BoxCollider2D groundCheck;
    private bool isJumping;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Statics.player = this.gameObject;
        isJumping = false;
    }

    void FixedUpdate()
    {
        if (Statics.hasControl)
        {
            Vector2 force = Vector2.zero;
            if (Input.GetKey(KeyCode.W))
            {
                if (waterCheck.IsTouchingLayers(LayerMask.GetMask("Water")))
                {
                    force += Vector2.up;
                }
            }
            if (Input.GetKey(KeyCode.S))
            {
                force += Vector2.down;
            }
            if (Input.GetKey(KeyCode.A))
            {
                force += Vector2.left;
            }
            if (Input.GetKey(KeyCode.D))
            {
                force += Vector2.right;
            }
            if (isJumping)
            {
                force += Vector2.up * 10;
                isJumping = false;
            }

            rb.AddForce(force * controlForce);

            rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -maxSpeed, maxSpeed), Mathf.Clamp(rb.velocity.y, -maxSpeed, maxSpeed));

            // Debug.Log(rb.velocity);
        }
    }

    private void Update()
    {
        if (Statics.hasControl)
        {
            Vector2 force = Vector2.zero;
            if (Input.GetKey(KeyCode.W) && !waterCheck.IsTouchingLayers(LayerMask.GetMask("Water")))
            {
                if (groundCheck.IsTouchingLayers(LayerMask.GetMask("Water")) || groundCheck.IsTouchingLayers(LayerMask.GetMask("Ground")))
                {
                    isJumping = true;
                }
            }
        }

    }
}
