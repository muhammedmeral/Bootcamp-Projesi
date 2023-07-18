using UnityEngine;

public class TriggerBir : MonoBehaviour
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

        if (nDakika <= 5 && girdiMi == true && girmeSayisi == 0) //triggerin tetiklenme zaman� ve di�er �artlar�n� belirttik.
        {
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
