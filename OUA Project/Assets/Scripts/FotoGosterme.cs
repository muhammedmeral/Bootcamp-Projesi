using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FotoGosterme : MonoBehaviour
{
    public List<RawImage> rawImages; // 3 adet Raw Image referansý için liste tanýmladýk
    private List<Texture2D> fotoTextureList;

    private void Start()
    {
        fotoTextureList = new List<Texture2D>();

        // Önceki sahneden çekilen fotoðraflarý yükleyin
        for (int i = 1; i <= 3; i++)
        {
            string dosyaYolu = Application.persistentDataPath + "/foto" + i + ".png";
            byte[] fotoBytes = System.IO.File.ReadAllBytes(dosyaYolu);
            Texture2D fotoTexture = new Texture2D(2, 2);
            fotoTexture.LoadImage(fotoBytes);
            fotoTextureList.Add(fotoTexture);
        }

        // Fotoðraflarý Raw Image'lara atayýn
        for (int i = 0; i < fotoTextureList.Count; i++)
        {
            if (i < rawImages.Count)
            {
                RawImage rawImage = rawImages[i];
                rawImage.texture = fotoTextureList[i];
            }
        }
    }
}
