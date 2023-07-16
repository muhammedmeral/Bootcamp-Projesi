using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FotoCekme : MonoBehaviour
{
    public Camera fotoCekmeKamerasi;
    /*public List<RawImage> fotoGostericiler; */// Birden fazla Raw Image i�in liste tan�mlad�k
    private List<Texture2D> fotoTextureList;
    int fotoCekmeLimiti = 3;

    public LayerMask canavarLayer;

    public GameObject canavar;
    public Camera anaKamera;

    private AudioSource audioSource; //sesin kayna��n� belirlemek i�in bir bile�en olu�turuldu.
    public AudioClip fotoCek; //foto �ekti�inde ��kan sesi kullanmak i�in audioclip bile�eni olu�turuldu.
    public AudioClip bosKameraSesi;
    float sonTiklama;
    float tiklamaBeklemeSuresi = 0.65f;


    private void Start()
    {
        SifirlaFotoKayitlari();
        fotoTextureList = new List<Texture2D>();
        audioSource = GetComponent<AudioSource>(); //audiosource componentini cache ettik.
    }

    private void Update()
    {

        if (Input.GetMouseButtonDown(0) && fotoCekmeLimiti > 0 && PauseMenu.oyunDurduMu == false)
        {
            if (Time.time - sonTiklama > tiklamaBeklemeSuresi)
            {
                CanavariFotoCek();
                audioSource.PlayOneShot(fotoCek); //foto�raf �ekme sesinin oynat�lmas� sa�land�.

                //Kaydet();
                fotoCekmeLimiti--;
                sonTiklama = Time.time;

                if (KadrajdaMi() == true)
                {
                    Kaydet();
                    fotoCekmeLimiti = 0;
                }

                else
                {
                    //fotoCekmeLimiti--;
                    sonTiklama = Time.time;
                }
            }

        }
        else if (Input.GetMouseButtonDown(0) && fotoCekmeLimiti <= 0 && PauseMenu.oyunDurduMu == false)
        {
            if (fotoCekmeLimiti == 0)
            {
                if (audioSource.isPlaying == false)
                {
                    BosKameraSesi();
                }
            }
            else if (Time.time - sonTiklama > tiklamaBeklemeSuresi)
            {
                //�alacak ses eklenecek

                if (audioSource.isPlaying == false)
                {
                    BosKameraSesi();
                }

                sonTiklama = Time.time;
            }
        }

        //TumFotograflariGoster();
    }


    public bool KadrajdaMi()
    {
        Vector3 objePozisyon = canavar.transform.position;
        Vector3 ekranPozisyonu = anaKamera.WorldToViewportPoint(objePozisyon);

        if (ekranPozisyonu.x > 0 && ekranPozisyonu.x < 1 && ekranPozisyonu.y > 0 && ekranPozisyonu.y < 1 && ekranPozisyonu.z > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void CanavariFotoCek()
    {

        if (KadrajdaMi() == true)
        {
            RenderTexture renderTexture = new RenderTexture(Screen.width, Screen.height, 24);
            fotoCekmeKamerasi.targetTexture = renderTexture;
            Texture2D fotoTexture2D = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, true);
            fotoCekmeKamerasi.Render();
            RenderTexture.active = renderTexture;
            fotoTexture2D.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
            fotoTexture2D.Apply();
            fotoCekmeKamerasi.targetTexture = null;
            RenderTexture.active = null;
            Destroy(renderTexture);

            fotoTextureList.Add(fotoTexture2D);  //dasdadasdasdasdasd
            Debug.Log("Canaver kadrajdaydi len efferin");
        }
        else
        {
            Debug.Log("Masmaalesef beceremedin denyo");
        }
    }

    //public void TumFotograflariGoster()   //Bu k�s�m aray�z i�inden sonra silinecek.
    //{
    //    for (int i = 0; i < fotoTextureList.Count; i++)
    //    {
    //        if (i < fotoGostericiler.Count)
    //        {
    //            RawImage fotoGosterici = fotoGostericiler[i];
    //            Texture2D fotoTexture = fotoTextureList[i];
    //            fotoGosterici.texture = fotoTexture;
    //        }
    //    }
    //}

    public void Kaydet()
    {
        for (int i = 0; i < fotoTextureList.Count; i++)
        {
            byte[] fotoBytes = fotoTextureList[i].EncodeToPNG();
            string dosyaYolu = Application.persistentDataPath + "/foto" + (i + 1) + ".png";
            System.IO.File.WriteAllBytes(dosyaYolu, fotoBytes);
        }
    }

    public void BosKameraSesi() //foto hakk� doldu�unda �alacak ses efekti.
    {
        audioSource.PlayOneShot(bosKameraSesi);
    }
    public static Texture2D FotoyuYukle(string dosyaYolu)
    {
        byte[] fotoBytes = System.IO.File.ReadAllBytes(dosyaYolu);
        Texture2D yuklenenFoto = new Texture2D(2, 2); // Y�klenen foto�raf�n boyutunu belirleyin.
        yuklenenFoto.LoadImage(fotoBytes);
        return yuklenenFoto;
    }

    private void SifirlaFotoKayitlari()
    {
        for (int i = 0; i < fotoCekmeLimiti; i++)
        {
            string dosyaYolu = Application.persistentDataPath + "/foto" + (i + 1) + ".png";
            if (System.IO.File.Exists(dosyaYolu))
            {
                System.IO.File.Delete(dosyaYolu);
            }
        }
    }


}