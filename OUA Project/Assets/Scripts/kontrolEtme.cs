using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kontrolEtme : MonoBehaviour
{
    public Camera kameraKontrol;
    public GameObject canavar;

    public bool KadrajdaMi()
    {
        Vector3 objePozisyon = canavar.transform.position;
        Vector3 ekranPozisyonu = kameraKontrol.WorldToViewportPoint(objePozisyon);

        if (ekranPozisyonu.x > 0 && ekranPozisyonu.x < 1 && ekranPozisyonu.y > 0 && ekranPozisyonu.y < 1 && ekranPozisyonu.z > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


}
