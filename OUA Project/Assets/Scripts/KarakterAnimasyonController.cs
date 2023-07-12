using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class KarakterAnimasyonController : MonoBehaviour
{
    //crosshair birden fazla fonksiyonun içinde kullanýlacak(silah tutma,ateþ etme, kamera tutma,fotoðraf çekme vs.) unutma!!!!

    public Animator anim; //1.Animator bileþeninden anim isimli bir nesne oluþturuldu.
    public GameObject elKamerasi; //2.karakterin elindeki kamerayý animasyonlar sýrasýnda açýp kapatmak için kullandýðýmýz deðiþken.
    public GameObject pistol; //3.karakterin elindeki pistolü animasyonlar sýrasýnda açýp kapatmak için kullandýðýmýz deðiþken.
    bool elindeSilahVar = true; //4.karakterin elindeki nesneden diðer nesnelere geçiþte animasyon çakýþmasý olmamasý için kullandýðýmýz deðiþken.
    bool elindeKameraVar = false; //5.karakterin elindeki nesneden diðer nesnelere geçiþte animasyon çakýþmasý olmamasý için kullandýðýmýz deðiþken.
    float atesLimiti = 6f; //16. Ateþ etme animasyonunu limitleyen deðiþken
    float fotografLimiti = 3f; //16.1 Fotoðraf çekme animasyonunu limitleyen deðiþken.
    float sonTiklama; //17. Son ateþ etme süresini tutacak deðiþken.
    float tiklamaBeklemeSuresi = 0.65f;//18. Ateþ etme ve fotoðraf çekme animasyonlarýnýn bekleme süresini sýnýrlayan deðiþken.
    public float karakterHP = 100f;
    public GameObject Karakter;  //Karakter öldüüðünde anlayalým diye karakteri sahneden çýkarmak için bu deðiþkeni kullandýk. Bu kýsým daha sonra deðiþecek. You Died ekraný gelecek.
    public GameObject mermiBir; //Silahtaki mermi sayýsý. Altta hem bunlarýn Image componentini hem de mermiyi tanýmladýk. Bunun sebebi, image ile karakter eline kamera aldýðýnda renk daha soluk bir gri olacak. Bunu bu componenti içinde barýndýran deðiþkenle yapacaðýz. GameObjectle de ateþ ediliðinde ekrandan kaybolmasýný saðlamýþ olacaðýz.
    public GameObject mermiIki;
    public GameObject mermiUc;
    public GameObject mermiDort;
    public GameObject mermiBes;
    public GameObject mermiAlti;

    public Image silahCross; //Silahýn niþangahý
    public Image kameraCross;//Kameranýn niþangahý
    
    Color deaktifColor = new Color(1f,1f,1f,0.1f);  //Aktif ve deaktif color, arayüzdeki silah, kamera mermi gibi gri renkli bileþenlerin aktifken ve deaktifken renklerinin deðiþmesini saðlýyor.
    Color aktifColor = new Color(1f, 1f, 1f, 1f); 
    Color textColorAktif = new Color(0.6039216f, 0.6039216f, 0.6039216f, 1f);  //kameranýn kaç adet çekim sayýsý kaldýðýný gösteren textin rengini de bu iki deðiþkenle kontrol edeceðiz.
    Color textColorDeaktif = new Color(0.6039216f, 0.6039216f, 0.6039216f, 0.05098039f);
    

    private Image mermiBirIM; //Kamera aldýðýnda ve tekrar silah aldýðýnda mermi simgelerinin renklerinin deðiþmesini istediðimiz için kullanacaðýmýz component.
    private Image mermiIkýIM;
    private Image mermiUcIM;
    private Image mermiDortIM;
    private Image mermiBesIM;
    private Image mermiAltiIM;
    public Image silahSembol;
    public Image kameraSembol;
    

    public TextMeshProUGUI hpText;  //Karakterin canýnýn yazdýðý bileþenç
    public TextMeshProUGUI fotoSayisi;//Fotoðraf çekme hakkýný gösteren gösterge.
    int hpInt; //ekrana caný yazdýrýrken tür dönüþümü yapmak için kullandýðýmýz deðiþken.

    float deger;//Bu deðer, karakterin canýnýn deðiþip deðiþmediðini kontrol edecek. Eðer deðiþirse, bloodFramin renginin deðiþtiði fonksiyon çalýþacak.
    public Image bloodFrame; // Alpha deðerini deðiþtirmek istediðiniz görüntü

    private float beklemeSuresi = 3f; // Geçiþ süresi (saniye)
    private bool tetiklendiMi = false; // Geçiþ iþlemi devam ediyor mu? 

    void Start()
    {
        elKamerasi.SetActive(false); //12.baþlangýçta olmasýný istediðimiz durumlarý saðlamak için(elinde silah olmasý, silahýn görünür olmasý vs.) atadýðýmýz deðerler
        elindeSilahVar = true; //12.1 baþlangýçta olmasýný istediðimiz durumlarý saðlamak için(elinde silah olmasý, silahýn görünür olmasý vs.) atadýðýmýz deðerler
        elindeKameraVar = false; //12.2 baþlangýçta olmasýný istediðimiz durumlarý saðlamak için(elinde silah olmasý, silahýn görünür olmasý vs.) atadýðýmýz deðerler                                 

        mermiBirIM=mermiBir.GetComponent<Image>(); //componentleri cache ettik.
        mermiIkýIM = mermiIki.GetComponent<Image>();
        mermiUcIM = mermiUc.GetComponent<Image>();
        mermiDortIM = mermiDort.GetComponent<Image>();
        mermiBesIM = mermiBes.GetComponent<Image>();
        mermiAltiIM = mermiAlti.GetComponent<Image>();


         mermiBirIM.color = aktifColor;  //arayüzdeki unsurlarýn baþlangýçtaki renklerini verdik.
         mermiIkýIM.color = aktifColor;
         mermiUcIM.color=   aktifColor;
         mermiDortIM.color= aktifColor;
         mermiBesIM.color=  aktifColor;
         mermiAltiIM.color= aktifColor;
         silahSembol.color= aktifColor;
         kameraSembol.color=deaktifColor;
        fotoSayisi.color = textColorDeaktif;

        silahCross.gameObject.SetActive(true);  //silahla baþlayacaðýmýz için crosslarýn aktifliðini ayarladýk.
        kameraCross.gameObject.SetActive(false);


        deger = karakterHP; //deðeri hp ye atadýk.
        

        
    }

    void Update()
    {
        hpInt = Mathf.RoundToInt(karakterHP);  //karakter hp yi ilgili deðiþken çevirerek atadýk.

        if (deger != karakterHP&&karakterHP>0)  //Bu kýsýmda, karakterin caný, deðer deðiþkenine atandýktan sonra canda deðiþim olup olmadýðýný kontrol ediyor. Eðer deðiþim varsa bloodFrame effect devreye girecek.
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
        }

        
        
        else
        {
            hpText.text =hpInt.ToString();
            if (Input.GetMouseButtonDown(0) && elindeSilahVar == true && atesLimiti > 0) //14.atanan tuþa basýldýðýnda ve karakterin elinde silah varsa ateþ etme fonksiyonu çalýþýr.
            {
                if (Time.time - sonTiklama > tiklamaBeklemeSuresi) //19. Bekleme süresi ve ateþ etme limitini burada kullandýk.
                {
                    AtesEtme();

                    //ateþ edildiðinde hasar verme sistemi daha sonra burada kullanýlacak.
                    sonTiklama = Time.time;

                    switch (atesLimiti) //Ateþ ettikçe mermi sayýsýný gösteren sembollerin ekrandan silinmesini saðlayacak yapý.
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

            //ateþ etme limiti dolduðunda silahýn boþ olduðunu anlayacaðýmýz ses efekti burada bir if açýlarak yapýlacak.

            else //15.eðer 14.maddedeki þartlar saðlanmýyorsa ateþ etme animasyonunun durmasý saðlanýr.
            {
                anim.SetBool("atesEdiyorMu", false);
            }

            if (Input.GetMouseButtonDown(0) && elindeKameraVar == true && fotografLimiti > 0) //14.1 atanan tuþa basýldýðýnda ve karakterin elinde kamera varsa fotoðraf çekme fonksiyonu çalýþýr.
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
               
                mermiBirIM.color = deaktifColor;
                mermiIkýIM.color = deaktifColor;
                mermiUcIM.color = deaktifColor;
                mermiDortIM.color = deaktifColor;
                mermiBesIM.color = deaktifColor;
                mermiAltiIM.color = deaktifColor;
                silahSembol.color = deaktifColor;
                kameraSembol.color = aktifColor;
                fotoSayisi.color = textColorAktif;

                StartCoroutine(CrossPistolToCamera());
            }

            if (Input.GetKeyDown(KeyCode.Alpha2) && elindeKameraVar == true) //13.1 atadýðýmýz tuþa basýldýðýnda karakter kamerayý býrakýp silahý alýr. 4 ve 5. maddedeki deðiþkenlere olmasý gereken deðerler atandý. 
            {
                elindeSilahVar = true;
                elindeKameraVar = false;
                KamerayiBirakipSilahTutma();

                mermiBirIM.color = aktifColor;
                mermiIkýIM.color = aktifColor;
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
        
    }
    public void hasarALLight()
    {
        karakterHP -= Random.Range(5f, 10f);
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
        }
    }
    
}