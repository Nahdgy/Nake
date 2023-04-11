using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    [SerializeField]
    private float _mouseSensibilityX, _mouseSensibilityY, _distRange;
    private float _cameraRotationX, _cameraRotationY;
    [SerializeField]
    private Transform _oriantationCam, _objInView, _basePostion;
    [SerializeField]
    private GameObject _obj, _pickUpUI;
    [SerializeField]
    private PlayerMov _player;

    [SerializeField]
    private LayerMask _layerMask;

    public bool _canSee = true;


    private void Update()
    {
        GetMouseInput();
        ObjectTargeted();
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
    private void ObjectTargeted()
    {
        RaycastHit _hit;
        if (Physics.Raycast(transform.position, transform.forward, out _hit, _distRange, _layerMask))
        {
            if (_hit.transform.CompareTag("Object"))
            {
                _pickUpUI.SetActive(true);
                if (Input.GetButton("Pick"))
                {
                    _canSee = false;
                    _player._canMove = false;
                    _obj.transform.position = _objInView.transform.position;

                }
                if (Input.GetButtonDown("Back"))
                {
                    _canSee = true;
                    _player._canMove = true;
                    _obj.transform.position = _basePostion.transform.position;
                }
            }
            else
            {
                _pickUpUI.SetActive(false);
            }
        }
    }
}

    
