using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjManip : MonoBehaviour, Iinteractable
{

    private float _horizontalInput, _verticalInput;

    public bool _canManip = false;
   
    [SerializeField]
    private Transform _obj;
    [SerializeField]
    private float _multiplySpeed;

    Vector3 OGPos;


    private void Start()
    {
        OGPos = gameObject.transform.position;
    }

    private void Update()
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
            _obj.rotation = Quaternion.Euler(_verticalInput * _multiplySpeed + _obj.rotation.eulerAngles.x, _horizontalInput * _multiplySpeed + _obj.rotation.eulerAngles.y, _horizontalInput * _multiplySpeed + _obj.rotation.eulerAngles.z);
        }
    }
    public void ReturnBase()
    {
        _obj.position = OGPos;
    }

    public void Pick()
    {
        _canManip = true;
    }

    public void Back()
    {
        _canManip = false;
        ReturnBase();
    }
    public void SwitchLight()
    {}
    public void OpenDoor()
    {}
    public void CheckList()
    {}    

    public void OpenCase()
    {}

    public void ViewTab()
    { }
}
