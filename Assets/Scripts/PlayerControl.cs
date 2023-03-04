using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Rigidbody2D rb;
    const float controlForce = 10;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Statics.player = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Statics.hasControl)
        {
            Vector2 force = Vector2.zero;
            if (Input.GetKey(KeyCode.W))
            {
                force += Vector2.up;
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

            rb.AddForce(force * controlForce);
            // Debug.Log(rb.velocity);
        }
    }
}
