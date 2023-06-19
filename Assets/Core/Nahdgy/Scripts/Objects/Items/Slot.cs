using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using static UnityEditor.Progress;

public class Slot : MonoBehaviour
{
    public ItemData _item;
    public Image _itemVisual;
    [SerializeField]
    private AudioSource _source;
    [SerializeField]
    private AudioClip _pickSfx, _nullSfx;

    [SerializeField]
    private INavigation _navInv;
    [SerializeField]
    private Innventory _innventoryCode;
    private void Start()
    {
        _itemVisual = GetComponent<Image>();
    }
    public void ClickButton()
    {
        _innventoryCode.SelectedObject(_item);

        if (Innventory.Instance._objId != 0)
        {
            StartCoroutine(_navInv.ClickTimer());
            Innventory.Instance.RemoveItem(_item);
        }
        else
        {
            _source.PlayOneShot(_nullSfx);
        }

    }
}
