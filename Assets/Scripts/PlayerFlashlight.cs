using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlashlight : MonoBehaviour
{
    [SerializeField] GameObject light;
    // Update is called once per frame
    void Update()
    {
        if (Statics.hasControl)
        {
            Vector2 mouseVector = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 centeredVector = mouseVector - GetComponent<Rigidbody2D>().position;
            light.transform.eulerAngles = new Vector3(0, 0, Vector2.SignedAngle(Vector2.up, centeredVector));
        }
    }
}
