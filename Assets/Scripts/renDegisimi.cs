using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class renDegisimi : MonoBehaviour
{
    public  Image bloodFrame; // Alpha de�erini de�i�tirmek istedi�iniz g�r�nt�

    private float beklemeSuresi = 3f; // Ge�i� s�resi (saniye)
    private bool tetiklendiMi = false; // Ge�i� i�lemi devam ediyor mu?

    private void Start()
    {
        bloodFrame.gameObject.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.CapsLock) && !tetiklendiMi)
        {
            tetiklendiMi = true;
            StartCoroutine(FadeOutAlpha());
        }
    }
    //void renkFonksiyonu()
    //{
    //    isTransitioning = true;
    //    StartCoroutine(FadeOutAlpha());
    //}

    IEnumerator FadeOutAlpha()
    {
        bloodFrame.gameObject.SetActive(true);
        float zamanlayici = 0f;
        Color startColor = bloodFrame.color;
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 0f);

        while (zamanlayici < beklemeSuresi)
        {
            zamanlayici += Time.deltaTime;
            float t = zamanlayici / beklemeSuresi;
            bloodFrame.color = Color.Lerp(startColor, endColor, t);
            yield return null;
        }

        bloodFrame.color = endColor;
        tetiklendiMi = false;

        if (bloodFrame.color.a <= 0)
        {
            bloodFrame.color = startColor;
            bloodFrame.gameObject.SetActive(false);
        }
    }
}
