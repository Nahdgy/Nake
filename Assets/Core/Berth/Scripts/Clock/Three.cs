using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Three : MonoBehaviour
{
    [SerializeField] GameObject Small;
    [SerializeField] private bool isOkSmall;
    public bool IsOkSmall { get { return isOkSmall; }}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Small)
        {
            isOkSmall = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Small)
        {
            isOkSmall = false;
        }
    }
}
