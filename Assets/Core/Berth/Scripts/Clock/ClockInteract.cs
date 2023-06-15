using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
using UnityEngine.InputSystem.EnhancedTouch;
using Cinemachine;

public class ClockInteract : MonoBehaviour
{

    [SerializeField]
    private CinemachineVirtualCamera _cameraPlayer, _clockCam;
    [SerializeField]
    private PlayerCam _playerCam;
    [SerializeField]
    private AudioSource _audioSource;
    [SerializeField]
    private AudioClip _validSfx;
    [SerializeField] private PlayerController _player;

    [SerializeField] private Transform _camera, _place;

    [SerializeField] private Transform _clockHand;

    public bool _canManip;


    private void CamInPlace()
    {
        _camera.position = _place.position;
        _camera.rotation = _place.rotation;
    }
    public void Open()
    {
        _clockHand.gameObject.SetActive(true);
        _cameraPlayer.Priority = 0;
        _clockCam.Priority = 10;
        _canManip = true;
        _player._canMove = false;
        _playerCam._canSee = false;
        CamInPlace();
    }
    public void Back()
    {
        _clockHand.gameObject.SetActive(false);
        _cameraPlayer.Priority = 10;
        _clockCam.Priority = 0;
        _canManip = false;
        _player._canMove = true;
        _playerCam._canSee = true;
    }
}
