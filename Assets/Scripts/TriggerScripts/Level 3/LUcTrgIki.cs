using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LUcTrgIki : MonoBehaviour
{
    
    public AudioClip triggerSesiIki;
    AudioSource audioSource;
    public LevelUcZaman zaman;
    float dakika_;
    bool triggerdeMi = false;
    int sayi = 0;
    void Start()
    {
       
        audioSource = GetComponent<AudioSource>();
        dakika_ = zaman.dakika;
    }

    // Update is called once per frame
    void Update()
    {
        dakika_ = zaman.dakika;



        if (dakika_ <= 7 && triggerdeMi == true && sayi == 0)
        {
            audioSource.PlayOneShot(triggerSesiIki);

            sayi++;
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            triggerdeMi = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            triggerdeMi = false;
        }
    }

   
}
