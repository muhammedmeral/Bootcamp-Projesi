using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelEkrani : MonoBehaviour
{
   
    public void level1()
    {
        SceneManager.LoadScene("Level_2(Bilal)");
       
    }

    

    public void level3()
    {
        SceneManager.LoadScene("Level_3(Bilal)");
    }

    public void geriDon()
    {
        SceneManager.LoadScene("menu");
    }
}
