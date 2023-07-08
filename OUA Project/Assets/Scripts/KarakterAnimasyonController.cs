using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class KarakterAnimasyonController : MonoBehaviour
{
    //crosshair birden fazla fonksiyonun içinde kullanýlacak(silah tutma,ateþ etme, kamera tutma,fotoðraf çekme vs.) unutma!!!!

    public Animator anim; //1.Animator bileþeninden anim isimli bir nesne oluþturuldu.
    public GameObject elKamerasi; //2.karakterin elindeki kamerayý animasyonlar sýrasýnda açýp kapatmak için kullandýðýmýz deðiþken.
    public GameObject pistol; //3.karakterin elindeki pistolü animasyonlar sýrasýnda açýp kapatmak için kullandýðýmýz deðiþken.
    bool elindeSilahVar = true; //4.karakterin elindeki nesneden diðer nesnelere geçiþte animasyon çakýþmasý olmamasý için kullandýðýmýz deðiþken.
    bool elindeKameraVar = false; //5.karakterin elindeki nesneden diðer nesnelere geçiþte animasyon çakýþmasý olmamasý için kullandýðýmýz deðiþken.
    float atesLimiti = 6f; //16. Ateþ etme animasyonunu limitleyen deðiþken
    float fotografLimiti = 5f; //16.1 Fotoðraf çekme animasyonunu limitleyen deðiþken.
    float sonTiklama; //17. Son ateþ etme süresini tutacak deðiþken.
    float tiklamaBeklemeSuresi = 0.65f;//18. Ateþ etme ve fotoðraf çekme animasyonlarýnýn bekleme süresini sýnýrlayan deðiþken.
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
        elKamerasi.SetActive(false); //12.baþlangýçta olmasýný istediðimiz durumlarý saðlamak için(elinde silah olmasý, silahýn görünür olmasý vs.) atadýðýmýz deðerler
        elindeSilahVar = true; //12.1 baþlangýçta olmasýný istediðimiz durumlarý saðlamak için(elinde silah olmasý, silahýn görünür olmasý vs.) atadýðýmýz deðerler
        elindeKameraVar = false; //12.2 baþlangýçta olmasýný istediðimiz durumlarý saðlamak için(elinde silah olmasý, silahýn görünür olmasý vs.) atadýðýmýz deðerler
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
       
        if (Input.GetMouseButtonDown(0) && elindeSilahVar == true&&atesLimiti>0) //14.atanan tuþa basýldýðýnda ve karakterin elinde silah varsa ateþ etme fonksiyonu çalýþýr.
        {
            if (Time.time-sonTiklama>tiklamaBeklemeSuresi) //19. Bekleme süresi ve ateþ etme limitini burada kullandýk.
            {
                AtesEtme();
                              
                //ateþ edildiðinde hasar verme sistemi daha sonra burada kullanýlacak.
                sonTiklama = Time.time;

                switch (atesLimiti) //Ateþ ettikçe mermi sayýsýný gösteren sembollerin ekrandan silinmesini saðlayacak yapý.
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

        //ateþ etme limiti dolduðunda silahýn boþ olduðunu anlayacaðýmýz ses efekti burada bir if açýlarak yapýlacak.

        else //15.eðer 14.maddedeki þartlar saðlanmýyorsa ateþ etme animasyonunun durmasý saðlanýr.
        {
            anim.SetBool("atesEdiyorMu", false);
        }

        if (Input.GetMouseButtonDown(0) && elindeKameraVar == true&&fotografLimiti>0) //14.1 atanan tuþa basýldýðýnda ve karakterin elinde kamera varsa fotoðraf çekme fonksiyonu çalýþýr.
        {
            if (Time.time - sonTiklama > tiklamaBeklemeSuresi)
            {
                FotoCekme();
                fotografLimiti--;
                sonTiklama = Time.time;                
            }
            
            //--fotoðraf çekildiðinde fotoðraflarýn depolamada kaydedilmesi ve fotoðraf çekilme sýrasýnda raycast yöntemiyle sorgulamanýn yapýlmasý iþlemleri buraya gelicek.
        }
        //Fotoðraf çekme limiti dolduðunda kullanýcýnýn anlamasýný saðlayacak ses efekti burada çalacak.

        else //15.1 eðer 14.1.maddedeki þartlar saðlanmýyorsa fotoðraf çekme animasyonunun durmasý saðlanýr.
        {
            anim.SetBool("fotoCekiyorMu", false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && elindeSilahVar == true) //13.atadýðýmýz tuþa basýldýðýnda karakter silahý býrakýp kamerayý alýr. 4 ve 5. maddedeki deðiþkenlere olmasý gereken deðerler atandý. 
        {
            elindeKameraVar = true;
            elindeSilahVar = false;
            SilahiBirakipKamerayýTutma();

            kameraRaw.color = aktifColor;
            silahRaw.color = deaktifColor;
            mermiBirRaw.color = deaktifColor;
            mermiIkiRaw.color = deaktifColor;
            mermiUcRaw.color = deaktifColor;
            mermiDortRaw.color = deaktifColor;
            mermiBesRaw.color = deaktifColor;
            mermiAltiRaw.color = deaktifColor;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && elindeKameraVar == true) //13.1 atadýðýmýz tuþa basýldýðýnda karakter kamerayý býrakýp silahý alýr. 4 ve 5. maddedeki deðiþkenlere olmasý gereken deðerler atandý. 
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

    void SilahiBirakipKamerayýTutma()  //6.karakterin elindeki silahý býrakýp kamerayý aldýðý sýrada gerçekleþecek olan animasyon ve iþlemleri gerçekleþtirecek fonksiyon.
    {
        anim.SetTrigger("silahTutarkenBirakma");
        StartCoroutine(KameraAlmaBekletme()); //7.bu yapýyý kullanma sebebimiz nesne görünürlüklerinin animasyonlardan önce çalýþmasýndan dolayý oluþan çarpýk görüntünün önüne geçmek.
        anim.SetTrigger("silahBirakirkenKameraAlma");
        anim.SetTrigger("kameraAlirkenTutma");
    }

    void FotoCekme()  //8.karakterin fotoðraf çekme animasyonunu gerçekleþtiren fonksiyon.
    {
        anim.SetBool("fotoCekiyorMu", true);
    }

    void KamerayiBirakipSilahTutma() //9.karakterin elindeki kamerayý býrakýp silahý aldýðý sýrada gerçekleþecek olan animasyon ve iþlemleri gerçekleþtirecek fonksiyon.
    {
        anim.SetTrigger("kameraTutarkenBirakma");
        StartCoroutine(SilahAlmaBekletme());
        anim.SetTrigger("kameraBirakirkenSilahAlma");
        anim.SetTrigger("silahAlirkenTutma");
    }

    void AtesEtme() //10.karakterin ateþ etme animasyonunu gerçekleþtiren fonksiyon.
    {
        anim.SetBool("atesEdiyorMu", true);        
    }

    IEnumerator SilahAlmaBekletme() //11.  7.maddedeki iþlemi gerçekleþtiren coroutine
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