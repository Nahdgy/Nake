using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;


public class GlobeNav : MonoBehaviour
{


    private float _horizontalInput, _verticalInput,_inclineAngleX = -65f, _inclineAngleY = 0f;
    public bool _italyHere = false;
    public bool _canManip = false;

    [SerializeField]
    private CinemachineVirtualCamera _cameraPlayer, _cameraGlobe;
    [SerializeField]
    private Transform _obj,_globe, _ping;
    [SerializeField]
    private float _multiplySpeed, _multiplySpeedRot, _pingHeight, _distRange, _min, _max;
    [SerializeField]
    private LayerMask _countryLayer;
    [SerializeField]
    private AudioSource _audioSource;
    [SerializeField]
    private AudioClip _validSfx;
    [SerializeField]
    private PlayerController _player;
    [SerializeField]
    private PlayerCam _playerCam;
    [SerializeField]
    private Transform _camera, _place;

    private void Start()
    {
        //_cameraGlobe = GetComponent<CinemachineVirtualCamera>();
    }
    void Update()
    {
        ControllerInputs();
        Turn();
        PingNav();   
        CamInPlace();

    }

    private void ControllerInputs()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Mouse Y");
    }
    public void Open()
    { 
        _ping.gameObject.SetActive(true);
        _cameraPlayer.Priority = 0;
        _cameraGlobe.Priority = 10;
        _canManip = true; 
        _player._canMove = false;
        _playerCam._canSee = false;
        Detection();
    }
    public void Back()
    {
        _cameraPlayer.Priority = 10;
        _cameraGlobe.Priority = 0;
        _canManip = false;
        _player._canMove = true;
        _playerCam._canSee = true;  
        _ping.gameObject.SetActive(false);
    }
    private void CamInPlace()
    {
        _camera.position = _place.position;
        _camera.rotation = _place.rotation;

    }

    private void Turn()
    {

        if (_canManip)
        {
            _globe.rotation = Quaternion.Euler(_inclineAngleX,_inclineAngleY, _horizontalInput * _multiplySpeedRot + _obj.rotation.eulerAngles.z);
        }
    }

    private void PingNav()
    {
        if(_canManip)
        {
            _ping.transform.position = new Vector3(_obj.transform.position.x,_verticalInput * _multiplySpeed + Mathf.Clamp(_ping.transform.position.y,_min,_max), _obj.transform.position.z + _pingHeight);
        }
    }

    private void Detection()
    {
        if (_canManip == true)
        {
            RaycastHit _hit;
            if (Physics.Raycast(_ping.transform.position, Vector3.forward * -1, out _hit, _distRange, _countryLayer))
            {
                _italyHere = true;
                if (Input.GetButtonDown("Action") && _italyHere == true)
                {
                    StartCoroutine(Validation());
                }
            }
            else
            {
                _italyHere = false;
            }
        }
    } 
    private IEnumerator Validation()
    {
        float timer = 0.3f;
        _audioSource.PlayOneShot(_validSfx);
        yield return new WaitForSeconds(timer);
        Back();
    }
   
}
