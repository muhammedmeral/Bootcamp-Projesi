using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtesSistemi : MonoBehaviour
{
    Camera kamera;
    public LayerMask canavarKatman; //1. I��n�n b�t�n katmanlarla etkile�ime ge�mesini istemedi�imiz i�in, canavar ad�nda bir katman olu�turduk.

    public ParticleSystem muzzleEffect; //6. Silahtan ��kan muzzle efektin oldu�u component.
    public ParticleSystem bloodEffect; //12. Canavardan ��kacak kan efekti.
    public ParticleSystem wallEffect; //21. Duvardan ��kacak mermi efekti.
    float sonTiklama; //8. mouseye t�klad���m�z zaman� tutan de�i�ken.
    float tiklamaBeklemeSuresi = 0.65f; //9. mouseye tekrar t�klamam�z i�in ge�mesi gereken s�re.
    float atesSiniri = 6f;//30. Ate� etme miktar�n� s�n�rlayan de�i�ken.
    public GameObject bloodObje;  //13. Kan efektini ��karacak prefab�m�z.
    Vector3 mermiKonum; //14. raycast ���n�n�n canavara �arpt��� pozisyonu tutacak de�i�ken
    Quaternion hitRotation; //15. raycast ���n�n�n canavara �arpt��� a��y� tutacak de�i�ken
    public GameObject wallObje; //22. Duvar tag�na sahip nesnelere vurdu�umuzda ��karacak prefab�m�z
    Vector3 wallKonum; //23. raycast ���n�n�n canavara �arpt��� pozisyonu tutacak de�i�ken.
    Quaternion wallRotation; //24. raycast a��s�n�n duvar tag�na sahip nesnelere �arpt��� a��    


    void Start()
    {
        kamera = Camera.main;

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)&&atesSiniri>0) //2. Bu k�s�mda mouseye t�klad���m�zda ekranda ��kacak particle effectleri kontrol edece�iz.
        {
            if (Time.time - sonTiklama > tiklamaBeklemeSuresi)
            {
                AtesEt(); //4. Burada ate� etme i�lemimiz ger�ekle�iyor.
                StartCoroutine(muzzleBekleme());//11. Burada muzzle effect �al���yor.
                atesSiniri--;         
                sonTiklama = Time.time; //10. Son t�klama zaman� ile ilgili de�i�keni g�ncelliyoruz.
            }
        }

    }

    void AtesEt() //3. Ate� etme i�lemimiz ve ate� etti�imizde ��kacak particle sistemler bu fonksiyonda olacak.
    {
        Ray ray = kamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, canavarKatman))
        {
            if (hit.collider != null)
            {
                if (hit.collider.name == "Enemy") //16. E�er ���n�n �arpt��� nesne, canavarsa, bu ko�ulun i�indeki kod dizisi �al��acak.
                {
                    hit.collider.gameObject.GetComponent<CanavarController>().HasarAl(); //17. Burada canavar�m�z hasar alacak.
                    mermiKonum = hit.point; //18. ���n�n konumunu ilgili de�i�kene atad�k.
                    hitRotation = Quaternion.LookRotation(hit.normal);//19. ���n�n rotasyonunu ilgili de�i�kene atad�k.
                    Instantiate(bloodObje, mermiKonum, hitRotation); //20. burada kan efekti instance ettik.
                }

                if (hit.collider.gameObject.CompareTag("duvar")) //25. E�er ���n�n �arpt��u nesne duvar tag�na sahipse bu ko�ulun i�indeki olaylar ger�ekle�ecek.
                {
                    wallKonum = hit.point; //26. ���n�n konumunu ilgili de�i�kene atad�k.
                    wallRotation = Quaternion.LookRotation(hit.normal);//27. ���n�n rotasyonunu ilgili de�i�kene atad�k.
                    if (wallObje != null)
                    {
                        Destroy(wallObje); //28. �nce, daha �nce bir obje varsa onu yok ettik ki nullreferance hatas� almayal�m diye.
                    }
                    wallObje =Instantiate(wallObje, wallKonum, wallRotation); //29. Ard�ndan da yeni bir obje �rettik.                    

                }

            }

        }

    }

    IEnumerator muzzleBekleme() //7. Muzzle efektin gecikme s�resini ayarlayan coroutine. Bunu kullanmam�z�n sebeni, alevin ��k�� zaman� ile, ate� etme animasyonun ilgili zaman�n�n senkronize olmas�n� sa�lamak.
    {
        yield return new WaitForSecondsRealtime(0.2f);
        muzzleEffect.Play();
    }
}
