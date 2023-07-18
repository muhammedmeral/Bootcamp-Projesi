using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kilitliKapı : MonoBehaviour
{
    bool girdiMi = false;
    public AudioClip kilitliKapiSesi;

    // Update is called once per frame
    void Update()
    {
        if (girdiMi == true && Input.GetKeyDown(KeyCode.E))
        {
            AudioSource.PlayClipAtPoint(kilitliKapiSesi, transform.position);
        }


    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            girdiMi = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            girdiMi=false;
        }
    }
}
