using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tirroir : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private string _animName;
    [SerializeField]
    private Clock _clock;
    [SerializeField]
    private GlobeNav _globe;
    [SerializeField]
    private GameObject _triggerInteract;
  
    void Update()
    {
        TirroirAnim();
    }

    private void TirroirAnim()
    {
        if(_clock._canOpen == true &&  _globe._canOpen == true)
        {
            _triggerInteract.SetActive(true);
            _animator.Play(_animName);
        }
       
    }
}
