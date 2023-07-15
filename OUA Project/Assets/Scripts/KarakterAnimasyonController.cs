using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class KarakterAnimasyonController : MonoBehaviour
{
   
    //crosshair birden fazla fonksiyonun i�inde kullan�lacak(silah tutma,ate� etme, kamera tutma,foto�raf �ekme vs.) unutma!!!!

    public Animator anim; //1.Animator bile�eninden anim isimli bir nesne olu�turuldu.
    public GameObject elKamerasi; //2.karakterin elindeki kameray� animasyonlar s�ras�nda a��p kapatmak i�in kulland���m�z de�i�ken.
    public GameObject pistol; //3.karakterin elindeki pistol� animasyonlar s�ras�nda a��p kapatmak i�in kulland���m�z de�i�ken.
    bool elindeSilahVar = true; //4.karakterin elindeki nesneden di�er nesnelere ge�i�te animasyon �ak��mas� olmamas� i�in kulland���m�z de�i�ken.
    bool elindeKameraVar = false; //5.karakterin elindeki nesneden di�er nesnelere ge�i�te animasyon �ak��mas� olmamas� i�in kulland���m�z de�i�ken.
    float atesLimiti = 6f; //16. Ate� etme animasyonunu limitleyen de�i�ken
    float fotografLimiti = 3f; //16.1 Foto�raf �ekme animasyonunu limitleyen de�i�ken.
    float sonTiklama; //17. Son ate� etme s�resini tutacak de�i�ken.
    float tiklamaBeklemeSuresi = 0.65f;//18. Ate� etme ve foto�raf �ekme animasyonlar�n�n bekleme s�resini s�n�rlayan de�i�ken.
    public static float karakterHP = 100f;
    public GameObject Karakter;  //Karakter �ld����nde anlayal�m diye karakteri sahneden ��karmak i�in bu de�i�keni kulland�k. Bu k�s�m daha sonra de�i�ecek. You Died ekran� gelecek.
    public GameObject mermiBir; //Silahtaki mermi say�s�. Altta hem bunlar�n Image componentini hem de mermiyi tan�mlad�k. Bunun sebebi, image ile karakter eline kamera ald���nda renk daha soluk bir gri olacak. Bunu bu componenti i�inde bar�nd�ran de�i�kenle yapaca��z. GameObjectle de ate� edili�inde ekrandan kaybolmas�n� sa�lam�� olaca��z.
    public GameObject mermiIki;
    public GameObject mermiUc;
    public GameObject mermiDort;
    public GameObject mermiBes;
    public GameObject mermiAlti;

    public Image silahCross; //Silah�n ni�angah�
    public Image kameraCross;//Kameran�n ni�angah�
    
    Color deaktifColor = new Color(1f,1f,1f,0.1f);  //Aktif ve deaktif color, aray�zdeki silah, kamera mermi gibi gri renkli bile�enlerin aktifken ve deaktifken renklerinin de�i�mesini sa�l�yor.
    Color aktifColor = new Color(1f, 1f, 1f, 1f); 
    Color textColorAktif = new Color(0.6039216f, 0.6039216f, 0.6039216f, 1f);  //kameran�n ka� adet �ekim say�s� kald���n� g�steren textin rengini de bu iki de�i�kenle kontrol edece�iz.
    Color textColorDeaktif = new Color(0.6039216f, 0.6039216f, 0.6039216f, 0.05098039f);
    

    private Image mermiBirIM; //Kamera ald���nda ve tekrar silah ald���nda mermi simgelerinin renklerinin de�i�mesini istedi�imiz i�in kullanaca��m�z component.
    private Image mermiIk�IM;
    private Image mermiUcIM;
    private Image mermiDortIM;
    private Image mermiBesIM;
    private Image mermiAltiIM;
    public Image silahSembol;
    public Image kameraSembol;
    

    public TextMeshProUGUI hpText;  //Karakterin can�n�n yazd��� bile�en�
    public TextMeshProUGUI fotoSayisi;//Foto�raf �ekme hakk�n� g�steren g�sterge.
    int hpInt; //ekrana can� yazd�r�rken t�r d�n���m� yapmak i�in kulland���m�z de�i�ken.

    float deger;//Bu de�er, karakterin can�n�n de�i�ip de�i�medi�ini kontrol edecek. E�er de�i�irse, bloodFramin renginin de�i�ti�i fonksiyon �al��acak.
    public Image bloodFrame; // Alpha de�erini de�i�tirmek istedi�iniz g�r�nt�

    private float beklemeSuresi = 3.7f; // Ge�i� s�resi (saniye)
    private bool tetiklendiMi = false; // Ge�i� i�lemi devam ediyor mu? 

    private AudioSource audioSource; //ses kayna��n� belirlemek i�in bir bile�en olu�turuldu.
    public AudioSource auSource; //Kalp at���n� tutacak component.
    public AudioClip[] yaralanma; //karakter hasar ald���nda kullan�lacak ses i�in bir audioclip bile�eni olu�turuldu.
    public AudioClip silahAl; //karakter silah� ald���nda kullan�lacak ses i�in bir audioclip bile�eni olu�turuldu.
    public AudioClip kalpSesi; //Karakter hasar ald���nda anl�k olarak ��kacak kalp sesi.
    public AudioClip kameraCekme;
   

    int lightAttackSayisi = 0;//Karakterin yedi�i attack1 yani light attack say�s�n� tutacak de�i�ken. 0'sa veya 2'nin katlar�ysa hasar alma sesi �alacak.

    void Start()
    {
        elKamerasi.SetActive(false); //12.ba�lang��ta olmas�n� istedi�imiz durumlar� sa�lamak i�in(elinde silah olmas�, silah�n g�r�n�r olmas� vs.) atad���m�z de�erler
        elindeSilahVar = true; //12.1 ba�lang��ta olmas�n� istedi�imiz durumlar� sa�lamak i�in(elinde silah olmas�, silah�n g�r�n�r olmas� vs.) atad���m�z de�erler
        elindeKameraVar = false; //12.2 ba�lang��ta olmas�n� istedi�imiz durumlar� sa�lamak i�in(elinde silah olmas�, silah�n g�r�n�r olmas� vs.) atad���m�z de�erler                                 

        mermiBirIM=mermiBir.GetComponent<Image>(); //componentleri cache ettik.
        mermiIk�IM = mermiIki.GetComponent<Image>();
        mermiUcIM = mermiUc.GetComponent<Image>();
        mermiDortIM = mermiDort.GetComponent<Image>();
        mermiBesIM = mermiBes.GetComponent<Image>();
        mermiAltiIM = mermiAlti.GetComponent<Image>();


        mermiBirIM.color = aktifColor;  //aray�zdeki unsurlar�n ba�lang��taki renklerini verdik.
        mermiIk�IM.color = aktifColor;
        mermiUcIM.color=   aktifColor;
        mermiDortIM.color= aktifColor;
        mermiBesIM.color=  aktifColor;
        mermiAltiIM.color= aktifColor;
        silahSembol.color= aktifColor;
        kameraSembol.color=deaktifColor;
        fotoSayisi.color = textColorDeaktif;

        silahCross.gameObject.SetActive(true);  //silahla ba�layaca��m�z i�in crosslar�n aktifli�ini ayarlad�k.
        kameraCross.gameObject.SetActive(false);


         

        audioSource = GetComponent<AudioSource>(); //audiosource compenenti cache edildi.

        karakterHP = 100;
        deger = karakterHP; //de�eri hp ye atad�k.
        bloodFrame.gameObject.SetActive(false);
       
        
    }

    void Update()
    {
        hpInt = Mathf.RoundToInt(karakterHP);  //karakter hp yi ilgili de�i�ken �evirerek atad�k.

        if (deger != karakterHP&&karakterHP>0)  //Bu k�s�mda, karakterin can�, de�er de�i�kenine atand�ktan sonra canda de�i�im olup olmad���n� kontrol ediyor. E�er de�i�im varsa bloodFrame effect devreye girecek.
        {
            float degerIki = deger;
            tetiklendiMi = true;
            StartCoroutine(renkGecisi());
            deger = karakterHP;
           
            if (degerIki != deger)
            {
                StopCoroutine(renkGecisi());
                StartCoroutine(renkGecisi());
            }
            
        }

        if (karakterHP <= 0)
        {
            Karakter.SetActive(false);
            hpText.text = "0";
            OlumEkrani.Olum(); //--
        }

        
        
        else
        {
            hpText.text =hpInt.ToString();
            if (Input.GetMouseButtonDown(0) && elindeSilahVar == true && atesLimiti > 0 && !(PauseMenu.oyunDurduMu)) //14.atanan tu�a bas�ld���nda ve karakterin elinde silah varsa ate� etme fonksiyonu �al���r.
            {
                if (Time.time - sonTiklama > tiklamaBeklemeSuresi) //19. Bekleme s�resi ve ate� etme limitini burada kulland�k.
                {
                    AtesEtme();

                    //ate� edildi�inde hasar verme sistemi daha sonra burada kullan�lacak.
                    sonTiklama = Time.time;

                    switch (atesLimiti) //Ate� ettik�e mermi say�s�n� g�steren sembollerin ekrandan silinmesini sa�layacak yap�.
                    {
                        case 6:
                            mermiBir.SetActive(false);
                            break;
                        case 5:
                            mermiIki.SetActive(false);
                            break;
                        case 4:
                            mermiUc.SetActive(false);
                            break;
                        case 3:
                            mermiDort.SetActive(false);
                            break;
                        case 2:
                            mermiBes.SetActive(false);
                            break;
                        case 1:
                            mermiAlti.SetActive(false);
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

            if (Input.GetMouseButtonDown(0) && elindeKameraVar == true && fotografLimiti > 0 && !(PauseMenu.oyunDurduMu)) //14.1 atanan tu�a bas�ld���nda ve karakterin elinde kamera varsa foto�raf �ekme fonksiyonu �al���r.
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
               
                mermiBirIM.color = deaktifColor;
                mermiIk�IM.color = deaktifColor;
                mermiUcIM.color = deaktifColor;
                mermiDortIM.color = deaktifColor;
                mermiBesIM.color = deaktifColor;
                mermiAltiIM.color = deaktifColor;
                silahSembol.color = deaktifColor;
                kameraSembol.color = aktifColor;
                fotoSayisi.color = textColorAktif;

                StartCoroutine(CrossPistolToCamera());
            }

            if (Input.GetKeyDown(KeyCode.Alpha2) && elindeKameraVar == true) //13.1 atad���m�z tu�a bas�ld���nda karakter kameray� b�rak�p silah� al�r. 4 ve 5. maddedeki de�i�kenlere olmas� gereken de�erler atand�. 
            {
                elindeSilahVar = true;
                elindeKameraVar = false;
                KamerayiBirakipSilahTutma();
               

                mermiBirIM.color = aktifColor;
                mermiIk�IM.color = aktifColor;
                mermiUcIM.color = aktifColor;
                mermiDortIM.color = aktifColor;
                mermiBesIM.color = aktifColor;
                mermiAltiIM.color = aktifColor;
                silahSembol.color = aktifColor;
                kameraSembol.color = deaktifColor;
                fotoSayisi.color = textColorDeaktif;

                StartCoroutine(CrossCameraToPistol());
            }
        }


        fotoSayisi.text = "x" + fotografLimiti;


    }

    public void HasarAl()
    {
        karakterHP -= Random.Range(10f, 20f);
        //audioSource.PlayOneShot(yaralanma); //karakter hasar ald���nda ��kacak sesin oynat�lmas� sa�land�.
        yaralanmaSesi();
        
    }
    public void hasarALLight()
    {
        
        karakterHP -= Random.Range(5f, 10f);
        //audioSource.PlayOneShot(yaralanma); //karakter hasar ald���nda ��kacak sesin oynat�lmas� sa�land�.
        if (lightAttackSayisi == 0 || lightAttackSayisi % 2 == 0) 
        { 
            yaralanmaSesiLight();
        }
        lightAttackSayisi++;
    }

    void SilahiBirakipKameray�Tutma()  //6.karakterin elindeki silah� b�rak�p kameray� ald��� s�rada ger�ekle�ecek olan animasyon ve i�lemleri ger�ekle�tirecek fonksiyon.
    {
        anim.SetTrigger("silahTutarkenBirakma");
        StartCoroutine(KameraAlmaBekletme()); //7.bu yap�y� kullanma sebebimiz nesne g�r�n�rl�klerinin animasyonlardan �nce �al��mas�ndan dolay� olu�an �arp�k g�r�nt�n�n �n�ne ge�mek.
        anim.SetTrigger("silahBirakirkenKameraAlma");
        StartCoroutine(kameraCekmeSesi());
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
        StartCoroutine(silahCekmeSesi());
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
    IEnumerator CrossPistolToCamera()
    {
        silahCross.gameObject.SetActive(false);
        yield return new WaitForSecondsRealtime(1.6f);
        kameraCross.gameObject.SetActive(true);
       
    }
    IEnumerator CrossCameraToPistol()
    {
        kameraCross.gameObject.SetActive(false);
        yield return new WaitForSecondsRealtime(1.5f);        
        silahCross.gameObject.SetActive(true);

    }

    IEnumerator renkGecisi() //sadasdas
    {
        
        float zamanlayici = 0f;
        Color startColor = new Color(0.5f,0.15f,0.15f,1.0f);        
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 0f);
        
        bloodFrame.gameObject.SetActive(true);

        if (!auSource.isPlaying)
        {
            auSource.PlayOneShot(kalpSesi);
        }
            
        

        while (zamanlayici < beklemeSuresi)
        {
            zamanlayici += Time.deltaTime;
            float t = zamanlayici / beklemeSuresi;
            bloodFrame.color = Color.Lerp(startColor, endColor, t);
            yield return null;
        }

        //bloodFrame.color = endColor;
        tetiklendiMi = false;

        if (bloodFrame.color.a <= 0)
        {
            bloodFrame.color = startColor;
            bloodFrame.gameObject.SetActive(false);
            auSource.Stop();
            
        }
    }
    void yaralanmaSesiLight() //Karakter attack1 yedikten sonra �alacak ses efekti.
    {

        audioSource.PlayOneShot(yaralanma[0]);

    }
    void yaralanmaSesi() //karakterin attack2 yedikten sonra �alacak ses efekti
    {
        
        audioSource.PlayOneShot(yaralanma[1]);
        
    }
    
    IEnumerator silahCekmeSesi() //karakterin kameray� b�rak�p silah� al�rken �alacak ses efekti
    {
        yield return new WaitForSecondsRealtime(0.8f);
        audioSource.PlayOneShot(silahAl); //silah� al�rken ��kan sesin oynat�lmas� sa�land�.
    }
    IEnumerator kameraCekmeSesi()// karakterin silah� b�rak�p kameray� al�rken �alacak ses efekti
    {
        yield return new WaitForSecondsRealtime(0.7f);
        audioSource.PlayOneShot(kameraCekme);
    }
}