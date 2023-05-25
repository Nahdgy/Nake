using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobeNav : MonoBehaviour
{


    private float _horizontalInput, _verticalInput;

    public bool _canManip = false;

    [SerializeField]
    private Transform _obj, _basePosition;
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
    public void ReturnBase()
    {
        _obj.position = _basePosition.position;
        _obj.rotation = Quaternion.Euler(_basePosition.rotation.x, _basePosition.rotation.y, _basePosition.rotation.z);
    }
}
