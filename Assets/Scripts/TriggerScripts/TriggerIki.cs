using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerIki : MonoBehaviour
{
    AudioSource sescalma;
    public AudioClip triggerSesi;

    float nDakika; // zaman sayacý scriptindeki zaman deðiþkenlerini tutacak deðiþkenlerimiz.
    
    public zaman_sayaci zamansc; //Dakika ve saniyeyi çekeceðimiz script
    bool girdiMi; // Karakterin triggerin içinde olup olmadýðýný kontrol edecek deðiþken.
    int girmeSayisi = 0; //Sesin bir kere çalmasý için kullaancaðýmýz deðiþken.


    void Start()
    {
        sescalma = GetComponent<AudioSource>();

    }


    void Update()
    {
        if (zamansc != null) //deðiþkenleri eþitledik.
        {
            nDakika = zamansc.Dakika();
            
        }

        if (nDakika <= 4 && girdiMi == true && girmeSayisi == 0) //triggerin tetiklenme zamaný ve diðer þartlarýný belirttik.
        { //Bu kýsýmda triggerde olacak olaylar belirtilecek.
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