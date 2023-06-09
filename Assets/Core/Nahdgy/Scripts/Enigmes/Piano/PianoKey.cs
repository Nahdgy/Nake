using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class PianoKey : MonoBehaviour
{
    private AudioSource _audioSource;
    private int _finger = 16;
    [SerializeField]
    private float _pressedPosition,_basePosition = -90f,_speed = 3f;
    [SerializeField]
    private Transform _joint;
    private float _rotation;

    float timeToLerp = 1f;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        //_joint = gameObject.GetComponentInParent<Transform>();

    }

    private void OnCollisionEnter(Collision collision)
    {
        //When the finger press the key
        if (collision.gameObject.layer == _finger)
        {
            _audioSource.Play();

            if(timeToLerp > 0f) 
            {
                timeToLerp -= _speed * Time.deltaTime;
            }
           
            _rotation = Mathf.Lerp(_pressedPosition,_basePosition, timeToLerp);
            _joint.transform.rotation = Quaternion.Euler(_rotation, _joint.transform.rotation.y, _joint.transform.rotation.z);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        //When the finger press out the key
        if (collision.gameObject.layer == _finger)
        {

            if (timeToLerp < 1f)
            {
                timeToLerp += _speed * Time.deltaTime;
            }

            _rotation = Mathf.Lerp(_pressedPosition, _basePosition, timeToLerp);
            _joint.transform.rotation = Quaternion.Euler(_rotation, _joint.transform.rotation.y, _joint.transform.rotation.z);
        }
    }
}
