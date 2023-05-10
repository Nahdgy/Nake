using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCam : MonoBehaviour
{
    [SerializeField]
    private float _mouseSensibilityX, _mouseSensibilityY, _distRange;
    private float _cameraRotationX, _cameraRotationY;
    [SerializeField]
    private int _layer;
    [SerializeField]
    private Transform _oriantationCam, _objInView;

    //UI GameObjects
    [SerializeField]
    private GameObject _obj, _actionUI, _lessUI;

    [SerializeField]
    Animator _anim;


    [SerializeField]
    private PlayerMov _player;
    [SerializeField]
    private Rigidbody _rb;

    [SerializeField]
    private LayerMask _layerMask,_layerMaskEnigma;

    public bool _canSee = true;
    public bool _canSave = false;
    private bool _canRay = false;


    private void Update()
    {
        GetMouseInput();
        ObjectTargeted();
        EnigmaTargeted();
        //TurnAnimation();
    }
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == _layer)
        { 
            _canRay = true;
            _actionUI.SetActive(true); 
        }  
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == _layer)
        {
            _canRay = false;
            _actionUI.SetActive(false);
        }

    }
    void GetMouseInput()
    {
        if (_canSee == true)
        {
            float _mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * _mouseSensibilityX;
            float _mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * _mouseSensibilityY;
            _cameraRotationY += _mouseX;
            _cameraRotationX -= _mouseY;
            _cameraRotationX = Mathf.Clamp(_cameraRotationX, -90f, 90f);

            _rb.rotation = Quaternion.Euler(0, _cameraRotationY,0);
            transform.rotation = Quaternion.Euler(_cameraRotationX, _cameraRotationY, 0);
            _oriantationCam.rotation = Quaternion.Euler(0, _cameraRotationY, 0);
        }
    }
    private void TurnAnimation()
    {
        float _playerRotation = Mathf.Abs(_rb.rotation.y);
        _anim.SetFloat("Direction", _playerRotation);
    }
    private void ObjectTargeted()
    {
        RaycastHit _hit;

        if (Physics.Raycast(transform.position, transform.forward, out _hit, _distRange, _layerMask) && _canRay == true)
        {
            _obj = _hit.collider.gameObject;
            if (_obj.TryGetComponent<Iinteractable>(out Iinteractable interactObj))
            {

                if (_hit.transform.CompareTag("Object"))
                {

                    if (Input.GetButtonDown("Action"))
                    {
                        _actionUI.SetActive(false);
                        _lessUI.SetActive(true);
                        _canSee = false;
                        interactObj.Pick();
                        _obj.transform.position = _objInView.transform.position;
                        _player._canMove = false;
                    }
                    if (Input.GetButtonDown("Back"))
                    {
                        _actionUI.SetActive(false);
                        _lessUI.SetActive(false);
                        _canSee = true;
                        _player._canMove = true;
                        interactObj.ReturnBase();
                        interactObj.Back();
                    }
                }
                if (_hit.transform.CompareTag("Default"))
                {
                    Debug.Log("A desactivé");
                    _actionUI.SetActive(false);
                }

                if (_hit.transform.CompareTag("Light"))
                {
                    _actionUI.SetActive(true);

                    if (Input.GetButtonDown("Action"))
                    {
                        interactObj.SwitchLight();
                        _actionUI.SetActive(false);
                    }
                }
                if (_hit.transform.CompareTag("Door"))
                {
                    _actionUI.SetActive(true);

                    if (Input.GetButtonDown("Action"))
                    {
                        interactObj.OpenDoor();
                        _actionUI.SetActive(false);
                    }
                }
               
            }
        }
    }
    private void EnigmaTargeted()
    {
        RaycastHit _hit;

        if (Physics.Raycast(transform.position, transform.forward, out _hit, _distRange, _layerMaskEnigma) && _canRay == true)
        {
            _obj = _hit.collider.gameObject;
            if (_obj.TryGetComponent<Icodable>(out Icodable interactObj))
            {
                Debug.Log("hit layer");
                

                if (Input.GetButtonDown("Action"))
                {
                    interactObj.Open();
                    _actionUI.SetActive(false);
                }
            }
        }
        
    }
}

    
