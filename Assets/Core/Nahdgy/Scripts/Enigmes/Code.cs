using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Code : MonoBehaviour
{
    [SerializeField]
    private Words _word = new Words();
    [SerializeField]
    private GameObject _enigme;

    public string _letter;
    public Text _txt;
    private string _code;
    private bool _find = false;
   

    void Start()
    {
        _enigme = GameObject.FindGameObjectWithTag("Enigme");
        if (_enigme.TryGetComponent<Icodable>(out Icodable response))
        {
            response.Code1();
        }
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
    }
}
