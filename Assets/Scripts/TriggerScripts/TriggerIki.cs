using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerIki : MonoBehaviour
{
    AudioSource sescalma;
    public AudioClip triggerSesi;

    float nDakika; // zaman sayac� scriptindeki zaman de�i�kenlerini tutacak de�i�kenlerimiz.
    
    public zaman_sayaci zamansc; //Dakika ve saniyeyi �ekece�imiz script
    bool girdiMi; // Karakterin triggerin i�inde olup olmad���n� kontrol edecek de�i�ken.
    int girmeSayisi = 0; //Sesin bir kere �almas� i�in kullaanca��m�z de�i�ken.


    void Start()
    {
        sescalma = GetComponent<AudioSource>();

    }


    void Update()
    {
        if (zamansc != null) //de�i�kenleri e�itledik.
        {
            nDakika = zamansc.Dakika();
            
        }

        if (nDakika <= 4 && girdiMi == true && girmeSayisi == 0) //triggerin tetiklenme zaman� ve di�er �artlar�n� belirttik.
        { //Bu k�s�mda triggerde olacak olaylar belirtilecek.
            if (!sescalma.isPlaying)
            {
                sescalma.PlayOneShot(triggerSesi);
                girmeSayisi++;



            }

        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            girdiMi = true;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            girdiMi = false;

        }
    }
}