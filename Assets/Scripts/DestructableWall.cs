using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableWall : MonoBehaviour
{
    public void Destruct() {
        // TODO: create particle
        Destroy(gameObject);
    }
}
