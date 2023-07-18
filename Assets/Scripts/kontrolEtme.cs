//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class kontrolEtme : MonoBehaviour
//{
//    //public Camera kameraKontrol;
//    //public GameObject canavar;

//    private void Start()
//    {
//        // Scriptin baðlý olduðu objeleri bul
//        GameObject[] objeler = GameObject.FindGameObjectsWithTag("YourTag");

//        // Bulunan objeleri kontrol et
//        foreach (GameObject obje in objeler)
//        {
//            if (obje.GetComponent<kontrolEtme>() != null)
//            {
//                // Script objede bulundu
//                Debug.Log("Script, " + obje.name + " objesine ekli.");
//            }
//            else
//                Debug.Log("Bir objeye ekli deðil");
//        }
//    }





//    //public bool KadrajdaMi()
//    //{
//    //    Vector3 objePozisyon = canavar.transform.position;
//    //    Vector3 ekranPozisyonu = kameraKontrol.WorldToViewportPoint(objePozisyon);

//    //    if (ekranPozisyonu.x > 0 && ekranPozisyonu.x < 1 && ekranPozisyonu.y > 0 && ekranPozisyonu.y < 1 && ekranPozisyonu.z > 0)
//    //    {
//    //        return true;
//    //    }
//    //    else
//    //    {
//    //        return false;
//    //    }
//    //}


//}
