using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarakterHareketleri : MonoBehaviour
{
    [SerializeField] float hareketHizi=1.25f; //1.karakterin hýzýný belirleyen bir deðiþken oluþturuldu ve deðer atandý.
    Rigidbody rb; //2.Rigidbody bileþeninden rb adlý deðiþken oluþturuldu.

    private AudioSource audioSource;
    public AudioClip yurume;
   



    private void Start()
    {
        rb = GetComponent<Rigidbody>(); //3.karakterin hareketini Rigidbody bileþeni üzerinden kontrol etmek için rb deðiþkeni kullanýldý. 
        audioSource = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {

        float yatay = Input.GetAxis("Horizontal") * hareketHizi * 100 * Time.deltaTime; //4.yatay giriþlerin alýnmasý ve kontrol edilmesi (yatay yöndeki hareketler)
        float dikey = Input.GetAxis("Vertical") * hareketHizi * 100 * Time.deltaTime; //5.dikey giriþlerin alýnmasý ve kontrol edilmesi (dikey yöndeki hareketler)

        Vector3 hareket = new Vector3(yatay, 0, dikey) * hareketHizi * Time.deltaTime; //6.yatay ve dikey giriþlere göre belirli bir hýzda hareket eden bir 3D vektör hesaplandý
        rb.MovePosition(transform.position + transform.TransformDirection(hareket)); //7.mevcut konum ve hareket vektörü toplanarak yeni konum hesaplandý ve karakterin haraket etmesi saðlandý.

        if (Input.GetKey(KeyCode.LeftShift))
        {
            hareketHizi = 0.65f;
        }
        else
            hareketHizi = 1.25f;

        if (yatay!=0 || dikey != 0)
        {
            audioSource.PlayOneShot(yurume);
           
        }




    }









}
