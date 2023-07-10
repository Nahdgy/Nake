using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chess : MonoBehaviour
{
    //[HideInInspector]
    public bool _isInHand = false;
    [SerializeField]
    private int _itemNeed;

    [Header("CodeCaller")]
    [SerializeField]
    private PlayerCam _playerCam;
    [SerializeField]
    private Innventory _itemSelect;
    [SerializeField]
    private GameObject _chessPiece;

    [SerializeField]
    private AudioSource _audioSource;
    [SerializeField]
    private AudioClip _validSfx;
    
    [SerializeField]
    private GameObject _collider;
    [SerializeField]
    private GameObject _keyLivingRoom;

    [SerializeField]
    private Transform _table, _camera, _place, _chessEnd;

    [SerializeField]
    private float _multiplySpeed, _pieceHeight, _distRange;
    [SerializeField]
    private LayerMask _layerMask;

    [SerializeField]
    private CinemachineVirtualCamera _cameraPlayer, _cameraChess;
    [SerializeField]
    private PlayerController _player;
    [SerializeField]
    private bool _canMoving = false;
    [SerializeField]
    private UIAnimation _UIanimation;
    
    private float _horizontalInput, _verticalInput;

    private void Update()
    {
        ControllerInputs();
        Moving();
        CamInPlace();
    }
    private void CamInPlace()
    {
        _camera.position = _place.position;
        _camera.rotation = _place.rotation;
    }
    private void ControllerInputs()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");
    }
    public void Open()
    {
        _cameraPlayer.Priority = 0;
        _cameraChess.Priority = 10;
        _chessPiece.SetActive(true);
        _canMoving = true;
        _collider.SetActive(true);
        _player._canMove = false;
        _player.InInventory = true;
        _playerCam._canSee = false;
        _UIanimation.DoTheAnimation();
    }
    public void Back()
    {
        _playerCam._actionUI.SetActive(false);
        _playerCam._lessUI.SetActive(false);
        _cameraPlayer.Priority = 10;
        _cameraChess.Priority = 0;
        _canMoving = false;
        _collider.SetActive(false);
        _player._canMove = true;
        _player.InInventory = false;
        _playerCam._canSee = true;
        _UIanimation.StopTheAnimation();
    }
   
    private void Moving()
    {
        if (_canMoving == true)
        {
            _chessPiece.transform.position = new Vector3(_horizontalInput * _multiplySpeed + _chessPiece.transform.position.x, _table.transform.position.y + _pieceHeight, _verticalInput * _multiplySpeed + _chessPiece.transform.position.z);
            Detection();
        }
    } 
    private void Detection()
    {
        if (_canMoving == true)
        {
            RaycastHit _hit;
            if (Physics.Raycast(_chessPiece.transform.position, Vector3.down, out _hit, _distRange, _layerMask))
            {
                Debug.Log("EtMat");
                if (Input.GetButtonDown("Action"))
                {
                   _keyLivingRoom.SetActive(true);
                   _chessPiece.transform.position = _chessEnd.position;
                   _audioSource.PlayOneShot(_validSfx);
                   Back();

                }
            }
        }
    }
    public void CheckList()
    {
        if (_itemNeed == 0) return;

        if (_itemSelect._objId == _itemNeed)
        {
            _isInHand = true;
        }
        else if (_itemSelect._objId != _itemNeed)
        {
            _isInHand = false;
        }
    }
}
