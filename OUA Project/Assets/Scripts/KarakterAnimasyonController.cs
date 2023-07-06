using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarakterAnimasyonController : MonoBehaviour
{
    //crosshair birden fazla fonksiyonun i�inde kullan�lacak(silah tutma,ate� etme, kamera tutma,foto�raf �ekme vs.) unutma!!!!

    public Animator anim; //1.Animator bile�eninden anim isimli bir nesne olu�turuldu.
    public GameObject elKamerasi; //2.karakterin elindeki kameray� animasyonlar s�ras�nda a��p kapatmak i�in kulland���m�z de�i�ken.
    public GameObject pistol; //3.karakterin elindeki pistol� animasyonlar s�ras�nda a��p kapatmak i�in kulland���m�z de�i�ken.
    bool elindeSilahVar = true; //4.karakterin elindeki nesneden di�er nesnelere ge�i�te animasyon �ak��mas� olmamas� i�in kulland���m�z de�i�ken.
    bool elindeKameraVar = false; //5.karakterin elindeki nesneden di�er nesnelere ge�i�te animasyon �ak��mas� olmamas� i�in kulland���m�z de�i�ken.
    void Start()
    {
        elKamerasi.SetActive(false); //12.ba�lang��ta olmas�n� istedi�imiz durumlar� sa�lamak i�in(elinde silah olmas�, silah�n g�r�n�r olmas� vs.) atad���m�z de�erler
        elindeSilahVar = true; //12.1 ba�lang��ta olmas�n� istedi�imiz durumlar� sa�lamak i�in(elinde silah olmas�, silah�n g�r�n�r olmas� vs.) atad���m�z de�erler
        elindeKameraVar = false; //12.2 ba�lang��ta olmas�n� istedi�imiz durumlar� sa�lamak i�in(elinde silah olmas�, silah�n g�r�n�r olmas� vs.) atad���m�z de�erler
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && elindeSilahVar == true) //14.atanan tu�a bas�ld���nda ve karakterin elinde silah varsa ate� etme fonksiyonu �al���r.
        {
            AtesEtme(); 
            //ate� edildi�inde hasar verme sistemi daha sonra burada kullan�lacak.
        }

        else //15.e�er 14.maddedeki �artlar sa�lanm�yorsa ate� etme animasyonunun durmas� sa�lan�r.
        {
            anim.SetBool("atesEdiyorMu", false);
        }

        if (Input.GetMouseButtonDown(0) && elindeKameraVar == true) //14.1 atanan tu�a bas�ld���nda ve karakterin elinde kamera varsa foto�raf �ekme fonksiyonu �al���r.
        {
            FotoCekme();
            //foto�raf �ekildi�inde foto�raflar�n depolamada kaydedilmesi ve foto�raf �ekilme s�ras�nda raycast y�ntemiyle sorgulaman�n yap�lmas� i�lemleri buraya gelicek.
        }

        else //15.1 e�er 14.1.maddedeki �artlar sa�lanm�yorsa foto�raf �ekme animasyonunun durmas� sa�lan�r.
        {
            anim.SetBool("fotoCekiyorMu", false);
        }

        if (Input.GetKeyDown(KeyCode.P) && elindeSilahVar == true) //13.atad���m�z tu�a bas�ld���nda karakter silah� b�rak�p kameray� al�r. 4 ve 5. maddedeki de�i�kenlere olmas� gereken de�erler atand�. 
        {
            elindeKameraVar = true;
            elindeSilahVar = false;
            SilahiBirakipKameray�Tutma();


        }

        if (Input.GetKeyDown(KeyCode.U) && elindeKameraVar == true) //13.1 atad���m�z tu�a bas�ld���nda karakter kameray� b�rak�p silah� al�r. 4 ve 5. maddedeki de�i�kenlere olmas� gereken de�erler atand�. 
        {
        
            elindeSilahVar = true;
            elindeKameraVar = false;
            KamerayiBirakipSilahTutma();

        }



    }

    void SilahiBirakipKameray�Tutma()  //6.karakterin elindeki silah� b�rak�p kameray� ald��� s�rada ger�ekle�ecek olan animasyon ve i�lemleri ger�ekle�tirecek fonksiyon.
    {
        anim.SetTrigger("silahTutarkenBirakma");
        StartCoroutine(KameraAlmaBekletme()); //7.bu yap�y� kullanma sebebimiz nesne g�r�n�rl�klerinin animasyonlardan �nce �al��mas�ndan dolay� olu�an �arp�k g�r�nt�n�n �n�ne ge�mek.
        anim.SetTrigger("silahBirakirkenKameraAlma");
        anim.SetTrigger("kameraAlirkenTutma");
    }

    void FotoCekme()  //8.karakterin foto�raf �ekme animasyonunu ger�ekle�tiren fonksiyon.
    {
        anim.SetBool("fotoCekiyorMu", true);
    }

    void KamerayiBirakipSilahTutma() //9.karakterin elindeki kameray� b�rak�p silah� ald��� s�rada ger�ekle�ecek olan animasyon ve i�lemleri ger�ekle�tirecek fonksiyon.
    {
        anim.SetTrigger("kameraTutarkenBirakma");
        StartCoroutine(SilahAlmaBekletme());
        anim.SetTrigger("kameraBirakirkenSilahAlma");
        anim.SetTrigger("silahAlirkenTutma");

    }

    void AtesEtme() //10.karakterin ate� etme animasyonunu ger�ekle�tiren fonksiyon.
    {
        anim.SetBool("atesEdiyorMu", true);
    }

  
   
   
    IEnumerator SilahAlmaBekletme() //11.  7.maddedeki i�lemi ger�ekle�tiren coroutine
    {
        yield return new WaitForSecondsRealtime(1f);
        pistol.SetActive(true);
        elKamerasi.SetActive(false);
    }
    IEnumerator KameraAlmaBekletme() 
    {
        yield return new WaitForSecondsRealtime(1f);
        elKamerasi.SetActive(true);
        pistol.SetActive(false);
    }
}