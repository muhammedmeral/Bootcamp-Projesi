using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class renDegisimi : MonoBehaviour
{
    public  Image bloodFrame; // Alpha deðerini deðiþtirmek istediðiniz görüntü

    private float beklemeSuresi = 3f; // Geçiþ süresi (saniye)
    private bool tetiklendiMi = false; // Geçiþ iþlemi devam ediyor mu?

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
