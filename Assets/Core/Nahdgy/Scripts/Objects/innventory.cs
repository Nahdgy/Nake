using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;
using UnityEngine.UI;
using static UnityEditor.Progress;


public class Innventory : MonoBehaviour
{
    [SerializeField]
    private List<ItemInInventory> _content = new List<ItemInInventory>();
    [SerializeField]
    private Transform _inventorySlotsParents, _inHandSlot;

    [HideInInspector]
    public ItemData _itemCurrentlySelected;

    [SerializeField]
    private AudioSource _source;
    [SerializeField]
    private AudioClip _pickSfx, _nullSfx, _openSfx, _closeSfx;
    [SerializeField]
    private Sprite _emptySlotVisual;

    public int _objId;


    const int InventorySize = 4;

    public static Innventory Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void AddItem(ItemData item)
    {
        
        /*_content.Add(item);
        ItemInInventory[] itemInInventory = content.Where(elem => elem.itemData == item).ToArray();

        for (int i = 0; i < _content.Count; i++)
        {
            //_navSlot._item = _content[i];
            _inventorySlotsParents.GetChild(i).GetChild(0).GetComponent<Image>().sprite = _content[i]._visual;
        }
        */
        ItemInInventory[] itemInInventory = _content.Where(elem => elem.itemData == item).ToArray();

        bool itemAdded = false;

        if (itemInInventory.Length > 0 && item._stackable == true)
        {

            for (int i = 0; i < itemInInventory.Length; i++)
            {
                if (itemInInventory[i].count < item._maxStack)
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

        // Add sprite on the innventary slot
        /*for (int i = 0; i < _content.Count; i++)
        {
            Slot currentSlot = _inventorySlotsParents.GetChild(i).GetComponent<Slot>();
            currentSlot._item = _content[i].itemData;
            currentSlot._itemVisual.sprite = _content[i].itemData._visual;
        }*/
    }
    public void RefreshContent()
    {
        // Move up all slots
        /*for (int i = 0; i < _inventorySlotsParents.childCount; i++)
        {
            Slot currentSlot = _inventorySlotsParents.GetChild(i).GetComponent<Slot>();

            currentSlot._item = null;
            currentSlot._itemVisual.sprite = _emptySlotVisual;
        }*/

        // On peuple le visuel des slots selon le contenu réel de l'inventaire
        for (int i = 0; i < _content.Count; i++)
        {
            Slot currentSlot = _inventorySlotsParents.GetChild(i).GetComponent<Slot>();

            currentSlot._item = _content[i].itemData;
            Debug.Log("visual"+currentSlot._itemVisual);
            Debug.Log("sprite"+currentSlot._itemVisual.sprite) ;
            Debug.Log("itemdata"+ _content[i].itemData) ;
            Debug.Log("itemdatavisual"+ _content[i].itemData._visual) ;
            currentSlot._itemVisual.sprite = _content[i].itemData._visual;
        }
    }
    public void ReadALetter()
    {

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
        _inHandSlot.GetChild(0).GetComponent<Image>().sprite = item._visual;

    }
   
} 
    [System.Serializable]
    public class ItemInInventory
    {
        public ItemData itemData;
        public int count;
    }
