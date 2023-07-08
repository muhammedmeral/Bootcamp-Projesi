using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fotoUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            this.gameObject.SetActive(true);
        }
    }
}
