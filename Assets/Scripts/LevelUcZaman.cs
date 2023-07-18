using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelUcZaman : MonoBehaviour
{
    public float dakika = 9; // 1. oyundaki dakikay� belirtecek de�i�ken
    public float saniye = 59; // 2. oyundaki saniyeyi belirtecek de�i�ken
    string ikiNokta = ":"; // 3. dakika ve saniye ifadelerinin ortas�nda yer alacak string
    public TextMeshProUGUI zamanSayaci;  //4 aray�z bile�enimiz

    

    public GameObject canavar;
    public Transform[] enemySpawnPoint;
    int spawnLock = 0;  //Canavar�n ortaya ��kmas�n� kontrol etmek i�in kullanaca��z. if blo�unun bir kere �al��mas� gerekiyor.


    private void Start()
    {


        if (zamanSayaci != null) // 5. e�er bile�en null de�ilse, ekranda dakika ve saniyeyi g�sterecek kod sat�r�m�z.
        {
            zamanSayaci.text = (int)dakika + ikiNokta + (int)saniye;
        }
        if (canavar != null)
        {
            canavar.SetActive(false);
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
            else if (saniye <= 0 && dakika <= 0) // S�re doldu�unda olacaklar.
            {
                saniye = 0;

                LoseScene.Lose();
            }

            if (dakika <= 4 && spawnLock == 0) //s�re 2 dakikan�n alt�na d��t���nde canavar�n ortaya ��kmas� sa�lanacak.
            {
                int rndInd = Random.Range(0, 16);
                canavar.transform.position = enemySpawnPoint[rndInd].position;
                canavar.SetActive(true);
                spawnLock++;
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
