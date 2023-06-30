using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour
{
    [SerializeField]
    private float _timer;

    [SerializeField]
    private AudioSource _source;
    [SerializeField]
    private AudioClip _interesting;

    [SerializeField]
    private GameObject _tradUI, _otherCanvas;

    [SerializeField]
    private Transform _camera, _place;

    [SerializeField]
    private CinemachineVirtualCamera _cameraPlayer, _cameraRadio;

    [SerializeField]
    private PlayerController _player;
    [SerializeField]
    private PlayerCam _playerCam;

    private void Update()
    {
        CamInPlace();
    }
    private void CamInPlace()
    {
        _camera.position = _place.position;
        _camera.rotation = _place.rotation;
    }
    public void Open()
    {
        Time.timeScale = 0f;
        _otherCanvas.SetActive(false);
        _cameraPlayer.Priority = 0;
        _cameraRadio.Priority = 10;
        _tradUI.SetActive(true);
        _player._canMove = false;
        _playerCam._canSee = false;
        _player.InInventory = true;
        StartCoroutine(AudioLast());
    }
    public void Back()
    {
        Time.timeScale = 1f;
        _otherCanvas.SetActive(true);
        _cameraPlayer.Priority = 10;
        _cameraRadio.Priority = 0;
        _tradUI.SetActive(false);
        _player._canMove = true;
        _playerCam._canSee = true;
        _player.InInventory = false;
    }

    public IEnumerator AudioLast()
    {
        yield return new WaitForSeconds(_timer);
        _source.PlayOneShot(_interesting);
        Back();
    }
}
