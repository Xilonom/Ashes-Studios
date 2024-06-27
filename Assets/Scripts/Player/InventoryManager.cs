using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class InventoryManager : MonoBehaviour
{
    [Serializable]
    class Slot
    {
        private enum ItemType
        {
            None = 0,
            Tool = 1,
            Resource = 32
        }

        [SerializeField] private int _slotNumber;
        private Sprite _defaultItemImage;
        [SerializeField] private Sprite _currentItemImage;
        [SerializeField] private bool _isEmpty = true;
        [SerializeField] private int _currentItemAmount = 0;
        [SerializeField] private int _maxItemAmount;
        [SerializeField] private GameObject _currentItem;
        [SerializeField] private Text _currentItemAmountUI;
        [SerializeField] private ItemType _itemType = ItemType.None;

        public bool IsEmpty 
        { 
            get { return _isEmpty; }
        }

        public int SlotNumber
        {
            get { return _slotNumber; }
        }
    }

    //public GameObject[] ItemImages;
    [SerializeField] private GameObject _inventoryUI;
    [SerializeField] private Slot[] _slots = new Slot[3];  
    

    private GameObject _player;

    void Start()
    {
        _player = gameObject;  
    }

    int CheckForEmptySlots()
    {
        foreach(var slot in _slots)
        {
            if(slot.IsEmpty)
                return slot.SlotNumber;
        }

        return -1;
    }

    public void PickUp(GameObject item)
    {
        int tempEmptySlotNumber = CheckForEmptySlots();

        if(tempEmptySlotNumber == -1)
        {
            Debug.Log("Can't pickup this item!");
            return;
        }


    }

    void EquipSlot()
    {

    }

    void SelectSlot()
    {

    }



    void CheckForEquip()
    {

    }

    void CheckItem(int Slot)
    {

    }

    void Update()
    {

    }
}
