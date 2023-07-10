using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FotoGosterme : MonoBehaviour
{
    public List<RawImage> rawImages; // 3 adet Raw Image referans� i�in liste tan�mlad�k
    private List<Texture2D> fotoTextureList;

    private void Start()
    {
        fotoTextureList = new List<Texture2D>();

        // �nceki sahneden �ekilen foto�raflar� y�kleyin
        for (int i = 1; i <= 3; i++)
        {
            string dosyaYolu = Application.persistentDataPath + "/foto" + i + ".png";
            byte[] fotoBytes = System.IO.File.ReadAllBytes(dosyaYolu);
            Texture2D fotoTexture = new Texture2D(2, 2);
            fotoTexture.LoadImage(fotoBytes);
            fotoTextureList.Add(fotoTexture);
        }

        // Foto�raflar� Raw Image'lara atay�n
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
