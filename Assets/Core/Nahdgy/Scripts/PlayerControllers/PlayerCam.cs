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
    private GameObject _obj, _actionUI, _lessUI;
    [SerializeField]
    private Rigidbody _rb;
    [SerializeField]
    private LayerMask _layerMask, _layerMaskEnigma;

    [SerializeField]
    private Animator _anim;
    [SerializeField]
    private AudioSource _audioSource;
    [SerializeField]
    private AudioClip _sfxLock, _sfxZip;

    [SerializeField]
    private ItemBehavior _pickUp = new ItemBehavior();
    [SerializeField]
    private PlayerMov _player;
    [SerializeField]
    private GameObject _letterMail;
    [SerializeField]
    private GameManager _gameManager;


    public bool _canSee = true;
    public bool _canOpen = false;
    public bool _canRay = false;


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
    //Activation of the raycast in the box trigger
    {
        if (other.gameObject.layer == _layer)
        {
            _canRay = true;
            _actionUI.SetActive(true);
        }
        else
        {
            _actionUI.SetActive(false);
        }
    }
    //Desactivation of the raycast out of the box trigger
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == _layer)
        {
            _canRay = false;
            _actionUI.SetActive(false);
        }

    }
    //Convert mous input in controller inputs axis
    void GetMouseInput()
    {
        if (_canSee == true)
        {
            float _mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * _mouseSensibilityX;
            float _mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * _mouseSensibilityY;
            _cameraRotationY += _mouseX;
            _cameraRotationX -= _mouseY;
            _cameraRotationX = Mathf.Clamp(_cameraRotationX, -90f, 90f);

            _rb.rotation = Quaternion.Euler(0, _cameraRotationY, 0);
            transform.rotation = Quaternion.Euler(_cameraRotationX, _cameraRotationY, 0);
            _oriantationCam.rotation = Quaternion.Euler(0, _cameraRotationY, 0);
        }
    }
    //Rotation Y of the Mesh Player with the camera
    private void TurnAnimation()
    {
        float _playerRotation = Mathf.Abs(_rb.rotation.y);
        _anim.SetFloat("Direction", _playerRotation);
    }
    //Raycast innitialization
    private void ObjectTargeted()
    {
        RaycastHit _hit;

        if (Physics.Raycast(transform.position, transform.forward, out _hit, _distRange, _layerMask) && _canRay == true)
        {
            //Pick letters for read
            _letterMail = _hit.collider.gameObject;
            if(_letterMail.TryGetComponent<LetterRead>(out LetterRead _mailCode))
            {
                
                if (_hit.transform.CompareTag("Letter"))
                {


                    if (Input.GetButtonDown("Action"))
                    {
                        _actionUI.SetActive(false);
                        _lessUI.SetActive(true);
                        _canSee = false;
                        _player._canMove = false;
                        _mailCode.Read();
                        _gameManager.Focus();

                    }


                    if (Input.GetButtonDown("Back"))
                    {
                        _actionUI.SetActive(false);
                        _lessUI.SetActive(false);
                        _canSee = true;
                        _player._canMove = true;
                        _mailCode.BackInPlace();
                        _gameManager.UnFocus();
                    }
                }
            }
            else
            {
                _letterMail = null;
            }
            
           
                //Pick up items
                if (_hit.transform.CompareTag("Item"))
                {
                    if (Input.GetButtonDown("Action"))
                    {
                        _audioSource.PlayOneShot(_sfxZip);
                        _pickUp.DoPickUp(_hit.transform.gameObject.GetComponent<Item>());
                    }
                }

                _obj = _hit.collider.gameObject;
                if (_obj.TryGetComponent<Iinteractable>(out Iinteractable interactObj))
                {
                    //Object can be manipulate 360°
                    if (_hit.transform.CompareTag("Object"))
                    {
                        if (Input.GetButtonDown("Action"))
                        {
                            _actionUI.SetActive(false);
                            _lessUI.SetActive(true);
                            _canSee = false;
                            _obj.transform.position = _objInView.transform.position;
                            _player._canMove = false; 
                            interactObj.Pick();
                            _gameManager.Focus();
                        }
                        if (Input.GetButtonDown("Back"))
                        {
                            _actionUI.SetActive(false);
                            _lessUI.SetActive(false);
                            _canSee = true;
                            _player._canMove = true;
                            interactObj.ReturnBase();
                            interactObj.Back();
                            _gameManager.UnFocus();
                        }
                    }
                    //Light switcher action
                    if (_hit.transform.CompareTag("Light"))
                    {

                        if (Input.GetButtonDown("Action"))
                        {
                            interactObj.SwitchLight();
                            _actionUI.SetActive(false);
                        }
                    }
                    //Open the door when the key is selected
                    if (_hit.transform.CompareTag("Door"))
                    {
                        interactObj.CheckList();
                        ObjInteract objInteract = _hit.collider.gameObject.GetComponent<ObjInteract>();

                        if (objInteract._isInHand == true)
                        {
                            _canOpen = true;
                        }
                        if (Input.GetButtonDown("Action") && _canOpen == true)
                        {
                            interactObj.OpenDoor();
                            _actionUI.SetActive(false);
                        }
                        if (Input.GetButtonDown("Action") && _canOpen == false)
                        {
                            _audioSource.PlayOneShot(_sfxLock);
                        }
                    }

                }
            }
        }
        //Open enigma's resolve objects
        private void EnigmaTargeted()
        {
            RaycastHit _hit;

            if (Physics.Raycast(transform.position, transform.forward, out _hit, _distRange, _layerMaskEnigma) && _canRay == true)
            {
                _obj = _hit.collider.gameObject;
                if (_obj.TryGetComponent<Icodable>(out Icodable interactObj))
                {
                    if (Input.GetButtonDown("Action"))
                    {
                        interactObj.Open();
                        _actionUI.SetActive(false);
                    }
                }
            }

        }
    }


    
