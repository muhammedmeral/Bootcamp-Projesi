using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class camera_controller : MonoBehaviour
{
    public Camera cammm;
    public Transform target;
    public float mouseSpeed;
    float xRot, yRot;
    public float minX, maxX;
    public TextMeshProUGUI fov;
    string skorrr = "FOV: ";
    float fovvar;
    private void Start()
    {
        fovvar = cammm.fieldOfView;
    }
    private void LateUpdate()
    {
        xRot -= Input.GetAxis("Mouse Y")*Time.deltaTime*mouseSpeed;
        yRot += Input.GetAxis("Mouse X")*Time.deltaTime*mouseSpeed;
        xRot = Mathf.Clamp(xRot, minX, maxX);
        transform.GetChild(0).localRotation = Quaternion.Euler(xRot, 0, 0);
        transform.localRotation = Quaternion.Euler(0, yRot, 0);



    }
    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position+new Vector3(0,0.5f,0), target.transform.position, 0.3f);

        

        if (Input.GetKey(KeyCode.L))
        {
            
            cammm.fieldOfView += 1;
            fovvar = cammm.fieldOfView;
            
            
        }
        if (Input.GetKey(KeyCode.K))
        {
            cammm.fieldOfView -= 1;
            fovvar = cammm.fieldOfView;
            
        }

        fov.text = skorrr+fovvar.ToString();
        

    }
}
