using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LUcTrgBir : MonoBehaviour
{
    public TextMeshProUGUI triggerYaziBir;
    public AudioClip triggerSesiBir;
    AudioSource audioSource;
    public LevelUcZaman zaman;
    float dakika_;
    bool  triggerdeMi = false;
    int sayi = 0;
    void Start()
    {
        triggerYaziBir.gameObject.SetActive(false);
        audioSource = GetComponent<AudioSource>();
        dakika_ = zaman.dakika;
    }

    // Update is called once per frame
    void Update()
    {
        dakika_ = zaman.dakika;
        

       
            if (dakika_ <= 8&&triggerdeMi==true&&sayi==0)
            {
                StartCoroutine(TriggerBirCourotine());
                
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

    IEnumerator TriggerBirCourotine()
    {
        triggerYaziBir.gameObject.SetActive(true);
        audioSource.PlayOneShot(triggerSesiBir);
        yield return new WaitForSecondsRealtime(4f);
        triggerYaziBir.gameObject.SetActive(false);
    }

   
}
