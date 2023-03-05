using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    const float cooldown = 2;
    float cd = 0;

    // Update is called once per frame
    void Update()
    {
        if (cd > 0) {
            cd -= Time.deltaTime;
        } else if (Input.GetKey(KeyCode.Mouse0)) {
            Vector2 pos = transform.position;
            Vector2 dir = (Vector2) Camera.main.ScreenToWorldPoint(Input.mousePosition) - pos;
            var target = Physics2D.OverlapCircle(pos + dir.normalized, 0.5f, LayerMask.GetMask("Fish"));
            target?.GetComponent<Status>().reduce(1);

            var envTarget = Physics2D.OverlapCircle(pos + dir.normalized, 0.5f, LayerMask.GetMask("Destructable"));
            envTarget?.GetComponent<Status>().reduce(1);
            cd = cooldown;
        }
    }
}
