using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller : MonoBehaviour
{
    [SerializeField] float _movement_speed;
    float _moveX, _moveZ;
    Rigidbody _rb;
    Vector3 move = Vector3.zero;
    public Transform cam;
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _moveX = Input.GetAxis("Horizontal")*_movement_speed*100*Time.deltaTime;
        _moveZ = Input.GetAxis("Vertical") * _movement_speed *100* Time.deltaTime;

        if (_moveX != 0 || _moveZ != 0)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, cam.transform.rotation, 0.1f);
        }

        move = new Vector3(_moveX, 0, _moveZ)*Time.deltaTime*_movement_speed;
        _rb.MovePosition(transform.position + transform.TransformDirection(move));
    }


}
