using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    [SerializeField]
    GameObject bloodParticles;

    public int coinDrop = 0;

    public void kill() {
        Destroy(gameObject);
    }

    public void emmitBlood() {
        Instantiate(bloodParticles, transform.position, Quaternion.identity);
    }
}
