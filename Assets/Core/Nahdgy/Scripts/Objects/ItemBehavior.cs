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
<<<<<<< HEAD
        }
        Innventory.Instance.AddItem(_itemBehavior._itemData);
=======
        }    
        _inventory.AddItem(_itemBehavior._itemData);
>>>>>>> parent of 69be29e (Finish Inventory Putain de merde)
        Destroy(_itemBehavior.gameObject, _destroyTiming);   
    }
}
