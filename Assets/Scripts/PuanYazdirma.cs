using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PuanYazdirma : MonoBehaviour
{ 

    public int canavarOldu = 0;
    public int fotoCekildi = 0;

    public Image yildizBir;
    public Image yildizIki;
    public Image yildizUc;
    public Image yildizDort;
    public Image yildizBes;
    public Image yildizAlti;

    public TextMeshProUGUI yaziBir;
    public TextMeshProUGUI yaziIki;
    public TextMeshProUGUI yaziUc;
    public TextMeshProUGUI yaziDort;




    private void Start()
    {
        
        canavarOldu = PlayerPrefs.GetInt("canavarOlduMu");
        fotoCekildi = PlayerPrefs.GetInt("fotoCekildiMi");

        canavarOldu = PlayerPrefs.GetInt("canavarOlduMu");
        fotoCekildi = PlayerPrefs.GetInt("fotoCekildiMi");
        
        
    }

    private void Update()
    {
        if (canavarOldu == 1 && fotoCekildi == 1) //Hem foto hem canavar öldü
        {
            yildizBir.gameObject.SetActive(true);
            yildizIki.gameObject.SetActive(true);
            yildizUc.gameObject.SetActive(true);
            yildizDort.gameObject.SetActive(false);
            yildizBes.gameObject.SetActive(false);
            yildizAlti.gameObject.SetActive(false);

            yaziBir.gameObject.SetActive(true);
            yaziIki.gameObject.SetActive(false);
            yaziUc.gameObject.SetActive(false);
            yaziDort.gameObject.SetActive(false);
        }
        else if (canavarOldu == 1 && fotoCekildi == 0) //Caavar öldü ama foto yok
        {

            yildizBir.gameObject.SetActive(false);
            yildizIki.gameObject.SetActive(false);
            yildizUc.gameObject.SetActive(false);
            yildizDort.gameObject.SetActive(true);
            yildizBes.gameObject.SetActive(true);
            yildizAlti.gameObject.SetActive(false);

            yaziBir.gameObject.SetActive(false);
            yaziIki.gameObject.SetActive(true);
            yaziUc.gameObject.SetActive(false);
            yaziDort.gameObject.SetActive(false);
        }
        else if (canavarOldu == 0 && fotoCekildi == 1) //Foto çekildi ama canavar ölmedi
        {
            yildizBir.gameObject.SetActive(false);
            yildizIki.gameObject.SetActive(false);
            yildizUc.gameObject.SetActive(false);
            yildizDort.gameObject.SetActive(true);
            yildizBes.gameObject.SetActive(true);
            yildizAlti.gameObject.SetActive(false);

            yaziBir.gameObject.SetActive(false);
            yaziIki.gameObject.SetActive(false);
            yaziUc.gameObject.SetActive(true);
            yaziDort.gameObject.SetActive(false);
        }
        else if (canavarOldu == 0 && fotoCekildi == 0)
        //Zamanýnda çýktý ama baþka bir þey yok
        {

            yildizBir.gameObject.SetActive(false);
            yildizIki.gameObject.SetActive(false);
            yildizUc.gameObject.SetActive(false);
            yildizDort.gameObject.SetActive(false);
            yildizBes.gameObject.SetActive(false);
            yildizAlti.gameObject.SetActive(true);

            yaziBir.gameObject.SetActive(false);
            yaziIki.gameObject.SetActive(false);
            yaziUc.gameObject.SetActive(false);
            yaziDort.gameObject.SetActive(true);
        }
        print("Canavar Durumu: " + canavarOldu + " Foto Durumu: " + fotoCekildi);
    }
}


