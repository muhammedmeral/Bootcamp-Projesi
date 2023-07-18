using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelUcZaman : MonoBehaviour
{
    public float dakika = 9; // 1. oyundaki dakikayý belirtecek deðiþken
    public float saniye = 59; // 2. oyundaki saniyeyi belirtecek deðiþken
    string ikiNokta = ":"; // 3. dakika ve saniye ifadelerinin ortasýnda yer alacak string
    public TextMeshProUGUI zamanSayaci;  //4 arayüz bileþenimiz

    

    public GameObject canavar;
    public Transform[] enemySpawnPoint;
    int spawnLock = 0;  //Canavarýn ortaya çýkmasýný kontrol etmek için kullanacaðýz. if bloðunun bir kere çalýþmasý gerekiyor.


    private void Start()
    {


        if (zamanSayaci != null) // 5. eðer bileþen null deðilse, ekranda dakika ve saniyeyi gösterecek kod satýrýmýz.
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
            else if (saniye <= 0 && dakika <= 0) // Süre dolduðunda olacaklar.
            {
                saniye = 0;

                LoseScene.Lose();
            }

            if (dakika <= 4 && spawnLock == 0) //süre 2 dakikanýn altýna düþtüðünde canavarýn ortaya çýkmasý saðlanacak.
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
