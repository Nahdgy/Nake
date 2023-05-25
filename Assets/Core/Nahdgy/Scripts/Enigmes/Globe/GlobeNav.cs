using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class GlobeNav : MonoBehaviour
{


    private float _horizontalInput, _verticalInput,_inclineAngleX = -65f, _inclineAngleY = 0f;
    public bool _italyHere = false;
    public bool _canManip = false;

    [SerializeField]
    private Camera _cameraPlayer, _cameraGlobe;
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
    private PlayerMov _player;
    [SerializeField]
    private PlayerCam _playerCam;

    private void Start()
    {
        _cameraGlobe = GetComponent<Camera>();
    }
    void Update()
    {
        ControllerInputs();
        Turn();
        PingNav();    
        Detection();
        //Mettre dans open apr�s
    }

    private void ControllerInputs()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Mouse Y");
    }
    public void Open()
    {
        _cameraPlayer.enabled = false;
        _cameraGlobe.enabled = true;
        _canManip = true; 
        _player._canMove = false;
        _playerCam._canSee = false;
        _ping.gameObject.SetActive(true);
    }
    public void Back()
    {
        _cameraPlayer.enabled = true;
        _cameraGlobe.enabled = false;
        _canManip = false;
        _player._canMove = true;
        _playerCam._canSee = true;  
        _ping.gameObject.SetActive(false);
    }

    private void Turn()
    {

        if (_canManip)
        {
            Debug.Log("IsMoving");
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