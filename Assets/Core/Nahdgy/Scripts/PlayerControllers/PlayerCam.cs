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
    private GameObject _obj,_pills, _grabUI;

    public GameObject _actionUI, _lessUI;
    [SerializeField]
    private LayerMask _layerMask, _layerMaskEnigma;

  
    [SerializeField]
    private AudioSource _audioSource,_radio,_gramophone;
    [SerializeField]
    private AudioClip _sfxLock, _sfxZip, _clockDeclineSfx, _chessDeclineSfx, _pillSfx;


    [SerializeField]
    private ItemBehavior _pickUp = new ItemBehavior();
    [SerializeField]
    private PlayerController _player;
    [SerializeField]
    private GameObject _letterMail,_objGrable, _sanityUI, _tutoSanity;
    [SerializeField]
    private GameManager _gameManager;
    [SerializeField]
    private GlobeNav _globeCode;
    [SerializeField]
    private PianoNav _pianoNav;
    [SerializeField] 
    private Chess _chess;
    [SerializeField]
    private SanityBar _sanityBar;
    [SerializeField]
    private ClockInteract _clockInteract;
    [SerializeField] 
    private LensNavigation _lens;
    [SerializeField]
    private Radio _radioCode;
    [SerializeField]
    private GameObject _paint;

    public bool _sanityIsActive;
    public bool _canSee = true;
    public bool _canOpen = false;
    public bool _canRay = false;
    public bool _canInteract = false;
    private bool _uiOn = false;

    private void Update()
    {
        ObjectTargeted();
        OuiijaTarget();
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
            _uiOn = true;
        }
    }
    //Desactivation of the raycast out of the box trigger
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == _layer)
        {
            _canRay = false;
            _uiOn = false;
        }
    }
    
    //Raycast innitialization
    private void ObjectTargeted()
    {
        RaycastHit _hit;
        
        if (Physics.Raycast(transform.position, transform.forward, out _hit, _distRange, _layerMask)&& _canRay == true)
        {
            //Pick up items
            if (_hit.transform.CompareTag("Item"))
            {
                if(_uiOn == true)
                {
                    _actionUI.SetActive(true);
                }
      
                if (Input.GetButtonDown("Action"))
                {
                    _uiOn = false;
                    _audioSource.PlayOneShot(_sfxZip);
                    _pickUp.DoPickUp(_hit.transform.gameObject.GetComponent<Item>());
                }
            }

            else
            {
                if (_uiOn == false)
                {
                    _actionUI.SetActive(false);
                }
            }

            //Interact Painting
            _paint = _hit.collider.gameObject;
            if (_paint.TryGetComponent<ArtInspect>(out ArtInspect _painting))
            {
                if (_uiOn == true)
                {
                    _actionUI.SetActive(true);
                }
       
                if (Input.GetButtonDown("Action"))
                {
                    _uiOn = false;
                    _painting.Open();
                }
                if (Input.GetButton("Back"))
                {
                    _uiOn = true;
                    _painting.Back();
                }
            }

            else
            {
                if (_uiOn == false)
                {
                    _actionUI.SetActive(false);
                }
            }
            //Interact Globe
            if (_hit.transform.CompareTag("Globe"))
            {
                if (_uiOn == true)
                {
                    _actionUI.SetActive(true);
                }

                if (Input.GetButtonDown("Action"))
                {
                    _uiOn = false;
                    _globeCode.Open();
                }
                if (Input.GetButtonDown("Back"))
                {
                    _uiOn = true;
                    _globeCode.Back();
                }
            }

            else
            {
                if (_uiOn == false)
                {
                    _actionUI.SetActive(false);
                }
            }
            //Interact Piano
            if (_hit.transform.CompareTag("Piano"))
            {
                if (_uiOn == true)
                {
                    _actionUI.SetActive(true);
                }
                if (Input.GetButtonDown("Action"))
                {
                    _uiOn = false;
                    _pianoNav.Open();
                }
                if (Input.GetButtonDown("Back"))
                {
                    _uiOn = true;
                    _pianoNav.Back();
                }
            }

            else
            {
                if (_uiOn == false)
                {
                    _actionUI.SetActive(false);
                }
            }

            //Interact ChessPiece
            if(_hit.transform.CompareTag("Mat"))
            {
                if (_uiOn == true)
                {
                    _actionUI.SetActive(true);
                }
                _chess.CheckList();
                if (_chess._isInHand == true)
                {
                    _canInteract = true;
                }
                if (Input.GetButtonDown("Action") && _canInteract == true)
                {
                    _uiOn = false;
                    _lessUI.SetActive(true);
                    _chess.Open();
                }
                if (Input.GetButtonDown("Action") && _canInteract == false)
                {
                    _uiOn = false;
                    _audioSource.PlayOneShot(_chessDeclineSfx);
                }
                if (Input.GetButtonDown("Back") && _canInteract == true)
                {
                    _clockInteract.Back();
                    _lessUI.SetActive(false);
                    _uiOn = true;
                }
            }
            else
            {
                if (_uiOn == false)
                {
                    _actionUI.SetActive(false);
                }
            }
            //Interact Radio
            if(_hit.transform.CompareTag("Radio"))
            {
                if(Input.GetButtonDown("Action"))
                {
                    _actionUI.SetActive(false);
                    _radio.Play();
                    _radioCode.Open();
                    _lessUI.SetActive(true);
                }
                if (Input.GetButtonDown("Back"))
                {
                    _radioCode.Back();
                    _lessUI.SetActive(false);
                }
            }
            //Interact GramoPhone
            if(_hit.transform.CompareTag("GramPhone"))
            {
                if (Input.GetButtonDown("Action"))
                {
                    _gramophone.Play();
                }

            }
            //Interact Clock
            if (_hit.transform.CompareTag("Clock"))
            {
                if (_uiOn == true)
                {
                    _actionUI.SetActive(true);
                }
                _clockInteract.CheckList();
                if (_clockInteract._isInHand == true)
                {
                    _canInteract = true;
                }
                if (Input.GetButtonDown("Action") && _canInteract == true)
                {
                    _uiOn = false;
                    _clockInteract.Open();
                }
                if (Input.GetButtonDown("Action") && _canInteract == false)
                {
                    _uiOn = false;
                    _audioSource.PlayOneShot(_clockDeclineSfx);
                }

                if (Input.GetButtonDown("Back"))
                {
                    _clockInteract.Back();
                    _uiOn = true;
                }
            }
            else
            {
                if (_uiOn == false)
                {
                    _actionUI.SetActive(false);
                }
            }

            //Pick item for the sanity bar    
            if (_hit.transform.CompareTag("pills"))
            {
                if (_uiOn == true)
                {
                    _actionUI.SetActive(true);
                }
                _pills = _hit.collider.gameObject;
                if (Input.GetButtonDown("Action"))
                {
                    _uiOn = false;
                    _sanityBar.t += 100;
                    _audioSource.PlayOneShot(_pillSfx);
                    Debug.Log("recovered");
                    Destroy(_pills.gameObject);
                }
                else
                {
                    if (_uiOn == false)
                    {
                        _actionUI.SetActive(false);
                    }
                }
            }

            //Carring Spetials Object 
            _objGrable = _hit.collider.gameObject;
            if (_objGrable.TryGetComponent<GrabObj>(out GrabObj _grabObj))
            {
                if (_hit.transform.CompareTag("ObjCarring"))
                {
                    _grabObj._canCarry = true;
                }
            }
            else
            {
                _objGrable = null;
                if (_uiOn == false)
                {
                    _grabUI.SetActive(false);
                }
            }


            //Pick letters for read
            _letterMail = _hit.collider.gameObject;
            if (_letterMail.TryGetComponent<LetterRead>(out LetterRead _mailCode))
            {
                if (_hit.transform.CompareTag("Letter"))
                {
                    if (_uiOn == true)
                    {
                        _actionUI.SetActive(true);
                    }
                    if (Input.GetButtonDown("Action"))
                    {
                        _uiOn = false;
                        _lessUI.SetActive(true);
                        _canSee = false;
                        _player._canMove = false;
                        _mailCode.Read();
                        _gameManager.Focus();
                    }

                    if (Input.GetButtonDown("Back"))
                    {
                        _uiOn = true;
                        _lessUI.SetActive(false);
                        _canSee = true;
                        _player._canMove = true;
                        _mailCode.BackInPlaceWOSanity();
                        _gameManager.UnFocus();
                    }
                    if (Input.GetButtonDown("Back") && _sanityIsActive)
                    {
                        _uiOn = true;
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
                    if (_uiOn == false)
                    {
                        _actionUI.SetActive(false);
                    }
            }

            _obj = _hit.collider.gameObject;
            if (_obj.TryGetComponent<Iinteractable>(out Iinteractable interactObj))
            {
                //Object can be manipulate 360°
                if (_hit.transform.CompareTag("Object"))
                {
                    if (_uiOn == true)
                    {
                        _actionUI.SetActive(true);
                    }
                    if (Input.GetButtonDown("Action"))
                    {
                        _uiOn = false;                   
                        _lessUI.SetActive(true);
                        _canSee = false;
                        _obj.transform.position = _objInView.transform.position;
                        _player._canMove = false;
                        interactObj.Pick();
                        _gameManager.Focus();
                    }
                    if (Input.GetButtonDown("Back"))
                    {
                        _uiOn = true;
                        _lessUI.SetActive(false);
                        _canSee = true;
                        _player._canMove = true;
                        interactObj.Back();
                        _gameManager.UnFocus();
                    }
                }
                else
                {
                    if (_uiOn == false)
                    {
                        _actionUI.SetActive(false);
                    }
                }
                //Light switcher action
                if (_hit.transform.CompareTag("Light"))
                {
                    if (_uiOn == true)
                    {
                        _actionUI.SetActive(true);
                    }
                    if (Input.GetButtonDown("Action"))
                    {
                        _uiOn = false;
                        interactObj.SwitchLight();                     
                    }
                }
                else
                {
                    if (_uiOn == false)
                    {
                        _actionUI.SetActive(false);
                    }
                }
                //Open the door when the key is selected
                if (_hit.transform.CompareTag("Door"))
                {
                    if (_uiOn == true)
                    {
                        _actionUI.SetActive(true);
                    }
                    interactObj.CheckList();
                    ObjInteract objInteract = _hit.collider.gameObject.GetComponent<ObjInteract>();

                    if (objInteract._isInHand == true)
                    {
                        _canOpen = true;
                    }
                    if (Input.GetButtonDown("Action") && _canOpen == true)
                    {
                        _uiOn = false;
                        interactObj.OpenDoor();
                        _actionUI.SetActive(false);
                    }
                    if (Input.GetButtonDown("Action") && _canOpen == false)
                    {
                        _audioSource.PlayOneShot(_sfxLock);
                    }
                }
                else
                {
                    if (_uiOn == false)
                    {
                        _actionUI.SetActive(false);
                    }
                }

                //Open the case
                if (_hit.transform.CompareTag("Case"))
                {
                    if (_uiOn == true)
                    {
                        _actionUI.SetActive(true);
                    }
                    if (Input.GetButtonDown("Action"))
                    {
                        _uiOn = false;
                        interactObj.OpenCase();
                        _actionUI.SetActive(false);
                        _tutoSanity.SetActive(true);
                        _player.InInventory = true;
                        StartCoroutine(BackWarning());
                    }
                }
                else
                {
                    if (_uiOn == false)
                    {
                        _actionUI.SetActive(false);
                    }
                }
            }
        }
  
    }
        //Iteract With the ouija table
        private void OuiijaTarget()
        {
            RaycastHit _hit;

            if (Physics.Raycast(transform.position, transform.forward, out _hit, _distRange, _layerMaskEnigma) && _canRay == true)
            {
                if (_uiOn == true)
                {
                    _actionUI.SetActive(true);
                }
                _obj = _hit.collider.gameObject;
                if (_hit.transform.CompareTag("Enigme"))
                {
                    if (Input.GetButtonDown("Action"))
                    {
                        _uiOn = false;
                        _lens.Open();
                        _actionUI.SetActive(false);
                    }
                }
            }

            else
            {
                if (_uiOn == false)
                {
                    _actionUI.SetActive(false);
                }
            }

        }
    private IEnumerator BackWarning()
    {
        float time = 8f;
        yield return new WaitForSeconds(time);
        Debug.Log("goback");
        _sanityUI.SetActive(true);
        _sanityBar.startCounting = true;
        _lessUI.SetActive(false);
        _tutoSanity.SetActive(false);
        _player.InInventory = false;
        _sanityIsActive = true;

    }
}


    
