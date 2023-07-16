using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelEkrani : MonoBehaviour
{
   
    public void level1()
    {
        SceneManager.LoadScene(5);
       
    }

    public void level2()
    {
        SceneManager.LoadScene(6);
    }

    public void level3()
    {
        SceneManager.LoadScene(7);
    }

    public void geriDon()
    {
        SceneManager.LoadScene("menu");
    }
}
