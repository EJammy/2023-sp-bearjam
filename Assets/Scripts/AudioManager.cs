using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    static private AudioManager instance;

    void Awake() {
        instance = this;
    }

    static public void Play(AudioClip target) {
        instance.GetComponent<AudioSource>().PlayOneShot(target);
    }
}
