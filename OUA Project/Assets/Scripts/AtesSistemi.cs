using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtesSistemi : MonoBehaviour
{
    Camera kamera;
    public LayerMask canavarKatman; //1. Iþýnýn bütün katmanlarla etkileþime geçmesini istemediðimiz için, canavar adýnda bir katman oluþturduk.

    public ParticleSystem muzzleEffect; //6. Silahtan çýkan muzzle efektin olduðu component.
    public ParticleSystem bloodEffect; //12. Canavardan çýkacak kan efekti.
    public ParticleSystem wallEffect; //21. Duvardan çýkacak mermi efekti.
    float sonTiklama; //8. mouseye týkladýðýmýz zamaný tutan deðiþken.
    float tiklamaBeklemeSuresi = 0.65f; //9. mouseye tekrar týklamamýz için geçmesi gereken süre.
    float atesSiniri = 6f;//30. Ateþ etme miktarýný sýnýrlayan deðiþken.
    public GameObject bloodObje;  //13. Kan efektini çýkaracak prefabýmýz.
    Vector3 mermiKonum; //14. raycast ýþýnýnýn canavara çarptýðý pozisyonu tutacak deðiþken
    Quaternion hitRotation; //15. raycast ýþýnýnýn canavara çarptýðý açýyý tutacak deðiþken
    public GameObject wallObje; //22. Duvar tagýna sahip nesnelere vurduðumuzda çýkaracak prefabýmýz
    Vector3 wallKonum; //23. raycast ýþýnýnýn canavara çarptýðý pozisyonu tutacak deðiþken.
    Quaternion wallRotation; //24. raycast açýsýnýn duvar tagýna sahip nesnelere çarptýðý açý    


    void Start()
    {
        kamera = Camera.main;

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)&&atesSiniri>0) //2. Bu kýsýmda mouseye týkladýðýmýzda ekranda çýkacak particle effectleri kontrol edeceðiz.
        {
            if (Time.time - sonTiklama > tiklamaBeklemeSuresi)
            {
                AtesEt(); //4. Burada ateþ etme iþlemimiz gerçekleþiyor.
                StartCoroutine(muzzleBekleme());//11. Burada muzzle effect çalýþýyor.
                atesSiniri--;         
                sonTiklama = Time.time; //10. Son týklama zamaný ile ilgili deðiþkeni güncelliyoruz.
            }
        }

    }

    void AtesEt() //3. Ateþ etme iþlemimiz ve ateþ ettiðimizde çýkacak particle sistemler bu fonksiyonda olacak.
    {
        Ray ray = kamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, canavarKatman))
        {
            if (hit.collider != null)
            {
                if (hit.collider.name == "Enemy") //16. Eðer ýþýnýn çarptýðý nesne, canavarsa, bu koþulun içindeki kod dizisi çalýþacak.
                {
                    hit.collider.gameObject.GetComponent<CanavarController>().HasarAl(); //17. Burada canavarýmýz hasar alacak.
                    mermiKonum = hit.point; //18. ýþýnýn konumunu ilgili deðiþkene atadýk.
                    hitRotation = Quaternion.LookRotation(hit.normal);//19. ýþýnýn rotasyonunu ilgili deðiþkene atadýk.
                    Instantiate(bloodObje, mermiKonum, hitRotation); //20. burada kan efekti instance ettik.
                }

                if (hit.collider.gameObject.CompareTag("duvar")) //25. Eðer ýþýnýn çarptýðu nesne duvar tagýna sahipse bu koþulun içindeki olaylar gerçekleþecek.
                {
                    wallKonum = hit.point; //26. ýþýnýn konumunu ilgili deðiþkene atadýk.
                    wallRotation = Quaternion.LookRotation(hit.normal);//27. ýþýnýn rotasyonunu ilgili deðiþkene atadýk.
                    if (wallObje != null)
                    {
                        Destroy(wallObje); //28. Önce, daha önce bir obje varsa onu yok ettik ki nullreferance hatasý almayalým diye.
                    }
                    wallObje =Instantiate(wallObje, wallKonum, wallRotation); //29. Ardýndan da yeni bir obje ürettik.                    

                }

            }

        }

    }

    IEnumerator muzzleBekleme() //7. Muzzle efektin gecikme süresini ayarlayan coroutine. Bunu kullanmamýzýn sebeni, alevin çýkýþ zamaný ile, ateþ etme animasyonun ilgili zamanýnýn senkronize olmasýný saðlamak.
    {
        yield return new WaitForSecondsRealtime(0.2f);
        muzzleEffect.Play();
    }
}
