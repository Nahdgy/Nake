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
    public void Pick()
    { }
    public void Back()
    { }
    public void ReturnBase()
    { }
}

