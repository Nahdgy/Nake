using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditor.Progress;

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

        Debug.Log("add to list");
        Innventory.Instance.AddItem(_itemBehavior._itemData);
        Destroy(_itemBehavior.gameObject, _destroyTiming);   
    }
}
