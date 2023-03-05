using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Status : MonoBehaviour
{
    [SerializeField]
    int val = 1;

    [SerializeField]
    [Tooltip("Event when value reaches zero")]
    UnityEvent zeroCallback;

    public void reduce(int amt) {
        val -= amt;
        if (val <= 0) {
            zeroCallback?.Invoke();;
        }
    }
}
