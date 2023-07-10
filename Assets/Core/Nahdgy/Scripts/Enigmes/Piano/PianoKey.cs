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

    [SerializeField]
    private Joint joint;

    float timeToLerp = 1f;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        joint = GetComponentInParent<Joint>();
        GetComponent<Rigidbody>().freezeRotation = true;
        //_joint = gameObject.GetComponentInParent<Transform>();

    }

    private void OnCollisionEnter(Collision collision)
    {
        //When the finger press the key
        if (collision.gameObject.layer == _finger)
        {
            _audioSource.Play();
            joint.RotationDown();       
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        //When the finger press out the key
        if (collision.gameObject.layer == _finger)
        {
            joint.RotationUP();
        }
    }
}
