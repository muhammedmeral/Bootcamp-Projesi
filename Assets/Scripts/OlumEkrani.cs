using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OlumEkrani : MonoBehaviour
{
    public static void Olum()
    {
        Cursor.lockState = CursorLockMode.Confined;
        SceneManager.LoadScene("olum");
    }
    public void GeriDon()
    {
        SceneManager.LoadScene("menu");
    }

}
