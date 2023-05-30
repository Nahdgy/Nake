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
    private float _min, _max, _speed;


    static float t = 0.0f;
   
    IEnumerator VignetteEffectFocus()
    {
        if (_volumeVignette.profile.TryGet(out Vignette vignette))
        {
            while(t<1f)
            {
                vignette.intensity.value = Mathf.Lerp(_min, _max, t);
                t += _speed * Time.deltaTime;
                yield return null;
            }    
        } 
    } 
    public void Focus()
    {
        _renderBlur.SetActive(true);
        StartCoroutine(VignetteEffectFocus());
    }
    IEnumerator VignetteEffectUnFocus()
    {
        if (_volumeVignette.profile.TryGet(out Vignette vignette))
        {
            while (t > 0f)
            {
                vignette.intensity.value = Mathf.Lerp(_min, _max, t);
                t -= _speed * Time.deltaTime;
                yield return null;
            }
        }
    }

    public void UnFocus()
    { 
        _renderBlur.SetActive(false);
        StartCoroutine(VignetteEffectUnFocus());
    }

}
