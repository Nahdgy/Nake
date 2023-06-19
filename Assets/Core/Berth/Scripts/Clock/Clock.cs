using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    [SerializeField] Animator Animation;
    [SerializeField] private Six six;
    [SerializeField] private Three three;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _validSfx;

    [SerializeField] private ClockInteract _clockInteract;

    public bool _canOpen = false;

    void Start()
    {
        Animation = GetComponent<Animator>();
        Animation.speed = 0;
    }

    void Update()
    {
        ClockControl();
        Validation();
    }

    private void Validation()
    {
        if (three.IsOkSmall && six.IsOkTall && Input.GetButton("Action")) 
        {
           _canOpen = true;
            _audioSource.PlayOneShot(_validSfx);
           _clockInteract.Back();
        }
    }

    void ClockControl()
    {
        if (_clockInteract._canManip == true)
        {
            if (Input.GetAxis("RT") > 0)
            {
                Animation.speed = 1;
            }
            else if (Input.GetAxis("RT") <= 0)
            {
                Animation.speed = 0;
            }
        }
    }
}