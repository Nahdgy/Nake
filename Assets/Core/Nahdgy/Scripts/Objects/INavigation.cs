using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;


public class INavigation : MonoBehaviour
{   
    [SerializeField]
    private float _timerClick;
    [SerializeField]
    private bool _isOpen = false;
    [SerializeField]
    private GameObject _inventoryUi;
    [SerializeField]
    private AudioSource _source;
    [SerializeField]
    private AudioClip _pickSfx, _nullSfx,_openSfx,_closeSfx;

    [SerializeField]
    private PlayerCam _playerCam;
    [SerializeField]
    private PlayerController _playerMov;
    [SerializeField]
    private Innventory _innventoryCode;


    private void Update()
    {
        OpenTheInventory();
    }
    private void OpenTheInventory()
    {
        if (Input.GetButtonDown("Inventory") && _isOpen == false)
        {
            _source.PlayOneShot(_openSfx);
            _inventoryUi.SetActive(true);
            _playerMov._canMove = false;
            _playerCam._canSee = false;
            _playerCam._canRay = false;
            _isOpen = true;
        }
        else if (Input.GetButtonDown("Back") && _isOpen == true)
        {
            _source.PlayOneShot(_closeSfx);
            _inventoryUi.SetActive(false);
            _playerMov._canMove = true;
            _playerCam._canSee = true;
            _playerCam._canRay = true;
            _isOpen = false;

        }
    }
    public IEnumerator ClickTimer()
    {
        _source.PlayOneShot(_pickSfx);
        yield return new WaitForSeconds(_timerClick);
        _inventoryUi.SetActive(false);
        _playerMov._canMove = true;
        _playerCam._canSee = true;
        _isOpen = false;
    }
}
