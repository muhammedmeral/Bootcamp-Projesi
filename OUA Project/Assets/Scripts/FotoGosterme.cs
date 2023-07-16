using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FotoGosterme : MonoBehaviour
{
    public RawImage gosterici; // Foto�raf� g�sterece�iniz nesne i�in referans.
    private FotoCekme fotoCekme;
    public Image fotoCerceve;
    private void Start()
    {
        
        fotoCekme = FindObjectOfType<FotoCekme>();
        fotoCerceve.gameObject.SetActive(false);
        gosterici.gameObject.SetActive(false);
        Debug.Log("start");

       
    }
    private void Update()
    {
        if (fotoCekme != null )
        {
            Debug.Log("foto");
            gosterici.gameObject.SetActive(true);
            fotoCerceve.gameObject.SetActive(true);
            Texture2D yuklenenFoto = FotoCekme.FotoyuYukle(Application.persistentDataPath + "/foto1.png");
            gosterici.texture = yuklenenFoto;
        }
    }
}



