using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjInteract : MonoBehaviour, Iinteractable
{
    public bool _canSwitch = false;
    //Intaractable GameObjects
    [SerializeField]
    private GameObject _light, _door;

    public void Pick()
    {}
    public void Back()
    {}
    public void ReturnBase()
    {}
    public void SwitchLight()
    {
        _canSwitch = true;

        if(_canSwitch == true)
        {
            _light.SetActive(true);
            _canSwitch = false;
        }
        if (_canSwitch  == false)
        {
            _light.SetActive(false);
            _canSwitch = true;

        }
    }
}
