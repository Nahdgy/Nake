using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjInteract : MonoBehaviour, Iinteractable
{
    public bool _canSwitch;
    //Intaractable GameObjects
    [SerializeField]
    private GameObject _door;
    [SerializeField]
    private Light _light;
    [SerializeField]
    private float _timerDoor, _rotationDoor, _baseAngle, _endAngle;
    [SerializeField]
    private PlayerCam _playerCam = new PlayerCam();


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
        }
        if (_canSwitch == false)
        {
            _light.intensity = 0f;
        }
    }
    public void OpenDoor()
    {
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
            _door.transform.rotation = Quaternion.Euler(0, _rotationDoor, 0); 
           yield return null;      
        }
        yield return new WaitForSeconds(_timerDoor);
        _timer = 0f;
        while (_timer < _lerpDuration)
        {
            _timer += Time.deltaTime;
            _rotationDoor = Mathf.Lerp(_endAngle, 0f, _timer / _lerpDuration);
            _door.transform.rotation = Quaternion.Euler(0, _rotationDoor, 0);
            _playerCam._canOpen = false;
            yield return null;
        }
    
    }
    public void Pick()
    { }
    public void Back()
    { }
    public void ReturnBase()
    { }
}

