using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class LensNavigation : MonoBehaviour,Icodable
{
    [SerializeField]
    private string _response;

    private float _horizontalInput, _verticalInput;
    [SerializeField]
    private GameObject _lens,_codeUI,_collider;
    [SerializeField]
    private Transform _obj, _basePosition,_objInView;

    [SerializeField]
    private float _multiplySpeed, _lensHeight, _distRange;
    [SerializeField]
    private LayerMask _layerMask;

    [SerializeField]
    private Code _code;
    [SerializeField]
    private Words _words;
    [SerializeField]
    private PlayerMov _player;
    [SerializeField]
    private PlayerCam _playerCam;
    [SerializeField]
    private bool _canMoving = false;

    private void Update()
    {
        ControllerInputs();
        Moving();
        ReturnBase();   
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
    public void Open()
    {
        _canMoving = true;
        _obj.transform.position = _objInView.position;
        _codeUI.SetActive(true);
        _collider.SetActive(true);
        _player._canMove = false;
        _playerCam._canSee = false;
    }
    public void Back()
    {
        _canMoving = false;
        _codeUI.SetActive(false);
        _collider.SetActive(false);
        _player._canMove = true;
        _playerCam._canSee = true;

    }

    public void ReturnBase()
    {
        if (_canMoving == false)
        {
            _obj.position = _basePosition.position;
            _obj.rotation = Quaternion.Euler(_basePosition.rotation.x, _basePosition.rotation.y, _basePosition.rotation.z);
        }
        
    }
}
