using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadMusic : MonoBehaviour
{
    AudioSource auSource;
    public AudioClip deadMusic;

    private void Start()
    {
        auSource = GetComponent<AudioSource>();
        auSource.PlayOneShot(deadMusic);
    }
}
