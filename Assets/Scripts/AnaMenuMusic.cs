using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnaMenuMusic : MonoBehaviour
{
    AudioSource ausource;
    public AudioClip anaMenuMusic;

    private void Start()
    {
        ausource = GetComponent<AudioSource>();
        ausource.PlayOneShot(anaMenuMusic);
    }

    
}
