using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGravity : MonoBehaviour
{
    [SerializeField] BoxCollider2D waterCheck;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (waterCheck.IsTouchingLayers(LayerMask.GetMask("Water")))
        {
            GetComponent<Rigidbody2D>().gravityScale = 0.3f;
            GetComponent<Rigidbody2D>().drag = 4;
        } else
        {
            GetComponent<Rigidbody2D>().gravityScale = 2;
            GetComponent<Rigidbody2D>().drag = 2;
        }

    }
}
