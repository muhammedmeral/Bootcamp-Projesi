using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FotoCekme : MonoBehaviour
{
    public Camera fotoCekmeKamerasi;
    public RawImage fotoGosterici;
    private List<Texture2D> fotoTextureList;
    Camera mainCam;
    Vector3 mainPos;
    Quaternion mainRot;
    float fotoCekmeLimiti = 3f;
    

    private void Start()
    {
        fotoTextureList = new List<Texture2D>();
        mainCam = Camera.main;
       
    }

    private void Update()
    {
        mainPos = mainCam.transform.position;
        mainRot = mainCam.transform.rotation;

        if (Input.GetMouseButtonDown(0)&&fotoCekmeLimiti>0)
        {
            
            Instantiate(fotoCekmeKamerasi, mainPos, mainRot);
            CanavariFotoCek();
            Kaydet();
            Debug.Log("Foto kaydedildi.");
            Destroy(fotoCekmeKamerasi);
            fotoCekmeLimiti--;
        }
        
        if (Input.GetKeyDown(KeyCode.T))
        {
            TumFotograflariGoster();
        }
    }

    public void CanavariFotoCek()
    {
        RenderTexture renderTexture = new RenderTexture(Screen.width, Screen.height, 24);
        fotoCekmeKamerasi.targetTexture = renderTexture;
        Texture2D fotoTexture2D = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false); // De�i�iklik burada

        // Ekran�n kitlenmesini �nlemek i�in renderTexture'in tamamlanmas�n� bekleyin
        StartCoroutine(CaptureRenderTexture(renderTexture, fotoTexture2D));
    }

    public void FotoyuGoster()
    {
        if (fotoTextureList.Count > 0)
        {
            Texture2D sonFoto = fotoTextureList[fotoTextureList.Count - 1];
            fotoGosterici.texture = sonFoto;
        }
    }

    public void TumFotograflariGoster()
    {
        if (fotoTextureList.Count > 0)
        {
            int xOffset = 0;
            int totalWidth = Screen.width * fotoTextureList.Count;
            Texture2D tumFotograflar = new Texture2D(totalWidth, Screen.height, TextureFormat.RGB24, true);

            foreach (Texture2D fotoTexture in fotoTextureList)
            {
                Color32[] pixels = fotoTexture.GetPixels32();
                tumFotograflar.SetPixels32(xOffset, 0, fotoTexture.width, fotoTexture.height, pixels);
                xOffset += fotoTexture.width;
            }

            tumFotograflar.Apply();
            fotoGosterici.texture = tumFotograflar;

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


    private IEnumerator CaptureRenderTexture(RenderTexture renderTexture, Texture2D fotoTexture2D)
    {
        yield return new WaitForEndOfFrame();

        fotoCekmeKamerasi.Render();
        RenderTexture.active = renderTexture;
        fotoTexture2D.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        fotoTexture2D.Apply();
        fotoCekmeKamerasi.targetTexture = null;
        RenderTexture.active = null;
        Destroy(renderTexture);

        fotoTextureList.Add(fotoTexture2D);
    }
}
