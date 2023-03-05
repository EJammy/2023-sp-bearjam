using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSwarm : MonoBehaviour
{
    [SerializeField]
    SwarmMovement spawnTarget;
    [SerializeField]
    int spawnCnt = 10;

    // public List<SwarmMovement> swarm { get; private set; } = new List<SwarmMovement>();
    // public Vector2 avgVelocity { get; private set; } = Vector2.zero;
    // public Vector2 avgPos { get; private set; } = Vector2.zero;
    public Vector2 randomTarget { get; private set; }

    public Vector2 blBound { get; private set; }
    public Vector2 trBound { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        blBound = GetComponent<BoxCollider2D>().bounds.min;
        trBound = GetComponent<BoxCollider2D>().bounds.max;

        for (int i = 0; i < spawnCnt; i++) {
            var fish = Instantiate(spawnTarget);
            // swarm.Add(fish);
            fish.transform.position = new Vector3(
                    Random.Range(blBound.x, trBound.x),
                    Random.Range(blBound.y, trBound.y),
                    transform.position.z
                    );
            fish.swarm = this;
        }

        StartCoroutine(setRandomPoint());
    }

    // Update is called once per frame
    void Update()
    {
        // avgVelocity = Vector2.zero;
        // avgPos = Vector2.zero;
        // foreach (var fish in swarm) {
        //     avgPos += (Vector2) fish.transform.position;
        //     avgVelocity += fish.velocity;
        // }
        // avgVelocity /= swarm.Count;
        // avgPos /= swarm.Count;
        // avgPos = (avgPos + (Vector2) randomTarget) / 2;
    }

    IEnumerator setRandomPoint() {
        while (true) {
            randomTarget = new Vector2(
                    Random.Range(blBound.x, trBound.x),
                    Random.Range(blBound.y, trBound.y)
                    );
            yield return new WaitForSeconds(4);
        }
    }
}

