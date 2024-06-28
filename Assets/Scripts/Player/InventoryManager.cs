using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class InventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject _inventoryUI;

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
        [SerializeField] private GameObject _currentItemAmountUI;
        [SerializeField] private ItemType _itemType = ItemType.None;

        public bool IsEmpty 
        { 
            get { return _isEmpty; }
        }

        public int SlotNumber
        {
            get { return _slotNumber; }
        }

        public Sprite CurrentItemImage
        {
            get { return _currentItemImage; }
            set { _currentItemImage = value; }
        }

        public Slot(int slotNumber, Sprite currentItemImage, bool isEmpty, GameObject currentItem, int itemType, GameObject inventoryUI)
        {
            _slotNumber = slotNumber;
            _currentItemImage = currentItemImage;
            _isEmpty = isEmpty;
            _currentItem = currentItem;
            _itemType = (ItemType)itemType;

            
            foreach (Transform childUI in inventoryUI.transform)
            {
                Debug.Log(childUI.name);
                if (childUI.name == $"Slot{slotNumber}")
                {
                    _currentItemAmountUI = childUI.gameObject;
                    break;
                }
            }

            GameObject slotText = _currentItemAmountUI.transform.GetChild(1).gameObject;

            GameObject slotImage = _currentItemAmountUI.transform.GetChild(0).gameObject;
            slotImage.GetComponent<Image>().sprite = _currentItemImage;

            if (_itemType == ItemType.Tool)
            {
                _currentItemAmount = 1;
                _maxItemAmount = 1;
                slotText.GetComponent<Text>().text = _currentItemAmount.ToString();
            }
            else if (_itemType == ItemType.Resource)
            {
                _currentItemAmount = 1;
                _maxItemAmount = (int)ItemType.Resource;
                slotText.GetComponent<Text>().text = _currentItemAmount.ToString();
            }
        }
    }

    //public GameObject[] ItemImages;
    
    [SerializeField] private Slot[] _slots;  
    

    private GameObject _player;

    void Start()
    {
        _player = gameObject;  
    }

    int CheckForEmptySlots()
    {
        foreach(var slot in _slots)
        {
            if(slot.IsEmpty == true)
                return slot.SlotNumber;
        }

        return -1;
    }

    public void PickUp(GameObject item)
    {
        int tempEmptySlotNumber = CheckForEmptySlots();

        if(tempEmptySlotNumber == -1)
        {
            Debug.Log("Can't pickup this item! No empty inventory slots!");
            return;
        }

        var itemComponent = item.GetComponent<Item>();

        _slots[tempEmptySlotNumber - 1] = new Slot(tempEmptySlotNumber, 
                                                   itemComponent.ItemImage, 
                                                   false, 
                                                   item,
                                                   itemComponent.ThisItemType,
                                                   _inventoryUI);
        
        item.SetActive(false);
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
