using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;
using UnityEngine.UI;


public class Innventory : MonoBehaviour
{
    public List<ItemData> _content = new List<ItemData>();
    [SerializeField]
    private Transform _inventorySlotsParents;
    [SerializeField]
    private INavigation _navSlot;

    [SerializeField]
    private AudioSource _source;
    [SerializeField]
    private AudioClip _pickSfx, _nullSfx, _openSfx, _closeSfx;

    public int _objId;


    const int InventorySize = 4;

    public static Innventory Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void AddItem(ItemData item)
    {
        _content.Add(item);
        AddContentIninventory();
    }
    private void AddContentIninventory()
    {
        for (int i = 0; i < _content.Count; i++)
        {
<<<<<<< HEAD
            Slot currentSlot = _inventorySlotsParents.GetChild(i).GetComponent<Slot>();

            currentSlot._item = _content[i].itemData;
            currentSlot._itemVisual.sprite = _content[i].itemData._visual;
=======
            _navSlot._item = _content[i];
            _inventorySlotsParents.GetChild(i).GetChild(0).GetComponent<Image>().sprite = _content[i]._visual;
>>>>>>> parent of 69be29e (Finish Inventory Putain de merde)
        }
    }
    public void ReadALetter()
    { 
    
    }
    public bool IsFull()
    {
        return InventorySize == _content.Count;
    }

    public void SelectedObject(ItemData item)
    {
        if (item == null) return;
        switch (item._itemType)
        {
            case ItemType.KeyDeskRoom:
                _objId = 1;
                break;
            case ItemType.KeyBedRoomEnter: 
                _objId = 2; 
                break;
            case ItemType.KeyBedRoomLeave: 
                _objId = 3;
                break;
            case ItemType.KeyKitchen: 
                _objId = 4; 
                break;
            case ItemType.KeyHall: 
                _objId = 5;
                break; 
            case ItemType.ChessPiece: 
                _objId = 6; 
                break;
            case ItemType.ClockHand: 
                _objId = 7;
                break; 
            case ItemType.SkullHead:
                _objId = 8;
                break;
            case ItemType.Letter:
                ReadALetter();
                break;

        }

    }
}
