using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class backDoorController : MonoBehaviour
{
    public Animator anim;  //1. Kap� animat�r�
    public GameObject frontDoor;//2. Kap�n�n di�er ucundaki tetikleyici
    public TextMeshProUGUI pressEYazi;//3. Ekranda ��kacak yaz�
    public Image pressE;//4. ekranda ��kacak sembol
    bool triggereGirdiMi = false;//5. karakterin triggere girip girmedi�ini kontrol eden de�i�ken.
    bool triggerdenCiktiMi = false;//6. karakterin triggerden ��k�p ��kmad���n� kontrol eden de�i�ken.
    bool eTusunaBastiMi = false;//7. karakterin triggerin i�indeyken e tu�una bas�p basmad���n� kontrol eden de�i�ken.
    
    private void Start()
    {
        pressEYazi.gameObject.SetActive(false); //8. ba�lang��ta yaz� ve sembol�n g�r�nmesini istemedi�imiz i�in gizliyoruz.
        pressE.gameObject.SetActive(false);
    }

    private void Update()
    {
        
        if (triggereGirdiMi == true && eTusunaBastiMi == false && triggerdenCiktiMi == false) //12. E�er karakter triggere girer ve e tu�una basmazsa ve triggerden ��kmazsa bu kod blo�u �al���yor.
        {
            pressEYazi.gameObject.SetActive(true);
            pressE.gameObject.SetActive(true);
        }
        else if (triggereGirdiMi == false && eTusunaBastiMi == false && triggerdenCiktiMi == true) //E�er karakter triggere girdikten sonra, e tu�una basmadan triggerden ��karsa bu kod blo�u �al���yor.
        {
            pressEYazi.gameObject.SetActive(false);
            pressE.gameObject.SetActive(false);
        }
       

    }


    private void OnTriggerStay(Collider other)
    {

        if (other.tag == "Player") 
        {
            triggereGirdiMi = true;  //9. e�er karakter triggere girerse, triggere girdi�i de�i�ken true, ��kt��� de�i�ken ise false al�yor.
            triggerdenCiktiMi = false;           
            if (Input.GetKeyDown(KeyCode.E))
            {
                eTusunaBastiMi = true;   //10. e�er karakter e tu�una basarsa animasyon oynuyor, yaz� ve sembol gizleniyor ve kap� u�lar�ndaki triggerler gizleniyor.
                anim.SetTrigger("backDoorTrigger");
                pressEYazi.gameObject.SetActive(false);
                pressE.gameObject.SetActive(false);
                frontDoor.SetActive(false);
                this.gameObject.SetActive(false);
            }

        }



    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            triggerdenCiktiMi = true;  //11. triggerden ��kt���nda ilgili de�i�kenler beliritlen de�erleri al�yor.
            triggereGirdiMi = false;
            
        }
    }

    

}
