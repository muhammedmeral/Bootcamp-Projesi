using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CanavarController : MonoBehaviour
{
    public Animator anim;  //1. Canavar�n animasyonlar�n� kontrol edecek component.
    public GameObject hedef; //2. Canavar�n hedefi olacak. (Oyuncu)
    NavMeshAgent nmesh; //4. Canavardaki navmesh agent compenentini tutacak de�i�ken.
    public float mesafe; //5. Canavar ve karaktermiz aras�ndaki mesafeyi �l�ecek de�i�ken. (Bu mesafeye g�re ilgili animasyon ve olaylar�n �al��mas� kontrol edilecek.)



    private void Start()
    {

        nmesh = GetComponent<NavMeshAgent>(); //6. Navmesh componentimizi cache ettik.
        


    }

    private void Update()
    {
       
        
        mesafe = Vector3.Distance(hedef.transform.position,transform.position); //10. Bu k�s�m, canavarla karakterin aras�ndaki mesafeyi �l�ecek.

        nmesh.destination = hedef.transform.position;  //7. Bu kod sat�r� sayesinde, canavar haritada karakterimizi takip edecek.

        
        if (mesafe < 8 && mesafe>2.5f) //11. Bu k�s�mda canavar, karaktere do�ru ko�acak.
        {
            //Bu k�s�mda ko�ma ses efekti kullan�lacak.
            walkToRun();
            nmesh.speed = 2.4f;
            anim.SetBool("isAttack1", false);
            anim.SetBool("isAttack2", false);


        }
        if (mesafe >= 9 ) //13. Bu k�s�mda canavar karaktere do�ru y�r�yecek.
        {
            //Bu k�s�mda y�r�me ses efekti kullan�lacak.
            runToWalk();
            nmesh.speed = 1.8f;
            anim.SetBool("isAttack1", false);
            anim.SetBool("isAttack2", false);


        }

        if (mesafe <= 2.5f) //14. Bu k�s�mda canavar�n sald�r� animasyonlar� �al���yor.
        {
            //Bu k�s�mda sald�r� ses efekti kullan�lacak.
            anim.SetBool("isWalk", false);
            anim.SetBool("isRun", false);
            anim.SetBool("isAttack1", true);
            anim.SetBool("isAttack2", true);
        }
        


    }

    void walkToRun() //8. Bu fonksiyonda, canavar y�r�rken, ko�ma durumuna ge�ecek.
    {
        anim.SetBool("isWalk", false);
        anim.SetTrigger("walkToIddle");
        //Bu k�s�mda canavar�n k�kreme ses efekti kullan�lacak.
        StartCoroutine(IddleBekleme());
        anim.SetBool("isRun", true);
        
        
        
    }
    void runToWalk() //9. Bu fonksiyonda canavar ko�arken, y�r�me durumuna ge�ecek.
    {
        anim.SetBool("isRun", false);
        anim.SetBool("isWalk", true);
        
    }

  



    IEnumerator IddleBekleme() // 12 .walk animden iddle anime ge�ti�i s�rada canavar�n yerinde beklemesi i�in bu yap�y� kulland�k.
    {
        nmesh.stoppingDistance = 50f;
        yield return new WaitForSecondsRealtime(2f);
        nmesh.stoppingDistance = 1.5f;
    }

}
