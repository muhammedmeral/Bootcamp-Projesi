using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class zaman_sayaci : MonoBehaviour
{
    float saat = 05;
    float dakika = 59;

    string ikiNokta = ":";

    public TextMeshProUGUI zamanSayaci;



    private void Start()
    {

        if (zamanSayaci!=null)
        {
            zamanSayaci.text = (int)saat + ikiNokta + (int)dakika; 
        }
    }



    private void Update()
    {

        
        if (zamanSayaci != null)
        {
            dakika -= Time.deltaTime;

            if (dakika < 10) {
                zamanSayaci.text = (int)saat + ikiNokta+"0" + (int)dakika;
            }
            else
                zamanSayaci.text = (int)saat + ikiNokta + (int)dakika;

            if (dakika < 0)
            {
                saat--;
                dakika = 59;
            }
            
        }

    }


    
}

