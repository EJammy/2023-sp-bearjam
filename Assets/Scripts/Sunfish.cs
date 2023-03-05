using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Craig Reynolds Boids flocking simulation
 */
public class Sunfish : MonoBehaviour
{
    const float xVelocity = 0.2f;
    const float c1 = 0.1f;
    const float c2 = 0.6f;
    float yPos;

    float currentTime = 0;

    [SerializeField]
    GameObject bloodParticles;

    public void kill() {
        Instantiate(bloodParticles, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void Start() {
        yPos = transform.position.y;
    }

    void Update()
    {
        var pos = transform.position;
        pos.x += xVelocity * Time.deltaTime;
        pos.y = Mathf.Sin(c1 * currentTime * Mathf.PI) * c2 + yPos;
        currentTime += Time.deltaTime;
        transform.position = pos;
    }
}
