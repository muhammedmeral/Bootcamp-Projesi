using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AnaMenu : MonoBehaviour
{

    public void Start()
    {
        PauseMenu.oyunDurduMu = false;
    }

    
    public void PlayButton()
    {
        SceneManager.LoadScene("leveller");
        Time.timeScale = 1;
    }

    public void AboutButton()
    {

    }

    public void SettingsButton()
    {
        SceneManager.LoadScene("settings");
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
