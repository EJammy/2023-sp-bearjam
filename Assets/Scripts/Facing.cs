using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Facing : MonoBehaviour
{
    Vector2 lastPos = Vector2.zero;
    // Update is called once per frame
    void Update()
    {
        if (transform.position.x - lastPos.x > 0) {
            GetComponent<SpriteRenderer>().flipX = false;
        }

        if (transform.position.x - lastPos.x < 0) {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        lastPos = transform.position;
        
    }
}
