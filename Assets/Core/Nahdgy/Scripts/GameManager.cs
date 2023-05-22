using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering.Universal;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class GameManager : MonoBehaviour
{
    [SerializeField] 
    private Volume _volumeVignette;
    [SerializeField]
    private GameObject _renderBlur;
    [SerializeField]
    private float _min, _max;

    static float t = 0.0f;
    private void Start()
    {
        
    }
    public void Focus()
    {
        _renderBlur.SetActive(true);
        if(_volumeVignette.profile.TryGet(out Vignette vignette))
        { 
            vignette.intensity.value = Mathf.Lerp(_min,_max, t);
            t += 0.5f * Time.deltaTime;
        }
    }

    public void UnFocus()
    { 
        _renderBlur.SetActive(false);
        if (_volumeVignette.profile.TryGet(out Vignette vignette))
        { 
            vignette.intensity.value = Mathf.Lerp(_max, _min, t);
            t += 0.5f * Time.deltaTime;
        }
    }

}
