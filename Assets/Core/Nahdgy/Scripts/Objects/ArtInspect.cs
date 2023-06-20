using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtInspect : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera _cameraPlayer, _cameraTab;

    public void Open()
    {
        _cameraPlayer.Priority = 0;
        _cameraTab.Priority = 10;
    }

    public void Back()
    {
        _cameraPlayer.Priority = 10;
        _cameraTab.Priority = 0;
    }
    
}
