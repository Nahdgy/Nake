using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LensNavigation : MonoBehaviour
{
    private float _horizontalInput, _verticalInput;
    [SerializeField]
    private GameObject _lens;
    [SerializeField]
    private string _letter;
    [SerializeField]
    private float _multiplySpeed, _lensHeight, _distRange;
    [SerializeField]
    private LayerMask _layerMask;

    [SerializeField]
    private bool _great, wrong;
    [SerializeField]
    private char[] _goodLetters = {'E','S','C','A','P'};
    [SerializeField]
    private char[] _wrongLetters = {'Z','R','T','Y','U','I','O','Q','D','F','G','H','J','K','L','M','W','X','V','B','N'};
    //tableau bonne lettre, tableau mauvaise letttre. Si la lettre selectionné est n'est pas la bonne revois bool et vise versa.


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

    private void Detection()
    {
        RaycastHit _hit;
        if (Physics.Raycast(transform.position, Vector3.down , out _hit, _distRange, _layerMask))
        {
            /*
            _letter = _hit.collider.gameObject;
            if (_hit.transform.CompareTag("A") && Input.GetButtonDown("Action"))
            {
                Debug.Log("Letter A on it");
            }
            if (_hit.transform.CompareTag("B") && Input.GetButtonDown("Action"))
            {
                Debug.Log("Letter B on it");
            }
            if (_hit.transform.CompareTag("C") && Input.GetButtonDown("Action"))
            {
                Debug.Log("Letter C on it");
            }
            if (_hit.transform.CompareTag("D") && Input.GetButtonDown("Action"))
            {
                Debug.Log("Letter D on it");
            }
            if (_hit.transform.CompareTag("E") && Input.GetButtonDown("Action"))
            {
                Debug.Log("Letter E on it");
            }
            */


            _letter = _hit.collider.gameObject.tag;
            switch (_letter)
            {
                case "A":
                    Debug.Log("Letter A on it");
                    break;
                case "B":
                    Debug.Log("Letter B on it");
                    break;
                case "C":
                    Debug.Log("Letter C on it");
                    break;
                case "D":
                    Debug.Log("Letter D on it");
                    break;
                case "E":
                    Debug.Log("Letter E on it");
                    break;
            }
            
        }
    }


}
