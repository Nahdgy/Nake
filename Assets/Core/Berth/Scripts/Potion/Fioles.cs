using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Fioles : MonoBehaviour
{
    Vector3 OGPos;

    private void Start()
    {
        OGPos = gameObject.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Chaudron")
        {
            transform.position = OGPos;
        }

        if (other.gameObject.layer == 3)
        { 
            transform.position = OGPos;
        }
    }
}
