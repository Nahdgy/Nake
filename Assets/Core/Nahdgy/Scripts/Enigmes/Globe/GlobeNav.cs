using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GlobeNav : MonoBehaviour
{


    private float _horizontalInput, _verticalInput;

    public bool _canManip = false;

    [SerializeField]
    private Transform _obj,_globe, _basePosition, _ping;
    [SerializeField]
    private float _multiplySpeed, _pingHeight;

    void Update()
    {
        ControllerInputs();
        Turn();
        PingNav();
    }

    private void ControllerInputs()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Mouse Y");
    }

    private void Turn()
    {

        if (_canManip)
        {
            Debug.Log("IsMoving");
            _globe.rotation = Quaternion.Euler(0f, _horizontalInput * _multiplySpeed + _obj.rotation.eulerAngles.y, 0f);
        }
    }

    private void PingNav()
    {
        if(_canManip )
        {
            _ping.transform.position = new Vector3(_obj.transform.position.x + _pingHeight,_verticalInput * _multiplySpeed + _ping.transform.position.y, _obj.transform.position.z + _pingHeight);
        }
    }

    /*private void Detection()
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
    }*/
    public void ReturnBase()
    {
        _obj.position = _basePosition.position;
        _obj.rotation = Quaternion.Euler(_basePosition.rotation.x, _basePosition.rotation.y, _basePosition.rotation.z);
    }
}
