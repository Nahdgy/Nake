using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;


public class INavigation : MonoBehaviour
{   
    public ItemData _item;

    [SerializeField]
    private GameObject _inventoryUi;
    [SerializeField]
    private PlayerCam _playerCam;
    [SerializeField]
    private PlayerMov _playerMov;


    private void Update()
    {
        OpenTheInventory();
    }
    private void OpenTheInventory()
    {
        if(Input.GetButtonDown("Inventory"))
        {
            _inventoryUi.SetActive(true);
            _playerMov._canMove = false;
            _playerCam._canSee = false;
        }
        else if (Input.GetButtonDown("Back"))
        {
            _inventoryUi.SetActive(false);
            _playerMov._canMove = true;
            _playerCam._canSee = true;
        }

    }
    public void ClickButton()
    {
        Innventory.Instance.SelectedObject(_item);
    }
}
