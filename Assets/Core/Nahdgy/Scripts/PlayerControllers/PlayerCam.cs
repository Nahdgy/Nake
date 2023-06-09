using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    [SerializeField]
    private float _mouseSensibilityX, _mouseSensibilityY;
    private float _cameraRotationX, _cameraRotationY;
    [SerializeField]
    private Transform _oriantationCam;
    public bool _canSee = true;


    private void Update()
    {
        GetMouseInput();
    }
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void GetMouseInput()
    {
        if (_canSee == true)
        {
            float _mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * _mouseSensibilityX;
            float _mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * _mouseSensibilityY;
            _cameraRotationY += _mouseX;
            _cameraRotationX -= _mouseY;
            _cameraRotationX = Mathf.Clamp(_cameraRotationX, -90f, 90f);

            transform.rotation = Quaternion.Euler(_cameraRotationX, _cameraRotationY, 0);
            _oriantationCam.rotation = Quaternion.Euler(0, _cameraRotationY, 0);
        }
    }
}
