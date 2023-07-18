using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseScene : MonoBehaviour
{
    public static void Lose()
    {
        SceneManager.LoadScene("loseEkran");
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void geriDon()
    {
        SceneManager.LoadScene("leveller");
    }
}
