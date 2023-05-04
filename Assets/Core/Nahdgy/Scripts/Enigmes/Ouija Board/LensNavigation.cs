using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LensNavigation : MonoBehaviour,Icodable
{
    [SerializeField]
    private string _response;

    private float _horizontalInput, _verticalInput;
    [SerializeField]
    private GameObject _lens;

    [SerializeField]
    private float _multiplySpeed, _lensHeight, _distRange;
    [SerializeField]
    private LayerMask _layerMask;

    [SerializeField]
    private Code _code;
    [SerializeField]
    private Words _words;

    private void Update()
    {
        ControllerInputs();
        Moving();
        Detection();
    }
    void ControllerInputs()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");
    }
    private void Moving()
    {
        _lens.transform.position = new Vector3(_horizontalInput * _multiplySpeed + _lens.transform.position.x,_lensHeight,_verticalInput * _multiplySpeed + _lens.transform.position.z);
    }
    public void Code1()
    {
        _words.GetSetCurCode = _response;
    }

    private void Detection()
    {
        
        RaycastHit _hit;
        if (Physics.Raycast(transform.position, Vector3.down , out _hit, _distRange, _layerMask))
        { 
            if(Input.GetButtonDown("Action")) 
            { 
                _code._letter = _hit.collider.gameObject.tag;
                _code.Validation(_code._letter);
            }
        }
    }
}
