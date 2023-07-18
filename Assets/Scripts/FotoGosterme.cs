using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class FotoGosterme : MonoBehaviour
{
    public RawImage gosterici; // Foto�raf� g�sterece�iniz nesne i�in referans.
    private FotoCekme fotoCekme;
    public Image fotoCerceve;

    //public Image yildizAlti;
    //public TextMeshProUGUI yaziDort;
    private void Start()
    {

        fotoCekme = FindObjectOfType<FotoCekme>();
        fotoCerceve.gameObject.SetActive(false);
        gosterici.gameObject.SetActive(false);
        Debug.Log("start");
        //yildizAlti.gameObject.SetActive(false);
        //yaziDort.gameObject.SetActive(false);


        if (FotoCekme.FotoyuYukle(Application.persistentDataPath + "/foto1.png"))
        {

            Debug.Log("foto");
            gosterici.gameObject.SetActive(true);
            fotoCerceve.gameObject.SetActive(true);
            Texture2D yuklenenFoto = FotoCekme.FotoyuYukle(Application.persistentDataPath + "/foto1.png");
            gosterici.texture = yuklenenFoto;
            //yildizAlti.gameObject.SetActive(false);
            //yaziDort.gameObject.SetActive(false);

        }
        //else
        //{
        //    //yildizAlti.gameObject.SetActive(true);
        //    //yaziDort.gameObject.SetActive(true);
        //}


    }

}