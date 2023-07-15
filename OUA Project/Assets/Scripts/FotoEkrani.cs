using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FotoEkrani : MonoBehaviour
{
    public void geriButon()
    {
        SceneManager.LoadScene("menu");
    }

    public void ileriButon()
    {
        SceneManager.LoadScene("leveller");
    }
}
