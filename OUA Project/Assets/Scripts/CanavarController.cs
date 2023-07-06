using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CanavarController : MonoBehaviour
{
    public Animator anim;  //1. Canavar�n animasyonlar�n� kontrol edecek component.
    
    public GameObject hedef; //2. Canavar�n hedefi olacak. (Oyuncu)
   
    NavMeshAgent nmesh; //3. Canavardaki navmesh agent compenentini tutacak de�i�ken.
    
    public float mesafe; //4. Canavar ve karaktermiz aras�ndaki mesafeyi �l�ecek de�i�ken. (Bu mesafeye g�re ilgili animasyon ve olaylar�n �al��mas� kontrol edilecek.)



    private void Start()
    {
        nmesh = GetComponent<NavMeshAgent>(); // Navmesh componentimizi cache ettik.


    }

    private void Update()
    {
       mesafe = Vector3.Distance(hedef.transform.position,transform.position); //Bu k�s�m, canavarla karakterin aras�ndaki mesafeyi �l�ecek.

       nmesh.destination = hedef.transform.position;  // Bu kod sat�r� sayesinde, canavar haritada karakterimizi takip edecek.

        Debug.Log("Mesafe: " + mesafe);

        if (mesafe > 8f) //walk anim �al��acak.
        {
            anim.SetBool("isAttack1", false);
            anim.SetBool("isAttack2", false);
            anim.SetBool("isWalk", true);
            anim.SetBool("isRun", false);
            //bu k�s�mda y�r�me ses efekti �alacak.
        }

        else if (mesafe >= 2.5f && mesafe <= 8f) //iddle ve run animler �al��acak.
        {
            anim.SetBool("isAttack1", false);
            anim.SetBool("isAttack2", false);
            anim.SetBool("isWalk", false);
            anim.SetTrigger("walkToIddle");
            //bu k�s�mda k�kreme ses efekti �alacak.
            StartCoroutine(IddleBekleme());
            anim.SetBool("isRun", true);
            //bu k�s�mda ko�ma ses efekti �alacak.
        }
         
        else if (mesafe < 2.5f) //Attack animasyonlar� �al��acak.
        {
            anim.SetBool("isWalk", false);
            anim.SetBool("isRun", false);
            anim.SetBool("isAttack1", true);
            //burada attack1 animasyonu �alacak.
            anim.SetBool("isAttack2", true);
            //burada attack2 anias

        }









    }

    IEnumerator IddleBekleme() // 12 .walk animden iddle anime ge�ti�i s�rada canavar�n yerinde beklemesi i�in bu yap�y� kulland�k.
    {
        nmesh.stoppingDistance = 50f;
        yield return new WaitForSecondsRealtime(2f);
        nmesh.stoppingDistance = 1.5f;
    }

}
