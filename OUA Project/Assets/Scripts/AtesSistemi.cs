using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtesSistemi : MonoBehaviour
{
    Camera kamera;
    public LayerMask canavarKatman;
  
    void Start()
    {
        kamera = Camera.main;
    }

    void Update()
    {
        
        if (Input.GetMouseButton(0))
        {
            AtesEt();
        }
    }

    void AtesEt()
    {

        Ray ray = kamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, Mathf.Infinity, canavarKatman))
        {
            if (hit.collider != null)
            {
                hit.collider.gameObject.GetComponent<CanavarController>().HasarAl();
            }
        }

    }
}
