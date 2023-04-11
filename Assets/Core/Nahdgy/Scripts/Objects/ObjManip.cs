using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjManip : MonoBehaviour
{
    
    private float _horizontalInput, _verticalInput;
    [SerializeField]
    private bool _canManip = false;
    [SerializeField] 
    private Transform _obj;
    [SerializeField]
    private float _multiplySpeed;

    void Update()
    {
        ControllerInputs();
        Arround();
    }

    private void ControllerInputs()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void Arround()
    {

        if (_canManip) 
        {
            Debug.Log("IsMoving");
            _obj.rotation = Quaternion.Euler(_verticalInput * _multiplySpeed + _obj.rotation.eulerAngles.x, _horizontalInput * _multiplySpeed + _obj.rotation.eulerAngles.y, 0f);
        }
    }
}
