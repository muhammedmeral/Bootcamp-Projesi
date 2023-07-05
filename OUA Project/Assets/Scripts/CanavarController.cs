using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CanavarController : MonoBehaviour
{
    public Animator anim;  //1. Canavar�n animasyonlar�n� kontrol edecek component.
    public GameObject hedef; //2. Canavar�n hedefi olacak. (Oyuncu)
    //[SerializeField] float hareketHizi; //3. Canavar�n hareket h�z�n� tutacak de�i�ken.
    NavMeshAgent nmesh; //4. Canavardaki navmesh agent compenentini tutacak de�i�ken.
    bool isAttack = false;
    
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
            

        }
        if (mesafe >= 9 ) //13. Bu k�s�mda canavar karaktere do�ru y�r�yecek.
        {
            runToWalk();
            nmesh.speed = 1.8f;

        }
        
        

        






    }

    void walkToRun() //8. Bu fonksiyonda, canavar y�r�rken, ko�ma durumuna ge�ecek.
    {
        anim.SetBool("isWalk", false);
        anim.SetTrigger("walkToIddle");
        StartCoroutine(IddleBekleme());
        anim.SetBool("isRun", true);
        
        
        
    }
    void runToWalk() //9. Bu fonksiyonda canavar ko�arken, y�r�me durumuna ge�ecek.
    {
        anim.SetBool("isRun", false);
        anim.SetBool("isWalk", true);
        
    }

    void runToAttack()
    {
        
        anim.SetBool("isRun", false);
        anim.SetTrigger("isAttack1");
        anim.SetBool("isAttack2", true);

       

    }
    //void attackToRun()
    //{
        
        
    //}




    IEnumerator IddleBekleme() // 12 .walk animden iddle anime ge�ti�i s�rada canavar�n yerinde beklemesi i�in bu yap�y� kulland�k.
    {
        nmesh.stoppingDistance = 50f;
        yield return new WaitForSecondsRealtime(2f);
        nmesh.stoppingDistance = 1.5f;
    }

}
