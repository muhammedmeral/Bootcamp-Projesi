using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FotoCekme : MonoBehaviour
{
    public Camera fotoCekmeKamerasi;
    public List<RawImage> fotoGostericiler; // Birden fazla Raw Image için liste tanýmladýk
    private List<Texture2D> fotoTextureList;
    int fotoCekmeLimiti = 3;

    public LayerMask canavarLayer;

    public GameObject canavar;
    public Camera anaKamera;

    
    private void Start()
    {
        fotoTextureList = new List<Texture2D>();
    }

    private void Update()
    {
        
        if (Input.GetMouseButtonDown(0) && fotoCekmeLimiti > 0)
        {
            CanavariFotoCek();
            
            
            Kaydet();
            fotoCekmeLimiti--;
        }

        TumFotograflariGoster();
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
        if (KadrajdaMi() == true)
        {
            Debug.Log("Canaver kadrajdaydi len efferin");
        }
        else
        {
            Debug.Log("Masmaalesef beceremedin denyo");
        }
    }

    public void TumFotograflariGoster()   //Bu kýsým arayüz iþinden sonra silinecek.
    {
        for (int i = 0; i < fotoTextureList.Count; i++)
        {
            if (i < fotoGostericiler.Count)
            {
                RawImage fotoGosterici = fotoGostericiler[i];
                Texture2D fotoTexture = fotoTextureList[i];
                fotoGosterici.texture = fotoTexture;
            }
        }
    }

    public void Kaydet()
    {
        for (int i = 0; i < fotoTextureList.Count; i++)
        {
            byte[] fotoBytes = fotoTextureList[i].EncodeToPNG();
            string dosyaYolu = Application.persistentDataPath + "/foto" + (i + 1) + ".png";
            System.IO.File.WriteAllBytes(dosyaYolu, fotoBytes);
        }
    }
}