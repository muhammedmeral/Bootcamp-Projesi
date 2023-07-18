using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseMusic : MonoBehaviour
{
    AudioSource auSource;
    public AudioClip loseMusic;

    private void Start()
    {
        auSource = GetComponent < AudioSource>();
        auSource.PlayOneShot(loseMusic);
    }
}
