using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObj : MonoBehaviour
{
    public Transform _player;
    public Transform _playerCam;

    [SerializeField]
    private bool _hasPlayer = false, _beingCarried = false, _touched = false;

    [SerializeField]
    private GameObject _grabUI, _goUI;

    public void Update()
    {
        float _dist = Vector2.Distance(gameObject.transform.position, _player.position);

        if (_dist <= 1.9f)
        {
            _hasPlayer = true;
            _grabUI.SetActive(true);
        }
        else
        {
            _hasPlayer = false;
            _grabUI.SetActive(false);
        }

        if (_hasPlayer == true && Input.GetButtonDown("Action"))
        {

            GetComponent<Rigidbody>().isKinematic = true;
            transform.parent = _playerCam;
            _beingCarried = true;
        }

        if (_beingCarried)
        {
            _goUI.SetActive(true);
            if (_touched)
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                _beingCarried = false;
                _touched = false;
            }

            else if (Input.GetButtonUp("Action"))
            {
                _goUI.SetActive(false);
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

