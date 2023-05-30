using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Six : MonoBehaviour
{
    [SerializeField] GameObject Tall;
    [SerializeField] private bool isOkTall ;
    public bool IsOkTall {get { return isOkTall; }}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Tall)
        {
            isOkTall= true; 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Tall)
        {
            isOkTall = false;
        }
    }
}
