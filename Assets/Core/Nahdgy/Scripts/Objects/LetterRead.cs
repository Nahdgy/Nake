using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LetterRead : MonoBehaviour
{
    [SerializeField]
    private Transform _objInView, _basePosition;
    [SerializeField]
    private GameObject _mail,_textUI;
    [SerializeField]
    private AudioSource _audioSource;
    [SerializeField]
    private AudioClip _papperSfx;
    [SerializeField]
    private TextMeshProUGUI _text,_traduction;
    [SerializeField]
    private string[] _textAnim;
    [SerializeField]
    private float _letterOnViewX,  _letterOnViewY;



    public void Read()
    {
        _audioSource.PlayOneShot(_papperSfx);
        _textUI.SetActive(true);
        _text.text = _traduction.text;
    }
    public void BackInPlace()
    {
        _audioSource.PlayOneShot(_papperSfx);
        _textUI.SetActive(false);
    }
}
