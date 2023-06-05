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

    private void OnCollisionEnter(Collision collision)
        {
            string tag = collision.gameObject.tag;
            switch (tag)
        {
           // case "1": GameManager.
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Chodron")
        {
            transform.position = OGPos;
        }
    }

}
