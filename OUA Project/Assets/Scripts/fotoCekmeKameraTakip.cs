using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fotoCekmeKameraTakip : MonoBehaviour
{
    public Transform elKamerasi;
    public Camera mainCam;
    Vector3 elKamerasiKonum;
    


    private void Update()
    {
        elKamerasiKonum = elKamerasi.position;
        
        

        this.transform.localPosition = elKamerasiKonum;
        


        if (this.enabled == true)
        {
            Debug.Log("Ýkinci kamera açýk");
        }
        if (this.enabled == false)
        {
            Debug.Log("Ýkinci kamera kapat");
        }
        if (mainCam.enabled == true)
        {
            Debug.Log("Ana kamera açýk");
        }
        if (mainCam.enabled == false)
        {
            Debug.Log("Ana kamera kapalý");
        }





    }



}
