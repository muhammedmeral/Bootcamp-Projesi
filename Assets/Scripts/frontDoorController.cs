using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class frontDoorController : MonoBehaviour
{
    //Bu scriptin detaylý anlatýmý, backDoorController adýndaki scriptte anlatýlmýþtýr. Çalýþma prensipleri aynýdýr.

    public Animator anim;
    public GameObject backDoor;
    public TextMeshProUGUI pressEYazi;
    public Image pressE;
    bool triggereGirdiMi = false;
    bool triggerdenCiktiMi = false;
    bool eTusunaBastiMi = false;

    public AudioClip[] kapiAcilma;
    AudioSource _auidioSource;

    private void Start()
    {
        pressEYazi.gameObject.SetActive(false);
        pressE.gameObject.SetActive(false);
        _auidioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        

        if (triggereGirdiMi == true && eTusunaBastiMi == false && triggerdenCiktiMi == false)
        {
            pressEYazi.gameObject.SetActive(true);
            pressE.gameObject.SetActive(true);
        }
        else if (triggereGirdiMi == false && eTusunaBastiMi == false && triggerdenCiktiMi == true)
        {
            pressEYazi.gameObject.SetActive(false);
            pressE.gameObject.SetActive(false);
        }
        

    }


    private void OnTriggerStay(Collider other)
    {

        if (other.tag == "Player")
        {
            triggereGirdiMi = true;
            triggerdenCiktiMi = false;

            if (Input.GetKeyDown(KeyCode.E))
            {
                eTusunaBastiMi = true;
                anim.SetTrigger("frontDoorTrigger");
                StartCoroutine(KapininAcilmaSesleri());
                
                pressEYazi.gameObject.SetActive(false);
                pressE.gameObject.SetActive(false);
                backDoor.SetActive(false);
                this.gameObject.SetActive(false);
            }

        }
        else if (other.tag == "enemy")
        {
            anim.SetTrigger("frontDoorTrigger");
            StartCoroutine(KapininAcilmaSesleri());
            backDoor.SetActive(false);
            this.gameObject.SetActive(false);
        }



    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            triggerdenCiktiMi = true;
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
