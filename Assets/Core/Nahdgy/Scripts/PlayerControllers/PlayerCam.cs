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
    [SerializeField]
    private string _sceneName;

    //UI GameObjects
    [SerializeField]
    private GameObject _obj, _actionUI, _lessUI;


    [SerializeField]
    private PlayerMov _player;

    [SerializeField]
    private LayerMask _layerMask;

    public bool _canSee = true;
    private bool _canRay = false;


    private void Update()
    {
        GetMouseInput();
       ObjectTargeted();
        //faire des box trigger pour activer le raycast et éviter le trop plein de calcul et utiliser un traceur pour calibrer le raycast
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

            transform.rotation = Quaternion.Euler(_cameraRotationX, _cameraRotationY, 0);
            _oriantationCam.rotation = Quaternion.Euler(0, _cameraRotationY, 0);
        }
    }
    private void ObjectTargeted()
    {
        RaycastHit _hit;
        if (Physics.Raycast(transform.position, transform.forward, out _hit, _distRange, _layerMask) && _canRay == true)
        {
            if (_hit.transform.CompareTag("OUIJA"))
            {
                Debug.Log("hit layer");
                _actionUI.SetActive(true);
                _sceneName = _hit.collider.gameObject.tag;

                if (Input.GetButtonDown("Action"))
                {
                    SceneManager.LoadScene(_sceneName);
                }
            }

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
}

    
