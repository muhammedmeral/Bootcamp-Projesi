using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class zaman_sayaci : MonoBehaviour
{
    float dakika = 02; // 1. oyundaki dakikay� belirtecek de�i�ken
    float saniye = 01; // 2. oyundaki saniyeyi belirtecek de�i�ken

    string ikiNokta = ":"; // 3. dakika ve saniye ifadelerinin ortas�nda yer alacak string

    public TextMeshProUGUI zamanSayaci;  //4 aray�z bile�enimiz




    private void Start()
    {


        if (zamanSayaci != null) // 5. e�er bile�en null de�ilse, ekranda dakika ve saniyeyi g�sterecek kod sat�r�m�z.
        {
            zamanSayaci.text = (int)dakika + ikiNokta + (int)saniye;
        }
    }



    private void Update()
    {


        if (zamanSayaci != null)
        {
            saniye -= Time.deltaTime; // 6. saniye de�i�kenimizi, her 1sn i�inde 1 azaltmak i�in Time.deltaTime yap�s�n� kulland�k.

            if (saniye < 10)
            { // 7. e�er saniye 10'dan k���kse, rakam�n bir solunda "0" yazmas� i�in bu �art blo�unu kulland�k.
                zamanSayaci.text = (int)dakika + ikiNokta + "0" + (int)saniye;
            }
            else
                zamanSayaci.text = (int)dakika + ikiNokta + (int)saniye; // 8. de�ilse de normal yazs�n dedik.

            if (saniye < 0 && dakika > 0) // 9. e�er saniye 0'dan k���k olursa, dakikay� 1 azalt dedik.
            {
                dakika--;
                saniye = 59;

            }
            else if (saniye <= 0 && dakika <= 0)
            {
                saniye = 0;
                Debug.Log("s�re");
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

