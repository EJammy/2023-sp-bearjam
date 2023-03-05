using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Craig Reynolds Boids flocking simulation
 */
public class SwarmMovement : MonoBehaviour
{
    public Vector2 targetPos { get; set; }
    public Vector2 velocity { get; private set; }
    public FishSwarm swarm { get; set; }

    const float cohesionFactor = 1f;
    const float alignmentFactor = 1f;
    const float seperationFactor = 12f;
    const float maxVelocity = 6f;
    const float LOS = 2f;

    Collider2D[] getNearBy(float dist) {
        return Physics2D.OverlapCircleAll(transform.position, dist, LayerMask.GetMask("Fish"));
    }

    void Update()
    {
        // Cohesion
        // steer toward target pos, which equals the center of mass in the original program
        var avgPos = Vector2.zero;
        var avgVelocity = Vector2.zero;
        var others = getNearBy(LOS);
        foreach (var otherFish in others) {
            avgPos += (Vector2) otherFish.transform.position;
            avgVelocity += otherFish.GetComponent<SwarmMovement>().velocity;
        }
        avgPos /= others.Length;
        avgVelocity /= others.Length;

        targetPos = avgPos;

        Vector2 targetDir = targetPos - new Vector2(transform.position.x, transform.position.y);
        velocity += targetDir.normalized * Time.deltaTime * cohesionFactor;

        // Alignment
        velocity += (avgVelocity - velocity) * Time.deltaTime * alignmentFactor;

        // Seperation
        Vector2 nearBy = Vector2.zero;
        var othersList = getNearBy(0.2f);
        foreach (var otherFish in othersList) {
            Vector2 diff = otherFish.transform.position - transform.position;
            nearBy += diff.normalized;
        }

        velocity -= nearBy.normalized * Time.deltaTime * seperationFactor;

        // Bound
        float boundFactor = 10f;
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
