using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class zaman_sayaci : MonoBehaviour
{
    float dakika = 02; // 1. oyundaki dakikayý belirtecek deðiþken
    float saniye = 01; // 2. oyundaki saniyeyi belirtecek deðiþken

    string ikiNokta = ":"; // 3. dakika ve saniye ifadelerinin ortasýnda yer alacak string

    public TextMeshProUGUI zamanSayaci;  //4 arayüz bileþenimiz




    private void Start()
    {


        if (zamanSayaci != null) // 5. eðer bileþen null deðilse, ekranda dakika ve saniyeyi gösterecek kod satýrýmýz.
        {
            zamanSayaci.text = (int)dakika + ikiNokta + (int)saniye;
        }
    }



    private void Update()
    {


        if (zamanSayaci != null)
        {
            saniye -= Time.deltaTime; // 6. saniye deðiþkenimizi, her 1sn içinde 1 azaltmak için Time.deltaTime yapýsýný kullandýk.

            if (saniye < 10)
            { // 7. eðer saniye 10'dan küçükse, rakamýn bir solunda "0" yazmasý için bu þart bloðunu kullandýk.
                zamanSayaci.text = (int)dakika + ikiNokta + "0" + (int)saniye;
            }
            else
                zamanSayaci.text = (int)dakika + ikiNokta + (int)saniye; // 8. deðilse de normal yazsýn dedik.

            if (saniye < 0 && dakika > 0) // 9. eðer saniye 0'dan küçük olursa, dakikayý 1 azalt dedik.
            {
                dakika--;
                saniye = 59;

            }
            else if (saniye <= 0 && dakika <= 0)
            {
                saniye = 0;
                Debug.Log("süre");
                LoseScene.Lose();
            }

        }

    }

    public float Dakika()
    {
        return dakika; 
    }

    public float Saniye()
    {
        return saniye;
    }


}

