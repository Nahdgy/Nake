using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class GlobeNav : MonoBehaviour
{


    private float _horizontalInput, _verticalInput;
    public bool _italyHere = false;
    public bool _canManip = false;

    [SerializeField]
    private Transform _obj,_globe, _basePosition, _ping, _objInView;
    [SerializeField]
    private float _multiplySpeed, _multiplySpeedRot, _pingHeight, _distRange,_inclineAngle, _min, _max;
    [SerializeField]
    private LayerMask _italyLayer;
    [SerializeField]
    private AudioSource _audioSource;
    [SerializeField]
    private AudioClip _validSfx;
    [SerializeField]
    private PlayerMov _player;
    [SerializeField]
    private PlayerCam _playerCam;

    void Update()
    {
        ControllerInputs();
        Turn();
        PingNav();
        
        Detection();
        //Mettre dans open après
    }

    private void ControllerInputs()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Mouse Y");
    }
    public void Open()
    {
        _canManip = true;
        _obj.transform.position = _objInView.position;
        _player._canMove = false;
        _playerCam._canSee = false;
        
    }
    public void Back()
    {
        _canManip = false;
        _player._canMove = true;
        _playerCam._canSee = true; 
        ReturnBase();

    }

    private void Turn()
    {

        if (_canManip)
        {
            Debug.Log("IsMoving");
            _globe.rotation = Quaternion.Euler(_inclineAngle, _horizontalInput * _multiplySpeedRot + _obj.rotation.eulerAngles.y, 0f);
        }
    }

    private void PingNav()
    {
        if(_canManip)
        {
            _ping.transform.position = new Vector3(_obj.transform.position.x + _pingHeight,_verticalInput * _multiplySpeed + Mathf.Clamp(_ping.transform.position.y,_min,_max), _obj.transform.position.z + _pingHeight);
        }
    }

    private void Detection()
    {
        if (_canManip == true)
        {
            RaycastHit _hit;
            if (Physics.Raycast(_ping.transform.position, Vector3.forward, out _hit, _distRange, _italyLayer))
            {
                _italyHere = true;
                if (Input.GetButtonDown("Action") && _italyHere == true)
                {
                    StartCoroutine(Validation());
                }
            }
        }
    } 
    public void ReturnBase()
    {
        _obj.position = _basePosition.position;
        _obj.rotation = Quaternion.Euler(_basePosition.rotation.x, _basePosition.rotation.y, _basePosition.rotation.z);
    }
    private IEnumerator Validation()
    {
        float timer = 0.3f;
        _audioSource.PlayOneShot(_validSfx);
        yield return new WaitForSeconds(timer);
        Back();
    }
   
}
