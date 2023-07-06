using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarakterAnimasyonController : MonoBehaviour
{
    //crosshair birden fazla fonksiyonun içinde kullanýlacak(silah tutma,ateþ etme, kamera tutma,fotoðraf çekme vs.) unutma!!!!

    public Animator anim; //1.Animator bileþeninden anim isimli bir nesne oluþturuldu.
    public GameObject elKamerasi; //2.karakterin elindeki kamerayý animasyonlar sýrasýnda açýp kapatmak için kullandýðýmýz deðiþken.
    public GameObject pistol; //3.karakterin elindeki pistolü animasyonlar sýrasýnda açýp kapatmak için kullandýðýmýz deðiþken.
    bool elindeSilahVar = true; //4.karakterin elindeki nesneden diðer nesnelere geçiþte animasyon çakýþmasý olmamasý için kullandýðýmýz deðiþken.
    bool elindeKameraVar = false; //5.karakterin elindeki nesneden diðer nesnelere geçiþte animasyon çakýþmasý olmamasý için kullandýðýmýz deðiþken.
    void Start()
    {
        elKamerasi.SetActive(false); //12.baþlangýçta olmasýný istediðimiz durumlarý saðlamak için(elinde silah olmasý, silahýn görünür olmasý vs.) atadýðýmýz deðerler
        elindeSilahVar = true; //12.1 baþlangýçta olmasýný istediðimiz durumlarý saðlamak için(elinde silah olmasý, silahýn görünür olmasý vs.) atadýðýmýz deðerler
        elindeKameraVar = false; //12.2 baþlangýçta olmasýný istediðimiz durumlarý saðlamak için(elinde silah olmasý, silahýn görünür olmasý vs.) atadýðýmýz deðerler
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && elindeSilahVar == true) //14.atanan tuþa basýldýðýnda ve karakterin elinde silah varsa ateþ etme fonksiyonu çalýþýr.
        {
            AtesEtme(); 
            //ateþ edildiðinde hasar verme sistemi daha sonra burada kullanýlacak.
        }

        else //15.eðer 14.maddedeki þartlar saðlanmýyorsa ateþ etme animasyonunun durmasý saðlanýr.
        {
            anim.SetBool("atesEdiyorMu", false);
        }

        if (Input.GetMouseButtonDown(0) && elindeKameraVar == true) //14.1 atanan tuþa basýldýðýnda ve karakterin elinde kamera varsa fotoðraf çekme fonksiyonu çalýþýr.
        {
            FotoCekme();
            //fotoðraf çekildiðinde fotoðraflarýn depolamada kaydedilmesi ve fotoðraf çekilme sýrasýnda raycast yöntemiyle sorgulamanýn yapýlmasý iþlemleri buraya gelicek.
        }

        else //15.1 eðer 14.1.maddedeki þartlar saðlanmýyorsa fotoðraf çekme animasyonunun durmasý saðlanýr.
        {
            anim.SetBool("fotoCekiyorMu", false);
        }

        if (Input.GetKeyDown(KeyCode.P) && elindeSilahVar == true) //13.atadýðýmýz tuþa basýldýðýnda karakter silahý býrakýp kamerayý alýr. 4 ve 5. maddedeki deðiþkenlere olmasý gereken deðerler atandý. 
        {
            elindeKameraVar = true;
            elindeSilahVar = false;
            SilahiBirakipKamerayýTutma();


        }

        if (Input.GetKeyDown(KeyCode.U) && elindeKameraVar == true) //13.1 atadýðýmýz tuþa basýldýðýnda karakter kamerayý býrakýp silahý alýr. 4 ve 5. maddedeki deðiþkenlere olmasý gereken deðerler atandý. 
        {
        
            elindeSilahVar = true;
            elindeKameraVar = false;
            KamerayiBirakipSilahTutma();

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