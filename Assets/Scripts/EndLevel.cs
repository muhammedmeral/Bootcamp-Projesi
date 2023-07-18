using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    public TextMeshProUGUI oyunBitirmeYazisi;
    public float _dakika;
    public zaman_sayaci zaman;
    bool cikabilirMi = false;
    public Image pressE;
    public AudioClip kilitliKapiSesi;
    public AudioSource audioSource;
    public AudioClip kapiAcilmaSesi;

    void Start()
    {
        pressE.gameObject.SetActive(false);
        oyunBitirmeYazisi.gameObject.SetActive(false);
    }
    private void Update()
    {
        _dakika = zaman.Dakika();

        if (zaman != null)
        {
            if (_dakika <= 1 && cikabilirMi == true)
            {
                pressE.gameObject.SetActive(true);
                oyunBitirmeYazisi.gameObject.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    audioSource.PlayOneShot(kapiAcilmaSesi);
                    Cursor.lockState = CursorLockMode.Confined;
                    SceneManager.LoadScene("fotoEkrani");
                    
                }
            }

            else if (_dakika > 1 && cikabilirMi == true)
            {

                pressE.gameObject.SetActive(false);
                oyunBitirmeYazisi.gameObject.SetActive(false);


                if (Input.GetKeyDown(KeyCode.E))
                {
                    audioSource.PlayOneShot(kilitliKapiSesi);
                    Debug.Log("çalýþtý");

                }
            }
        }
       

        
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            cikabilirMi = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            cikabilirMi = false;
        }
    }
}
