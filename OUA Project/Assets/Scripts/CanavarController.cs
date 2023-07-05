using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CanavarController : MonoBehaviour
{
    public Animator anim;  //1. Canavarýn animasyonlarýný kontrol edecek component.
    public GameObject hedef; //2. Canavarýn hedefi olacak. (Oyuncu)
    //[SerializeField] float hareketHizi; //3. Canavarýn hareket hýzýný tutacak deðiþken.
    NavMeshAgent nmesh; //4. Canavardaki navmesh agent compenentini tutacak deðiþken.
    bool isAttack = false;
    
    public float mesafe; //5. Canavar ve karaktermiz arasýndaki mesafeyi ölçecek deðiþken. (Bu mesafeye göre ilgili animasyon ve olaylarýn çalýþmasý kontrol edilecek.)



    private void Start()
    {

        nmesh = GetComponent<NavMeshAgent>(); //6. Navmesh componentimizi cache ettik.
        


    }

    private void Update()
    {
       
        
        mesafe = Vector3.Distance(hedef.transform.position,transform.position); //10. Bu kýsým, canavarla karakterin arasýndaki mesafeyi ölçecek.

        nmesh.destination = hedef.transform.position;  //7. Bu kod satýrý sayesinde, canavar haritada karakterimizi takip edecek.

        
        if (mesafe < 8 && mesafe>2.5f) //11. Bu kýsýmda canavar, karaktere doðru koþacak.
        {
            //Bu kýsýmda koþma ses efekti kullanýlacak.
            walkToRun();
            nmesh.speed = 2.4f;
            

        }
        if (mesafe >= 9 ) //13. Bu kýsýmda canavar karaktere doðru yürüyecek.
        {
            runToWalk();
            nmesh.speed = 1.8f;

        }
        
        

        






    }

    void walkToRun() //8. Bu fonksiyonda, canavar yürürken, koþma durumuna geçecek.
    {
        anim.SetBool("isWalk", false);
        anim.SetTrigger("walkToIddle");
        StartCoroutine(IddleBekleme());
        anim.SetBool("isRun", true);
        
        
        
    }
    void runToWalk() //9. Bu fonksiyonda canavar koþarken, yürüme durumuna geçecek.
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




    IEnumerator IddleBekleme() // 12 .walk animden iddle anime geçtiði sýrada canavarýn yerinde beklemesi için bu yapýyý kullandýk.
    {
        nmesh.stoppingDistance = 50f;
        yield return new WaitForSecondsRealtime(2f);
        nmesh.stoppingDistance = 1.5f;
    }

}
