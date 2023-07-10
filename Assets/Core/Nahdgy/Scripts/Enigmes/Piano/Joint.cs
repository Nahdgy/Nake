using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Joint : MonoBehaviour
{
    [SerializeField]
    private float _pressedPosition, _basePosition = -90f, _speed = 3f;
    private float _rotation;

    float timeToLerp = 1f;

    public void RotationDown()
    {
        if (timeToLerp > 0f)
        {
            timeToLerp -= _speed * Time.deltaTime;
        }

        _rotation = Mathf.Lerp(_basePosition, _pressedPosition, timeToLerp);
        transform.rotation = Quaternion.Euler(_rotation, 0f, -90f);
    }

    public void RotationUP()
    {
        if (timeToLerp < 1f)
        {
            timeToLerp += _speed * Time.deltaTime;
        }

        _rotation = Mathf.Lerp(_pressedPosition, _basePosition, timeToLerp);
        transform.rotation = Quaternion.Euler(_rotation, 0f, -90f);
    }
}
