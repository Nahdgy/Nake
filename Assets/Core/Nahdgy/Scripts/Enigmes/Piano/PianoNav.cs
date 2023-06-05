using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class PianoNav : MonoBehaviour
{
    private float _horizontalInput;
    public bool _canManip = false;
    private bool key1,key2,key3,key4;

    [SerializeField]
    private CinemachineVirtualCamera _cameraPlayer, _cameraPiano;
    [SerializeField]
    private PlayerCam _playerCam;
    [SerializeField]
    private AudioSource _audioSource;
    [SerializeField]
    private AudioClip _validSfx;
    [SerializeField]
    private PlayerController _player;
    [SerializeField]
    private Transform _camera, _place;
    [SerializeField]
    private Transform _obj, _finger, _down, _up;
    [SerializeField]
    private float _multiplySpeed, _min, _max,_timer;

    static float t = 0.0f;

    private void Update()
    {
        ControllerInputs();
        CamInPlace();
        FingerNav();
    }
    private void ControllerInputs()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
    }
    private void CamInPlace()
    {
        _camera.position = _place.position;
        _camera.rotation = _place.rotation;
    }
    public void Open()
    {
        _finger.gameObject.SetActive(true);
        _cameraPlayer.Priority = 0;
        _cameraPiano.Priority = 10;
        _canManip = true;
        _player._canMove = false;
        _playerCam._canSee = false;
        //Detection();
    }
    public void Back()
    {
        _finger.gameObject.SetActive(false);
        _cameraPlayer.Priority = 10;
        _cameraPiano.Priority = 0;
        _canManip = false;
        _player._canMove = true;
        _playerCam._canSee = true;
    }
    private void FingerNav()
    {
        if (_canManip)
        {
            _finger.transform.position = new Vector3(_horizontalInput * _multiplySpeed + Mathf.Clamp(_finger.transform.position.x, _min, _max),_obj.transform.position.y, _obj.transform.position.z);
        }
        if(_canManip && Input.GetButton("Action"))
        {
            StartCoroutine(Down());
        }
        if(_canManip && Input.GetButtonUp("Action"))
        {
            StartCoroutine(Down());
        }
        if(key4 == true) 
        {
            StartCoroutine(Melody());
        }
    }
    private IEnumerator Down()
    {
        _finger.transform.position = new Vector3(_finger.position.x,_down.position.y,_finger.position.z);
        yield return null;
    }
    private IEnumerator Up()
    {
        _finger.transform.position = new Vector3(_finger.position.x, _up.position.y, _finger.position.z); 
        yield return null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 17)
        {
            key1 = true;
        }
        else
        {
            key1 = false;
        }
        if (other.gameObject.layer == 18 && key1 == true)
        {
            key2 = true;
        }
        else
        {
            key2 = false;
        }
        if (other.gameObject.layer == 19 && key2 == true)
        {
            key3 = true;
        }
        else
        {
            key3 = false;
        }
        if (other.gameObject.layer == 20 && key3 == true)
        {
            key4 = true;
        }
        else
        {
            key4 = false;
        }

    }

    private IEnumerator Melody()
    {
        _canManip = false;
        _audioSource.PlayOneShot(_validSfx);
        yield return new WaitForSeconds(_timer);
        Back();
        
    }
}


