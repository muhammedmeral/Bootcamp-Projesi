using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FotoGosterme : MonoBehaviour
{
    public RawImage gosterici; // Foto�raf� g�sterece�iniz nesne i�in referans.

    private void Start()
    {
        // �kinci sahnede foto�raf� y�kleyin.
        Texture2D yuklenenFoto = FotoCekme.FotoyuYukle(Application.persistentDataPath + "/foto1.png");

        // Foto�raf� g�sterece�iniz nesneye atay�n.
        gosterici.texture = yuklenenFoto;
    }
}


 
