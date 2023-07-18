using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenuMusic : MonoBehaviour
{
    AudioSource auSource;
    public AudioClip settingsMusic;

    private void Start()
    {
        auSource = GetComponent<AudioSource>();
        auSource.PlayOneShot(settingsMusic);
    }
}
