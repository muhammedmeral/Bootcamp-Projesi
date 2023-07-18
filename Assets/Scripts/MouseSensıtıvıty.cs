using UnityEngine;
using UnityEngine.UI;

public class MouseSensıtıvıty : MonoBehaviour
{
    public Slider sensitivitySlider;
    private float defaultSensitivity = 100f; // Varsayılan mouse sensivity değeri
    private float currentSensitivity;

    private void Start()
    {
        
        // Pause menü açıldığında slider değerini varsayılan değerle başlat
        sensitivitySlider.value = defaultSensitivity;
        currentSensitivity = defaultSensitivity;
    }
   
    public void OnSensitivityChanged(float newSensitivity)
    {
        // Slider değeri değiştiğinde bu fonksiyon çağrılacak
        currentSensitivity = newSensitivity;
        PlayerPrefs.SetFloat("MouseSensitivity", currentSensitivity);
    }


}

