using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CanavarController : MonoBehaviour
{
    public Animator anim;  //1. Canavarýn animasyonlarýný kontrol edecek component.
    public GameObject hedef; //2. Canavarýn hedefi olacak. (Oyuncu)
    NavMeshAgent nmesh; //4. Canavardaki navmesh agent compenentini tutacak deðiþken.
    public float mesafe; //5. Canavar ve karaktermiz arasýndaki mesafeyi ölçecek deðiþken. (Bu mesafeye göre ilgili animasyon ve olaylarýn çalýþmasý kontrol edilecek.)

    public float canavarHp = 100;
    float deger = 0;
    public GameObject karakter;
    BoxCollider canavarCollider;

    private AudioSource audioSource; //sesin kaynaðýný belirlemek için bileþen oluþturuldu.
    public AudioClip olme; //canavar öldüðünde kullanýlacak ses için audioclip bileþeni oluþturuldu.
    public AudioClip attack1; //canavar karaktere saldýrdýðýnda kullanýlacak ses için audioclip bileþeni oluþturuldu.
    public AudioClip attack2; //canavar karaktere saldýrdýðýnda kullanýlacak ses için audioclip bileþeni oluþturuldu.
    public AudioClip yaralanma; //canavar hasar aldýðýnda kullanýlacak ses için audioclip bileþeni oluþturuldu.

    private void Start()
    {

        nmesh = GetComponent<NavMeshAgent>(); //6. Navmesh componentimizi cache ettik.
        canavarCollider = GetComponent<BoxCollider>();
        audioSource = GetComponent<AudioSource>(); //audiosource componentini cache ettik.
    }

    private void Update()
    {


        if (canavarHp <= 0)
        {
            this.canavarCollider.isTrigger=true;

            deger++;
            if (deger == 1)
            {
                anim.SetTrigger("death");
                nmesh.isStopped = true;
                audioSource.PlayOneShot(olme); //canavar öldüðünde çýkacak sesin oynatýlmasý saðlandý.

            }

        }

        else
        {


            mesafe = Vector3.Distance(hedef.transform.position, transform.position); //10. Bu kýsým, canavarla karakterin arasýndaki mesafeyi ölçecek.

            nmesh.destination = hedef.transform.position;  //7. Bu kod satýrý sayesinde, canavar haritada karakterimizi takip edecek.

            if (mesafe < 9 && mesafe > 2.5f) //11. Bu kýsýmda canavar, karaktere doðru koþacak.
            {
                //Bu kýsýmda koþma ses efekti kullanýlacak.
                walkToRun();
                nmesh.speed = 2.8f;
                anim.SetBool("isAttack1", false);
                anim.SetBool("isAttack2", false);


            }
            if (mesafe >= 9) //13. Bu kýsýmda canavar karaktere doðru yürüyecek.
            {
                //Bu kýsýmda yürüme ses efekti kullanýlacak.
                runToWalk();
                nmesh.speed = 1f;
                anim.SetBool("isAttack1", false);
                anim.SetBool("isAttack2", false);


            }

            if (mesafe <= 2.5f) //14. Bu kýsýmda canavarýn saldýrý animasyonlarý çalýþýyor.
            {
                //Bu kýsýmda saldýrý ses efekti kullanýlacak.
                anim.SetBool("isWalk", false);
                anim.SetBool("isRun", false);
                anim.SetBool("isAttack1", true);
                anim.SetBool("isAttack2", true);
                //HasarVer();
                StartCoroutine(IddleBekleme());
            }
        }
    }

    public void HasarAl()
    {
        canavarHp -= Random.Range(20, 30);
        audioSource.PlayOneShot(yaralanma); //karakter canavara hasar verdiðinde çýkacak olan sesin oynatýlmasý saðlandý.
    }

    public void HasarVer()
    {
        if (karakter != null)
        {
            karakter.GetComponent<KarakterAnimasyonController>().HasarAl();
            audioSource.PlayOneShot(attack1); //canavar karaktere hasar verdiðinde çýkacak olan sesin oynatýlmasý saðlandý.
        }


    }
    public void hasarVerLight()
    {
        if (karakter != null)
        {
            karakter.GetComponent<KarakterAnimasyonController>().hasarALLight();
            audioSource.PlayOneShot(attack2); //canavar karaktere hasar verdiðinde çýkacak olan sesin oynatýlmasý saðlandý.
        }
    }

    void walkToRun() //8. Bu fonksiyonda, canavar yürürken, koþma durumuna geçecek.
    {
        anim.SetBool("isWalk", false);
        anim.SetTrigger("walkToIddle");
        //Bu kýsýmda canavarýn kükreme ses efekti kullanýlacak.
        StartCoroutine(IddleBekleme());
        anim.SetBool("isRun", true);

    }

    void runToWalk() //9. Bu fonksiyonda canavar koþarken, yürüme durumuna geçecek.
    {
        anim.SetBool("isRun", false);
        anim.SetBool("isWalk", true);

    }


    IEnumerator IddleBekleme() // 12 .walk animden iddle anime geçtiði sýrada canavarýn yerinde beklemesi için bu yapýyý kullandýk.
    {
        nmesh.stoppingDistance = 50f;
        yield return new WaitForSecondsRealtime(2f);
        nmesh.stoppingDistance = 2.5f;

    }

}