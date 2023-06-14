using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerRay : MonoBehaviour
{
    [SerializeField]
    private GameObject _touche;
    [SerializeField]
    private float _distRange;
    [SerializeField]
    private LayerMask _layerMask;
    [SerializeField]
    private PianoNav _pianoNav;


    private void Update()
    {
        Target();
    }
    private void Target()
    {
        RaycastHit _hit;
        if(Physics.Raycast(transform.position, transform.up * -1, out _hit, _distRange, _layerMask))
        {
            _pianoNav._canGoDown = true;
            _touche = _hit.collider.gameObject;
            _touche.GetComponent<Renderer>().material.color = Color.green;
        }
        else
        {
            _pianoNav._canGoDown = false;
            _touche.GetComponent<Renderer>().material.color = Color.white;
        }
    }
}
