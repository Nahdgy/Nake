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

    

    public void Read()
    {
        _mail.transform.position = _objInView.transform.position;
        _mail.transform.rotation = Quaternion.Euler(-150f, 0f, 0f);
        _audioSource.PlayOneShot(_papperSfx);
        _textUI.SetActive(true);
        _text.text = _traduction.text;
    }
    public void BackInPlace()
    {
        _mail.transform.position = _basePosition.transform.position;
        _mail.transform.rotation = _basePosition.rotation;
        _audioSource.PlayOneShot(_papperSfx);
        _textUI.SetActive(false);
    }

    private void ReadAnimation()
    {
        for (int i = 0; i < _textAnim.Length; i++)
        {


        }
    }


}
