using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skull : MonoBehaviour
{
    private Animator _animatorSkull, _animatorDoor;
    [SerializeField]
    private string _animSkull, _animDoor;
    [SerializeField]
    private float _timer;

    private void Start()
    {
        _animatorSkull = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("BoxSkull"))
        {
            _animatorSkull.enabled = true;
            _animatorSkull.Play(_animSkull);
            StartCoroutine(DoorOpen());
        }
    }

    private IEnumerator DoorOpen()
    {
        yield return new WaitForSeconds(_timer);
        _animatorDoor.Play(_animDoor);
    }

}
