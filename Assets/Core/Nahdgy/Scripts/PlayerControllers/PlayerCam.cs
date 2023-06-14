using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCam : MonoBehaviour
{
    [Header("YUP")] //Header to organize

    [SerializeField]
    private float _distRange;
    [SerializeField]
    private int _layer;

    [SerializeField]
    private Transform _objInView;
    [SerializeField]
    private GameObject _obj, _actionUI, _lessUI;
    [SerializeField]
    private LayerMask _layerMask, _layerMaskEnigma;

  
    [SerializeField]
    private AudioSource _audioSource;
    [SerializeField]
    private AudioClip _sfxLock, _sfxZip;


    [SerializeField]
    private ItemBehavior _pickUp = new ItemBehavior();
    [SerializeField]
    private PlayerController _player;
    [SerializeField]
    private GameObject _letterMail;
    [SerializeField]
    private GameManager _gameManager;
    [SerializeField]
    private GlobeNav _globeCode;
    [SerializeField]
    private PianoNav _pianoNav;
    [SerializeField]
    private SanityBar _sanityBar;


    public bool _canSee = true;
    public bool _canOpen = false;
    public bool _canRay = false;


    private void Update()
    {
        ObjectTargeted();
        EnigmaTargeted();
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
    
    //Raycast innitialization
    private void ObjectTargeted()
    {
        RaycastHit _hit;

        if (Physics.Raycast(transform.position, transform.forward, out _hit, _distRange, _layerMask) && _canRay == true)
        {
            //Pick up items
            if (_hit.transform.CompareTag("Item"))
            {
                if (Input.GetButtonDown("Action"))
                {
                    _audioSource.PlayOneShot(_sfxZip);
                    _pickUp.DoPickUp(_hit.transform.gameObject.GetComponent<Item>());
                }
            }
            //Interact Globe
            if (_hit.transform.CompareTag("Globe"))
            {
                if (Input.GetButtonDown("Action"))
                {
                    _globeCode.Open();
                }
                if (Input.GetButtonDown("Back")) 
                { 
                    _globeCode.Back();
                }
            }
            //Interact Piano
            if(_hit.transform.CompareTag("Piano"))
            {
                if (Input.GetButtonDown("Action"))
                {
                    _pianoNav.Open();
                }
                if (Input.GetButtonDown("Back"))
                {
                    _pianoNav.Back();
                }

            }

            //Pick item for the sanity bar    
            {
                if (_hit.transform.CompareTag("pills"))
                {
                    _sanityBar.t += 100;
                    // SanityBar.slider.value = 100f;
                    Debug.Log("recovered");
                    //Destroy(pills.gameObject);
                }
            }

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

                //Open the case
                if (_hit.transform.CompareTag("Case"))
                {
                    if (Input.GetButtonDown("Action"))
                    {
                        interactObj.OpenCase();
                        _actionUI.SetActive(false);
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


    
