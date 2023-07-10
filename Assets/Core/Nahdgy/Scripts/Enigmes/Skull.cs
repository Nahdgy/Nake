using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skull : MonoBehaviour
{
    private Animator _animatorSkull;
    [SerializeField]
    private string _animSkull;
    [SerializeField]
    private float _timer, _alphaFade = 1f, _timeToLerp = 1;
    [SerializeField]
    private GameObject _door;

    private void Start()
    {
        _animatorSkull = GetComponent<Animator>();
        //DoorLerp();
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
    private void DoorLerp()
    {
        //_timeToLerp += Time.deltaTime;
        _alphaFade = Mathf.Lerp(1f, 0f, _timeToLerp);
        _door.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, _alphaFade);    
    }


    private IEnumerator DoorOpen()
    {
        yield return new WaitForSeconds(_timer);
        DoorLerp();
        _door.SetActive(false);

    }

}
