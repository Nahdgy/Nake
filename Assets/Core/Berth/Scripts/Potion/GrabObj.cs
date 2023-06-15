using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObj : MonoBehaviour
{
    public Transform _playerCam;

    [SerializeField]
    private bool _hasPlayer = false, _beingCarried = false, _touched = false;
    public bool _canCarry = false;

    [SerializeField]
    private GameObject _grabUI;

    public void Update()
    {

        if (_canCarry == true)
        {
            Debug.Log("player here");
            _hasPlayer = true;
            _grabUI.SetActive(true);
        }
        else
        {
            _hasPlayer = false;
            _grabUI.SetActive(false);
        }

        if (_hasPlayer == true && Input.GetAxis("RT") > 0)
        {
            GetComponent<Rigidbody>().isKinematic = true;
            transform.parent = _playerCam;
            _beingCarried = true;
        }

        if (_beingCarried)
        {
            if (_touched)
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                _beingCarried = false;
                _touched = false;
            }

            else if (Input.GetAxis("RT") <= 0)
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                _beingCarried = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_beingCarried)
        {
            _touched = true;
        }
    }
}

