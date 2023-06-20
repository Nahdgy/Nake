using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;
using UnityEngine.UI;



public class Innventory : MonoBehaviour
{
    [SerializeField]
    private List<ItemInInventory> _content = new List<ItemInInventory>();
    [SerializeField]
    private Transform _inventorySlotsParents, _inHandSlot;

    [HideInInspector]
    public ItemData _itemCurrentlySelected;

    [SerializeField]
    private Sprite _emptySlotVisual;

    private int _maxStack = 4;
    public int _objId;


    const int InventorySize = 4;

    public static Innventory Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void AddItem(ItemData item)
    {
        ItemInInventory[] itemInInventory = _content.Where(elem => elem.itemData == item).ToArray();

        bool itemAdded = false;

        if (itemInInventory.Length > 0)
        {

            for (int i = 0; i < itemInInventory.Length; i++)
            {
                if (itemInInventory[i].count < _maxStack)
                {
                    itemAdded = true;
                    itemInInventory[i].count++;
                    break;
                }

                if (!itemAdded)
                {
                    _content.Add(new ItemInInventory { itemData = item, count = 1 });
                }
            }
        }
        else
        {
            _content.Add(new ItemInInventory { itemData = item, count = 1 });
        }
        RefreshContent();

    }
    public void RefreshContent()
    {

        // On peuple le visuel des slots selon le contenu réel de l'inventaire
        for (int i = 0; i < _content.Count; i++)
        {
            Slot currentSlot = _inventorySlotsParents.GetChild(i).GetComponent<Slot>();
            currentSlot._item = _content[i].itemData;
            currentSlot._itemVisual.sprite = _content[i].itemData._visual;
        }
    }
    public bool IsFull()
    {
        return InventorySize == _content.Count;
    }
    public void RemoveItem(ItemData item)
    {
        ItemInInventory itemInInventory = _content.Where(elem => elem.itemData == item).FirstOrDefault();

        if (itemInInventory != null && itemInInventory.count > 1)
        {
            itemInInventory.count--;
        }
        else
        {
            _content.Remove(itemInInventory);
        }
    }

    public void SelectedObject(ItemData item)
    {
        _itemCurrentlySelected = item;

        Debug.Log("IsInSelected");

        if (item == null) return;
        switch (item._itemType)
        {
            case ItemType.KeyDeskRoom:
                _objId = 1;
                break;
            case ItemType.KeyBedRoomEnter: 
                _objId = 2; 
                break;
            case ItemType.KeyKitchen: 
                _objId = 3; 
                break;
            case ItemType.KeyHall: 
                _objId = 4;
                break; 
            case ItemType.ChessPiece: 
                _objId = 5; 
                break;
            case ItemType.ClockHand: 
                _objId = 6;
                break; 
        }
        _inHandSlot.GetChild(0).GetComponent<Image>().sprite = item._visual;

    }
   
} 
    [System.Serializable]
    public class ItemInInventory
    {
        public ItemData itemData;
        public int count;
    }
