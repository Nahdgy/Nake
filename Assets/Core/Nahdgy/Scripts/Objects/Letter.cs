using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Letter : MonoBehaviour
{
    [SerializeField]
    private GameObject _UITraduction;
    [SerializeField]
    private AudioSource _audioSource;
    [SerializeField]
    private AudioClip _paperSfx;
    [SerializeField]
    private Transform _letterTranform, _objInView, _basePlace;

    public void PickLetter()
    {
        _audioSource.PlayOneShot(_paperSfx);
        _letterTranform.position = _objInView.transform.position;
        _UITraduction.SetActive(true);
    }
    public void BackInPosition()
    {
        _audioSource.PlayOneShot(_paperSfx);
        _letterTranform.position = _basePlace.transform.position;
        _UITraduction.SetActive(false);
    }



}
