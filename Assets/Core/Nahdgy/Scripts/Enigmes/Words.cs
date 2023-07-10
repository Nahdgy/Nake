using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Words : MonoBehaviour
{
   private List<string> _listWords = new List<string>();
   private string _curCode;

    public string GetSetCurCode
    {
        get { return _curCode; }
        set { _curCode = value; }
    }

}
