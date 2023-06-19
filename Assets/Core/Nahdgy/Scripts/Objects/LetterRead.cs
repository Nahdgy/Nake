using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LetterRead : MonoBehaviour
{
    [SerializeField]
    private GameObject _mail,_textUI, _otherCanvas;
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
        Time.timeScale = 0f;
        _otherCanvas.SetActive(false);
        _audioSource.PlayOneShot(_papperSfx);
        _textUI.SetActive(true);    
        _text.text = _traduction.text;
    }
    public void BackInPlace()
    {
        Time.timeScale = 1f; 
        _otherCanvas.SetActive(true);
        _audioSource.PlayOneShot(_papperSfx); 
        _textUI.SetActive(false);
    }
}
