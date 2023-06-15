using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjInteract : MonoBehaviour, Iinteractable
{
    //[HideInInspector]
    public bool _isInHand = false;
    //[HideInInspector]
    public bool _canSwitch;

    [Header("Intaractable GameObjects")]
    [SerializeField]
    private GameObject _doorHinge;
    [SerializeField]
    private Light _light;

    [Header("Parameters")]
    [SerializeField]
    private float _timerDoor, _rotationDoor, _baseAngle, _endAngle;
    [SerializeField]
    private int _itemNeed;

    [Header("Sfx")]
    [SerializeField]
    private AudioSource _source;
    [SerializeField]
    private AudioClip _doorOpenSfx, _doorShutSfx, _swithLightSfx;
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private string _rotationCase;

    [Header("CodeCaller")]
    [SerializeField]
    private PlayerCam _playerCam = new PlayerCam();
    [SerializeField]
    private Innventory _itemSelect;

    public void SwitchLight()
    {
        TurnLight();
        _canSwitch = !_canSwitch;
    }
    private void TurnLight()
    {
        if (_light == null)
        {
            Debug.Log("Lumière non assigné"); 
            return;
        }
           
        if (_canSwitch == true)
        {
            _light.intensity = 100f; 
            _source.PlayOneShot(_swithLightSfx);
        }
        if (_canSwitch == false)
        {
            _light.intensity = 0f;
            _source.PlayOneShot(_swithLightSfx);
        }
    } 
    public void OpenCase()
    {
        _animator.Play(_rotationCase);
        
    }
    public void ViewTab()
    {

    }
    public void OpenDoor()
    {
        _source.PlayOneShot(_doorOpenSfx);
        StartCoroutine(ClosingDoor());      
    }  
    private IEnumerator ClosingDoor()
    {  
        float _lerpDuration = 5f;
        float _timer = 0f;
       
        while (_timer < _lerpDuration)
        {
            _timer += Time.deltaTime;
            _rotationDoor = Mathf.Lerp(_baseAngle, _endAngle, _timer/_lerpDuration);
            _doorHinge.transform.rotation = Quaternion.Euler(0, _rotationDoor, 0); 
            yield return null;      
        }
        yield return new WaitForSeconds(_timerDoor);
        _timer = 0f;
        while (_timer < _lerpDuration)
        {
            _timer += Time.deltaTime;
            _rotationDoor = Mathf.Lerp(_endAngle, 0f, _timer / _lerpDuration);
            _doorHinge.transform.rotation = Quaternion.Euler(0, _rotationDoor, 0);
            _playerCam._canOpen = false;
            yield return null;
        }
        yield return new WaitForSeconds(0.1f);
        _source.PlayOneShot(_doorShutSfx);
    }
    public void CheckList()
    {
        if (_itemNeed == 0) return;

        if (_itemSelect._objId == _itemNeed)
        {
            Debug.Log("L'objet est dans la main");
            _isInHand = true;
        }
        else if (_itemSelect._objId != _itemNeed)
        {
            _isInHand = false;
        }
    }
    public void Pick()
    { }
    public void Back()
    { }
}

