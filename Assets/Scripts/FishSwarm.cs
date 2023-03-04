using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSwarm : MonoBehaviour
{
    [SerializeField]
    Fish spawnTarget;

    public List<Fish> swarm { get; private set; } = new List<Fish>();
    public Vector2 avgVelocity { get; private set; } = Vector2.zero;
    public Vector2 avgPos { get; private set; } = Vector2.zero;

    public Vector2 blBound { get; private set; }
    public Vector2 trBound { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 20; i++) {
            var fish = Instantiate(spawnTarget);
            swarm.Add(fish);
            fish.transform.position = 
                new Vector3(Random.Range(-8f, -1f), Random.Range(0f, 2f), transform.position.z);
            fish.transform.parent = transform;
            fish.swarm = this;
        }

        blBound = GetComponent<BoxCollider2D>().bounds.min;
        trBound = GetComponent<BoxCollider2D>().bounds.max;
        Debug.Log(blBound);
        Debug.Log(trBound);
    }

    // Update is called once per frame
    void Update()
    {
        avgVelocity = Vector2.zero;
        avgPos = Vector2.zero;
        foreach (var fish in swarm) {
            avgPos += (Vector2) fish.transform.position;
            avgVelocity += fish.velocity;
        }
        avgVelocity /= swarm.Count;
        avgPos /= swarm.Count;
        avgPos = (avgPos + (Vector2) transform.position) / 2;
    }
}
