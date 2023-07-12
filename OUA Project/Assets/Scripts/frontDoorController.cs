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

    private void Start()
    {
        pressEYazi.gameObject.SetActive(false);
        pressE.gameObject.SetActive(false);
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
                pressEYazi.gameObject.SetActive(false);
                pressE.gameObject.SetActive(false);
                backDoor.SetActive(false);
                this.gameObject.SetActive(false);
            }

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



}
