using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraTakibi : MonoBehaviour
{
    public float mouseHizi = 100f; //1.mouse h�z� belirlendi ve bir de�i�kene atand�.
    public Transform karakter; //1.1 karakter i�in transform olu�turuldu.
    float xEkseniD�nd�rme = 0f; //1.2 x ekseninde d�nd�rmek i�in de�i�ken olu�turuldu.


    void Start()
    {
        karakter = transform.parent; //4.kameran�n karakter hareketiyle d�nmesi i�in ayarland�.
    }

    // Update is called once per frame
    void Update()
    {
        float MouseX = Input.GetAxis("Mouse X") * mouseHizi * Time.deltaTime; //2.mouse x ekseninde hareketi ayarland�.
        float MouseY = Input.GetAxis("Mouse Y") * mouseHizi * Time.deltaTime; //3.mouse y ekseninde hareketi ayarland�.

        karakter.Rotate(Vector3.up, MouseX); //5.karakterin x ekseninde d�nmesi ayarland�.
        xEkseniD�nd�rme -= MouseY; //6.mouse a�a�� inince g�r�nt�n�n de a�a�� inmesi ayarland�.(ayn� �ekilde yukar� i�in ge�erli)
        xEkseniD�nd�rme = Mathf.Clamp(xEkseniD�nd�rme, -75f, 75f); //7.mouse un yukar� ve a�a�� bakma s�n�r� ayarland�.
        transform.localRotation = Quaternion.Euler(xEkseniD�nd�rme, 0f, 0f); //8.kameray� y ekseninde d�nd�rme ayarland�.
    }
}
