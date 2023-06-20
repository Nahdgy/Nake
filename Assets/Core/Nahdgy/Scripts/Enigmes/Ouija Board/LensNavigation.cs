using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LensNavigation : MonoBehaviour,Icodable
{
    [SerializeField]
    private string _response;

    private float _horizontalInput, _verticalInput;
    [SerializeField]
    private GameObject _lens,_codeUI,_collider;
   
    [SerializeField]
    private Transform _obj, _camera, _place;

    [SerializeField]
    private float _multiplySpeed, _lensHeight, _distRange;
    [SerializeField]
    private LayerMask _layerMask;

    [SerializeField]
    private CinemachineVirtualCamera _cameraPlayer, _cameraOuija;
    [SerializeField]
    private Code _code;
    [SerializeField]
    private Words _words;
    [SerializeField]
    private PlayerController _player;
    [SerializeField]
    private PlayerCam _playerCam;
    [SerializeField]
    private bool _canMoving = false;

    private void Update()
    {
        ControllerInputs();
        Moving();  
        CamInPlace();
    }
    void ControllerInputs()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");
    }
    private void Moving()
    {
        if(_canMoving == true) 
        {
            _lens.transform.position = new Vector3(_horizontalInput * _multiplySpeed + _lens.transform.position.x, _obj.transform.position.y + _lensHeight, _verticalInput * _multiplySpeed + _lens.transform.position.z);
            Detection();
        }
    }
    public void Code1()
    {
        _words.GetSetCurCode = _response;
    }

    private void Detection()
    {
        if (_canMoving == true)
        {
            RaycastHit _hit;
            if (Physics.Raycast(transform.position, Vector3.down, out _hit, _distRange, _layerMask))
            {
                if (Input.GetButtonDown("Action"))
                {
                    _code._letter = _hit.collider.gameObject.tag;
                    _code.Validation(_code._letter);
                }
                if (_hit.transform.CompareTag("QuitCode") && Input.GetButtonDown("Action"))
                {
                    Back();
                }
            }
        }
    }
    private void CamInPlace()
    {
        _camera.position = _place.position;
        _camera.rotation = _place.rotation;
    }
    public void Open()
    {
        _cameraPlayer.Priority = 0;
        _cameraOuija.Priority = 10;
        _canMoving = true;
        _codeUI.SetActive(true);
        _collider.SetActive(true);
        _player._canMove = false;
        _playerCam._canSee = false;
    }
    public void Back()
    {
        _cameraPlayer.Priority = 10;
        _cameraOuija.Priority = 0;
        _canMoving = false;
        _codeUI.SetActive(false);
        _collider.SetActive(false);
        _player._canMove = true;
        _playerCam._canSee = true;

    }
}
