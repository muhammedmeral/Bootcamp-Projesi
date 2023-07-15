using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelEkrani : MonoBehaviour
{
   
    public void level1()
    {
        SceneManager.LoadScene("Level 1");
       
    }

    public void level2()
    {
        //SceneManager.LoadScene();
    }

    public void level3()
    {
        //SceneManager.LoadScene();
    }

    public void geriDon()
    {
        SceneManager.LoadScene("menu");
    }
}
