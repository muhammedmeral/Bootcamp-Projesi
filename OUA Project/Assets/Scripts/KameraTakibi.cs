using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraTakibi : MonoBehaviour
{
    public float mouseHizi = 100f; //1.mouse hýzý belirlendi ve bir deðiþkene atandý.
    public Transform karakter; //1.1 karakter için transform oluþturuldu.
    float xEkseniDöndürme = 0f; //1.2 x ekseninde döndürmek için deðiþken oluþturuldu.


    void Start()
    {
        karakter = transform.parent; //4.kameranýn karakter hareketiyle dönmesi için ayarlandý.
    }

    // Update is called once per frame
    void Update()
    {
        float MouseX = Input.GetAxis("Mouse X") * mouseHizi * Time.deltaTime; //2.mouse x ekseninde hareketi ayarlandý.
        float MouseY = Input.GetAxis("Mouse Y") * mouseHizi * Time.deltaTime; //3.mouse y ekseninde hareketi ayarlandý.

        karakter.Rotate(Vector3.up, MouseX); //5.karakterin x ekseninde dönmesi ayarlandý.
        xEkseniDöndürme -= MouseY; //6.mouse aþaðý inince görüntünün de aþaðý inmesi ayarlandý.(ayný þekilde yukarý için geçerli)
        xEkseniDöndürme = Mathf.Clamp(xEkseniDöndürme, -75f, 75f); //7.mouse un yukarý ve aþaðý bakma sýnýrý ayarlandý.
        transform.localRotation = Quaternion.Euler(xEkseniDöndürme, 0f, 0f); //8.kamerayý y ekseninde döndürme ayarlandý.
    }
}
