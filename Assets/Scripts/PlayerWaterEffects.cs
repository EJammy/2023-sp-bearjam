using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWaterEffects : MonoBehaviour
{
    Animator animator;

    [SerializeField] BoxCollider2D waterCheck;
    [SerializeField] GameObject light;

    [SerializeField] RuntimeAnimatorController waterAnimator;
    [SerializeField] RuntimeAnimatorController landAnimator;

    // Update is called once per frame
    void FixedUpdate()
    {
        // GetComponent<Animation>().Play("walk_0");
        if (waterCheck.IsTouchingLayers(LayerMask.GetMask("Water")))
        {
            GetComponent<Rigidbody2D>().gravityScale = 0.3f;
            GetComponent<Rigidbody2D>().drag = 4;
        } else
        {
            GetComponent<Rigidbody2D>().gravityScale = 2;
            GetComponent<Rigidbody2D>().drag = 2;
            // GetComponent<Animator>().runtimeAnimatorController = landAnimator;
            // GetComponent<Animation
        }

    }
}
