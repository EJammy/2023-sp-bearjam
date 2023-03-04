using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Craig Reynolds Boids flocking simulation
 */
public class Fish : MonoBehaviour
{
    public Vector2 targetPos { get; set; }
    public Vector2 velocity { get; private set; }
    public FishSwarm swarm;

    const float cohesionFactor = 2f;
    const float alignmentFactor = 2f;
    const float seperationFactor = 2f;
    const float maxVelocity = 6f;

    void Start()
    {
        targetPos = new Vector2(0.9f, -0.2f);
    }

    void Update()
    {
        // Cohesion
        // steer toward target pos, which equals the center of mass in the original program
        targetPos = swarm.avgPos;
        Vector2 targetDir = targetPos - new Vector2(transform.position.x, transform.position.y);
        velocity += targetDir.normalized * Time.deltaTime * cohesionFactor;

        // Alignment
        velocity += (swarm.avgVelocity - velocity) * Time.deltaTime * alignmentFactor;

        // Seperation
        Vector2 nearBy = Vector2.zero;
        int cnt = 0;
        foreach (var otherFish in swarm.swarm) {
            Vector2 diff = otherFish.transform.position - transform.position;
            if (diff.magnitude < 0.4 && otherFish != this) {
                nearBy += diff.normalized;
                cnt += 1;
            }
        }
        nearBy /= cnt;
        velocity -= nearBy.normalized * Time.deltaTime * seperationFactor;

        // Bound
        float boundFactor = 2f;
        if (transform.position.x < swarm.blBound.x) {
            velocity += Vector2.right * Time.deltaTime * boundFactor;
        }
        if (transform.position.x > swarm.trBound.x) {
            velocity += Vector2.left * Time.deltaTime * boundFactor;
        }
        if (transform.position.y < swarm.blBound.y) {
            velocity += Vector2.up * Time.deltaTime * boundFactor;
        }
        if (transform.position.y > swarm.trBound.y) {
            velocity += Vector2.down * Time.deltaTime * boundFactor;
        }

        if (velocity.magnitude >= maxVelocity) {
            velocity = velocity.normalized * maxVelocity;
        }
        transform.rotation = Quaternion.LookRotation(Vector3.forward, velocity);
        transform.position += (Vector3) velocity * Time.deltaTime;
        Debug.DrawLine(targetPos - Vector2.left, targetPos);
    }
}
