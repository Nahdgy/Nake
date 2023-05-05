using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Code : MonoBehaviour
{ 
    public string _letter;

    private AudioSource _audioSource;
    private bool _find = false, _unlock = false; 
    private string _code;
   
    [SerializeField]
    private AudioClip _sfxRight, _sfxUnlock,_sfxWrong;
    [SerializeField]
    private List<AudioClip> _sfxTab = new List<AudioClip>();
    [SerializeField]
    private float _waintingScene;
    [SerializeField]
    private GameObject _enigme; 
    [SerializeField]
    private string _sceneName; 
    [SerializeField]
    private Text _txt;
    [SerializeField]
    private Words _word = new Words();
     
    void Start()
    {
        _enigme = GameObject.FindGameObjectWithTag("Enigme");
        if (_enigme.TryGetComponent<Icodable>(out Icodable response))
        {
            response.Code1();
        }
        _audioSource = GetComponent<AudioSource>();
    }

    private IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(_waintingScene);
        SceneManager.LoadScene(_sceneName);
    }

    public void QuitCode()
    {
        SceneManager.LoadScene(_sceneName);
    }
       


    public void Validation(string letter)
    {
        _code = "";
        _find = false;
       

        for (int i = 0; i < _word.GetSetCurCode.Length; i++)
        {
           
            if (_txt.text.Substring(i, 1) == "_")
            {
                
                if (_word.GetSetCurCode.Substring(i, 1) == _letter)
                {
                    _code += _letter;
                    _find = true;
                }
                else
                {
                    _code += "_";
                }
            }
            else
            {
                _code += _txt.text.Substring(i, 1);
            }
        }
        _txt.text = _code;
        Verification();
    }
   
    private void Verification()
    {
        if(_find == true)
        {
            _audioSource.PlayOneShot(_sfxRight);
            if(_txt.text == _word.GetSetCurCode)
            {
                _audioSource.PlayOneShot(_sfxUnlock);
                _unlock = true;
                StartCoroutine(ChangeScene());
            }
        }
        else
        {
            _sfxWrong = _sfxTab[Random.Range(0, _sfxTab.Count)];
            _audioSource.PlayOneShot(_sfxWrong);
        }      
    }        
}