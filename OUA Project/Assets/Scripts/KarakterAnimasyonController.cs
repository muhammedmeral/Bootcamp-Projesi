using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class KarakterAnimasyonController : MonoBehaviour
{
    //crosshair birden fazla fonksiyonun i�inde kullan�lacak(silah tutma,ate� etme, kamera tutma,foto�raf �ekme vs.) unutma!!!!

    public Animator anim; //1.Animator bile�eninden anim isimli bir nesne olu�turuldu.
    public GameObject elKamerasi; //2.karakterin elindeki kameray� animasyonlar s�ras�nda a��p kapatmak i�in kulland���m�z de�i�ken.
    public GameObject pistol; //3.karakterin elindeki pistol� animasyonlar s�ras�nda a��p kapatmak i�in kulland���m�z de�i�ken.
    bool elindeSilahVar = true; //4.karakterin elindeki nesneden di�er nesnelere ge�i�te animasyon �ak��mas� olmamas� i�in kulland���m�z de�i�ken.
    bool elindeKameraVar = false; //5.karakterin elindeki nesneden di�er nesnelere ge�i�te animasyon �ak��mas� olmamas� i�in kulland���m�z de�i�ken.
    float atesLimiti = 6f; //16. Ate� etme animasyonunu limitleyen de�i�ken
    float fotografLimiti = 5f; //16.1 Foto�raf �ekme animasyonunu limitleyen de�i�ken.
    float sonTiklama; //17. Son ate� etme s�resini tutacak de�i�ken.
    float tiklamaBeklemeSuresi = 0.65f;//18. Ate� etme ve foto�raf �ekme animasyonlar�n�n bekleme s�resini s�n�rlayan de�i�ken.
    public GameObject mermiBir;
    public GameObject mermiIki;
    public GameObject mermiUc;
    public GameObject mermiDort;
    public GameObject mermiBes;
    public GameObject mermiAlti;
    public GameObject silahSembol;
    public GameObject kameraSembol;
    Color deaktifColor = new Color(1f,1f,1f,0.05f);
    Color aktifColor = new Color(25.5f, 25.5f, 25.5f, 25.5f);
    RawImage silahRaw;
    RawImage kameraRaw;
    RawImage mermiBirRaw;
    RawImage mermiIkiRaw;
    RawImage mermiUcRaw;
    RawImage mermiDortRaw;
    RawImage mermiBesRaw;
    RawImage mermiAltiRaw;



    void Start()
    {
        elKamerasi.SetActive(false); //12.ba�lang��ta olmas�n� istedi�imiz durumlar� sa�lamak i�in(elinde silah olmas�, silah�n g�r�n�r olmas� vs.) atad���m�z de�erler
        elindeSilahVar = true; //12.1 ba�lang��ta olmas�n� istedi�imiz durumlar� sa�lamak i�in(elinde silah olmas�, silah�n g�r�n�r olmas� vs.) atad���m�z de�erler
        elindeKameraVar = false; //12.2 ba�lang��ta olmas�n� istedi�imiz durumlar� sa�lamak i�in(elinde silah olmas�, silah�n g�r�n�r olmas� vs.) atad���m�z de�erler
        silahRaw = silahSembol.GetComponent<RawImage>();
        kameraRaw = kameraSembol.GetComponent<RawImage>();
        mermiBirRaw=mermiBir.GetComponent<RawImage>();
        mermiIkiRaw=mermiIki.GetComponent<RawImage>();
        mermiUcRaw=mermiUc.GetComponent<RawImage>();
        mermiDortRaw=mermiDort.GetComponent<RawImage>();
        mermiBesRaw=mermiBes.GetComponent<RawImage>();
        mermiAltiRaw=mermiAlti.GetComponent<RawImage>();
        silahRaw.color = aktifColor;
        kameraRaw.color = deaktifColor;
        mermiBirRaw.color = aktifColor;
        mermiIkiRaw.color = aktifColor;
        mermiUcRaw.color = aktifColor;
        mermiDortRaw.color = aktifColor;
        mermiBesRaw.color = aktifColor;
        mermiAltiRaw.color = aktifColor;

    }

    void Update()
    {
       
        if (Input.GetMouseButtonDown(0) && elindeSilahVar == true&&atesLimiti>0) //14.atanan tu�a bas�ld���nda ve karakterin elinde silah varsa ate� etme fonksiyonu �al���r.
        {
            if (Time.time-sonTiklama>tiklamaBeklemeSuresi) //19. Bekleme s�resi ve ate� etme limitini burada kulland�k.
            {
                AtesEtme();
                              
                //ate� edildi�inde hasar verme sistemi daha sonra burada kullan�lacak.
                sonTiklama = Time.time;

                switch (atesLimiti) //Ate� ettik�e mermi say�s�n� g�steren sembollerin ekrandan silinmesini sa�layacak yap�.
                {
                    case 6: mermiBir.SetActive(false);                        
                        break;
                    case 5:mermiIki.SetActive(false);
                        break;
                    case 4:mermiUc.SetActive(false);
                        break;
                    case 3:mermiDort.SetActive(false);
                        break;
                    case 2: mermiBes.SetActive(false);
                        break;
                    case 1: mermiAlti.SetActive(false);
                        break;
                    default:
                        break;
                }
                atesLimiti--;
            }
        }

        //ate� etme limiti doldu�unda silah�n bo� oldu�unu anlayaca��m�z ses efekti burada bir if a��larak yap�lacak.

        else //15.e�er 14.maddedeki �artlar sa�lanm�yorsa ate� etme animasyonunun durmas� sa�lan�r.
        {
            anim.SetBool("atesEdiyorMu", false);
        }

        if (Input.GetMouseButtonDown(0) && elindeKameraVar == true&&fotografLimiti>0) //14.1 atanan tu�a bas�ld���nda ve karakterin elinde kamera varsa foto�raf �ekme fonksiyonu �al���r.
        {
            if (Time.time - sonTiklama > tiklamaBeklemeSuresi)
            {
                FotoCekme();
                fotografLimiti--;
                sonTiklama = Time.time;                
            }
            
            //--foto�raf �ekildi�inde foto�raflar�n depolamada kaydedilmesi ve foto�raf �ekilme s�ras�nda raycast y�ntemiyle sorgulaman�n yap�lmas� i�lemleri buraya gelicek.
        }
        //Foto�raf �ekme limiti doldu�unda kullan�c�n�n anlamas�n� sa�layacak ses efekti burada �alacak.

        else //15.1 e�er 14.1.maddedeki �artlar sa�lanm�yorsa foto�raf �ekme animasyonunun durmas� sa�lan�r.
        {
            anim.SetBool("fotoCekiyorMu", false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && elindeSilahVar == true) //13.atad���m�z tu�a bas�ld���nda karakter silah� b�rak�p kameray� al�r. 4 ve 5. maddedeki de�i�kenlere olmas� gereken de�erler atand�. 
        {
            elindeKameraVar = true;
            elindeSilahVar = false;
            SilahiBirakipKameray�Tutma();

            kameraRaw.color = aktifColor;
            silahRaw.color = deaktifColor;
            mermiBirRaw.color = deaktifColor;
            mermiIkiRaw.color = deaktifColor;
            mermiUcRaw.color = deaktifColor;
            mermiDortRaw.color = deaktifColor;
            mermiBesRaw.color = deaktifColor;
            mermiAltiRaw.color = deaktifColor;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && elindeKameraVar == true) //13.1 atad���m�z tu�a bas�ld���nda karakter kameray� b�rak�p silah� al�r. 4 ve 5. maddedeki de�i�kenlere olmas� gereken de�erler atand�. 
        {
            elindeSilahVar = true;
            elindeKameraVar = false;
            KamerayiBirakipSilahTutma();

            kameraRaw.color = deaktifColor;
            silahRaw.color = aktifColor;
            mermiBirRaw.color = aktifColor;
            mermiIkiRaw.color = aktifColor;
            mermiUcRaw.color = aktifColor;
            mermiDortRaw.color = aktifColor;
            mermiBesRaw.color = aktifColor;
            mermiAltiRaw.color = aktifColor;
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