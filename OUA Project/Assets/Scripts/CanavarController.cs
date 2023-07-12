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

    public float canavarHp = 100;
    float deger = 0;
    public GameObject karakter;
    BoxCollider canavarCollider;

    private AudioSource audioSource; //sesin kayna��n� belirlemek i�in bile�en olu�turuldu.
    public AudioClip olme; //canavar �ld���nde kullan�lacak ses i�in audioclip bile�eni olu�turuldu.
    public AudioClip attack1; //canavar karaktere sald�rd���nda kullan�lacak ses i�in audioclip bile�eni olu�turuldu.
    public AudioClip attack2; //canavar karaktere sald�rd���nda kullan�lacak ses i�in audioclip bile�eni olu�turuldu.
    public AudioClip yaralanma; //canavar hasar ald���nda kullan�lacak ses i�in audioclip bile�eni olu�turuldu.

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
                audioSource.PlayOneShot(olme); //canavar �ld���nde ��kacak sesin oynat�lmas� sa�land�.

            }

        }

        else
        {


            mesafe = Vector3.Distance(hedef.transform.position, transform.position); //10. Bu k�s�m, canavarla karakterin aras�ndaki mesafeyi �l�ecek.

            nmesh.destination = hedef.transform.position;  //7. Bu kod sat�r� sayesinde, canavar haritada karakterimizi takip edecek.

            if (mesafe < 9 && mesafe > 2.5f) //11. Bu k�s�mda canavar, karaktere do�ru ko�acak.
            {
                //Bu k�s�mda ko�ma ses efekti kullan�lacak.
                walkToRun();
                nmesh.speed = 2.8f;
                anim.SetBool("isAttack1", false);
                anim.SetBool("isAttack2", false);


            }
            if (mesafe >= 9) //13. Bu k�s�mda canavar karaktere do�ru y�r�yecek.
            {
                //Bu k�s�mda y�r�me ses efekti kullan�lacak.
                runToWalk();
                nmesh.speed = 1f;
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
                //HasarVer();
                StartCoroutine(IddleBekleme());
            }
        }
    }

    public void HasarAl()
    {
        canavarHp -= Random.Range(20, 30);
        audioSource.PlayOneShot(yaralanma); //karakter canavara hasar verdi�inde ��kacak olan sesin oynat�lmas� sa�land�.
    }

    public void HasarVer()
    {
        if (karakter != null)
        {
            karakter.GetComponent<KarakterAnimasyonController>().HasarAl();
            audioSource.PlayOneShot(attack1); //canavar karaktere hasar verdi�inde ��kacak olan sesin oynat�lmas� sa�land�.
        }


    }
    public void hasarVerLight()
    {
        if (karakter != null)
        {
            karakter.GetComponent<KarakterAnimasyonController>().hasarALLight();
            audioSource.PlayOneShot(attack2); //canavar karaktere hasar verdi�inde ��kacak olan sesin oynat�lmas� sa�land�.
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
        nmesh.stoppingDistance = 2.5f;

    }

}