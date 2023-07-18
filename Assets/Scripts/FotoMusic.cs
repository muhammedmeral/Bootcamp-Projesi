using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FotoMusic : MonoBehaviour
{
    AudioSource auSource;
    public AudioClip fotoMusic;

    private void Start()
    {
        auSource = GetComponent<AudioSource>();
        auSource.PlayOneShot(fotoMusic);
    }
}
