using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtInspect : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera _cameraPlayer, _cameraTab;
    [SerializeField]
    private GameObject _otherCanvas;

    public void Open()
    {
        Time.timeScale = 0f;
        _otherCanvas.SetActive(false);
        _cameraPlayer.Priority = 0;
        _cameraTab.Priority = 10;
    }

    public void Back()
    {
        Time.timeScale = 1f;
        _otherCanvas.SetActive(true);
        _cameraPlayer.Priority = 10;
        _cameraTab.Priority = 0;
    }
    
}
