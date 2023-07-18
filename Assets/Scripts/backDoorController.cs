using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class backDoorController : MonoBehaviour
{
    public Animator anim;  //1. Kapý animatörü
    public GameObject frontDoor;//2. Kapýnýn diðer ucundaki tetikleyici
    public TextMeshProUGUI pressEYazi;//3. Ekranda çýkacak yazý
    public Image pressE;//4. ekranda çýkacak sembol
    bool triggereGirdiMi = false;//5. karakterin triggere girip girmediðini kontrol eden deðiþken.
    bool triggerdenCiktiMi = false;//6. karakterin triggerden çýkýp çýkmadýðýný kontrol eden deðiþken.
    bool eTusunaBastiMi = false;//7. karakterin triggerin içindeyken e tuþuna basýp basmadýðýný kontrol eden deðiþken.

    public AudioClip[] kapiAcilma;  //kapý sesini tutacak deðiþken
    AudioSource _auidioSource; //kapý sesinini oynayacak component
    
    
    private void Start()
    {
        pressEYazi.gameObject.SetActive(false); //8. baþlangýçta yazý ve sembolün görünmesini istemediðimiz için gizliyoruz.
        pressE.gameObject.SetActive(false);
        _auidioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        
        if (triggereGirdiMi == true && eTusunaBastiMi == false && triggerdenCiktiMi == false) //12. Eðer karakter triggere girer ve e tuþuna basmazsa ve triggerden çýkmazsa bu kod bloðu çalýþýyor.
        {
            pressEYazi.gameObject.SetActive(true);
            pressE.gameObject.SetActive(true);
        }
        else if (triggereGirdiMi == false && eTusunaBastiMi == false && triggerdenCiktiMi == true) //Eðer karakter triggere girdikten sonra, e tuþuna basmadan triggerden çýkarsa bu kod bloðu çalýþýyor.
        {
            pressEYazi.gameObject.SetActive(false);
            pressE.gameObject.SetActive(false);
        }
        //if (eTusunaBastiMi)
        //{
        //    _auidioSource.PlayOneShot(kapiAcilma); //Kapý açýlma sesi oynayacak.
            
        //}

    }


    private void OnTriggerStay(Collider other)
    {

        if (other.tag == "Player") 
        {
            triggereGirdiMi = true;  //9. eðer karakter triggere girerse, triggere girdiði deðiþken true, çýktýðý deðiþken ise false alýyor.
            triggerdenCiktiMi = false;           
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                eTusunaBastiMi = true;   //10. eðer karakter e tuþuna basarsa animasyon oynuyor, yazý ve sembol gizleniyor ve kapý uçlarýndaki triggerler gizleniyor.
                anim.SetTrigger("backDoorTrigger");
                StartCoroutine(KapininAcilmaSesleri());
                pressEYazi.gameObject.SetActive(false);
                pressE.gameObject.SetActive(false);
                frontDoor.SetActive(false);
                this.gameObject.SetActive(false);
            }

        }

        else if (other.tag == "enemy")
        {
            anim.SetTrigger("backDoorTrigger");
            StartCoroutine(KapininAcilmaSesleri());
            frontDoor.SetActive(false);
            this.gameObject.SetActive(false);
        }



    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            triggerdenCiktiMi = true;  //11. triggerden çýktýðýnda ilgili deðiþkenler beliritlen deðerleri alýyor.
            triggereGirdiMi = false;
            
        }
    }

    private IEnumerator KapininAcilmaSesleri()
    {
        int indxNo = Random.Range(0, 3);
        AudioSource.PlayClipAtPoint(kapiAcilma[indxNo], transform.position);
        yield return new WaitForSeconds(kapiAcilma[indxNo].length);
    }

}
