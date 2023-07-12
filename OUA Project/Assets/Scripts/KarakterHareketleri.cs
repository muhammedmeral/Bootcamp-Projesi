using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarakterHareketleri : MonoBehaviour
{
    [SerializeField] float hareketHizi=1.25f; //1.karakterin h�z�n� belirleyen bir de�i�ken olu�turuldu ve de�er atand�.
    Rigidbody rb; //2.Rigidbody bile�eninden rb adl� de�i�ken olu�turuldu.

    private AudioSource audioSource;
    public AudioClip yurume;
   



    private void Start()
    {
        rb = GetComponent<Rigidbody>(); //3.karakterin hareketini Rigidbody bile�eni �zerinden kontrol etmek i�in rb de�i�keni kullan�ld�. 
        audioSource = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {

        float yatay = Input.GetAxis("Horizontal") * hareketHizi * 100 * Time.deltaTime; //4.yatay giri�lerin al�nmas� ve kontrol edilmesi (yatay y�ndeki hareketler)
        float dikey = Input.GetAxis("Vertical") * hareketHizi * 100 * Time.deltaTime; //5.dikey giri�lerin al�nmas� ve kontrol edilmesi (dikey y�ndeki hareketler)

        Vector3 hareket = new Vector3(yatay, 0, dikey) * hareketHizi * Time.deltaTime; //6.yatay ve dikey giri�lere g�re belirli bir h�zda hareket eden bir 3D vekt�r hesapland�
        rb.MovePosition(transform.position + transform.TransformDirection(hareket)); //7.mevcut konum ve hareket vekt�r� toplanarak yeni konum hesapland� ve karakterin haraket etmesi sa�land�.

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
