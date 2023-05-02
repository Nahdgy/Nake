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


    private void Update()
    {
        TurnLight();
    }
    public void SwitchLight()
    {
        _canSwitch = !_canSwitch;
        Debug.Log("yesess");
    }
    private void TurnLight()
    {

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
        _door.transform.rotation = Quaternion.Euler(0, 0, 0);
    }
    public void Pick()
    { }
    public void Back()
    { }
    public void ReturnBase()
    { }
}

