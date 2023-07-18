using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMusic : MonoBehaviour
{
    AudioSource auSource;
    public AudioClip levelMusic;

    private void Start()
    {
        auSource = GetComponent<AudioSource>();
        auSource.PlayOneShot(levelMusic);
    }
}
