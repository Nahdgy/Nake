using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehavior : MonoBehaviour
{
    [SerializeField]
    private Innventory _inventory;
    [SerializeField]
    private float _destroyTiming;
   

    public void DoPickUp(Item _itemBehavior)
    {
        if (_inventory.IsFull())
        {
            return;
        }    
        _inventory.AddItem(_itemBehavior._itemData);
        Destroy(_itemBehavior.gameObject, _destroyTiming);   
    }
}
