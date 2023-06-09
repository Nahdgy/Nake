using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class PianoKey : MonoBehaviour
{
    private AudioSource _audioSource;
    private int _finger = 16;
    [SerializeField]
    private float _baseposition = -90f;
    [SerializeField]
    private float _pressedPosition;
    [SerializeField]
    private Transform _joint;
    private float _rotation;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();

    }

    private void OnCollisionEnter(Collision collision)
    {
        //Make a joint like the door  
        if (collision.gameObject.layer == _finger)
        {

            _audioSource.Play();

            float _lerpDuration = 5f;
            float _timer = 0f;

            while (_timer < _lerpDuration)
            {
                _timer += Time.deltaTime;
                _rotation = Mathf.Lerp(_baseposition, _pressedPosition, _timer / _lerpDuration);
                _joint.transform.rotation = Quaternion.Euler(_rotation, 0, 0);
            }

        }
    }
    private void OnCollisionExit(Collision collision)
    {
        float _lerpDuration = 5f;
        float _timer = 0f;

        while (_timer < _lerpDuration)
        {
            _timer -= Time.deltaTime;
            _rotation = Mathf.Lerp(_pressedPosition, -90f,_timer / _lerpDuration);
            _joint.transform.rotation = Quaternion.Euler(_rotation, 0, 0);
        }
    }

}
