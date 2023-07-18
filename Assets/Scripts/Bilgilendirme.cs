using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bilgilendirme : MonoBehaviour
{
    public TextMeshProUGUI yazi;

    private void Start()
    {
        StartCoroutine(BilgilendirmeCor());
    }


    IEnumerator BilgilendirmeCor()
    {
        yazi.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(8f);
        yazi.gameObject.SetActive(false);
    }

   
}
