using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject arayuz;
    public static bool oyunDurduMu = false;
    public GameObject panel;
    

    private void Start()
    {
        panel.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();

        }
    }

    public void Pause()
    {
        panel.SetActive(true);
        arayuz.SetActive(false);
        Time.timeScale = 0;
        oyunDurduMu = true;
        Cursor.lockState = CursorLockMode.Confined;
    }
    public void Continue()
    {
        panel.SetActive(false);
        arayuz.SetActive(true);
        Time.timeScale = 1;
        oyunDurduMu = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Settings()
    {
        SceneManager.LoadScene("settings");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("menu");
        
    }

    public void Quit()
    {
        Application.Quit();
    }
}
