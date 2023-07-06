using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CanavarController : MonoBehaviour
{
    public Animator anim;  //1. Canavarýn animasyonlarýný kontrol edecek component.
    
    public GameObject hedef; //2. Canavarýn hedefi olacak. (Oyuncu)
   
    NavMeshAgent nmesh; //3. Canavardaki navmesh agent compenentini tutacak deðiþken.
    
    public float mesafe; //4. Canavar ve karaktermiz arasýndaki mesafeyi ölçecek deðiþken. (Bu mesafeye göre ilgili animasyon ve olaylarýn çalýþmasý kontrol edilecek.)



    private void Start()
    {
        nmesh = GetComponent<NavMeshAgent>(); // Navmesh componentimizi cache ettik.


    }

    private void Update()
    {
       mesafe = Vector3.Distance(hedef.transform.position,transform.position); //Bu kýsým, canavarla karakterin arasýndaki mesafeyi ölçecek.

       nmesh.destination = hedef.transform.position;  // Bu kod satýrý sayesinde, canavar haritada karakterimizi takip edecek.

        Debug.Log("Mesafe: " + mesafe);

        if (mesafe > 8f) //walk anim çalýþacak.
        {
            anim.SetBool("isAttack1", false);
            anim.SetBool("isAttack2", false);
            anim.SetBool("isWalk", true);
            anim.SetBool("isRun", false);
            //bu kýsýmda yürüme ses efekti çalacak.
        }

        else if (mesafe >= 2.5f && mesafe <= 8f) //iddle ve run animler çalýþacak.
        {
            anim.SetBool("isAttack1", false);
            anim.SetBool("isAttack2", false);
            anim.SetBool("isWalk", false);
            anim.SetTrigger("walkToIddle");
            //bu kýsýmda kükreme ses efekti çalacak.
            StartCoroutine(IddleBekleme());
            anim.SetBool("isRun", true);
            //bu kýsýmda koþma ses efekti çalacak.
        }
         
        else if (mesafe < 2.5f) //Attack animasyonlarý çalýþacak.
        {
            anim.SetBool("isWalk", false);
            anim.SetBool("isRun", false);
            anim.SetBool("isAttack1", true);
            //burada attack1 animasyonu çalacak.
            anim.SetBool("isAttack2", true);
            //burada attack2 anias

        }









    }

    IEnumerator IddleBekleme() // 12 .walk animden iddle anime geçtiði sýrada canavarýn yerinde beklemesi için bu yapýyý kullandýk.
    {
        nmesh.stoppingDistance = 50f;
        yield return new WaitForSecondsRealtime(2f);
        nmesh.stoppingDistance = 1.5f;
    }

}
