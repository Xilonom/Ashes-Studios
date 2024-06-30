using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class InventoryManager : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private GameObject _inventoryUI;
    [SerializeField] private Sprite _unselectedSlotImage;
    [SerializeField] private Sprite _selectedSlotImage;
    [SerializeField] private int _activeSlotIndex = 1;
    

    private string _pressedKeyName = "";

    [Serializable]
    class Slot
    {
        private enum ItemType
        {
            None = 0,
            Tool = 1,
            CraftSource = 2,
            Resource = 32
        }

        [SerializeField] private int _slotNumber;
        private Sprite _defaultItemImage;
        [SerializeField] private Sprite _currentItemImage;
        [SerializeField] private bool _isEmpty = true;
        [SerializeField] private int _currentItemAmount = 0;
        [SerializeField] private int _maxItemAmount;
        [SerializeField] private GameObject _currentItem;
        [SerializeField] private string _currentItemName;
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

        public int CurrentItemAmount
        {
            get { return _currentItemAmount; }
            set { _currentItemAmount = value; }
        }

        public int MaxItemAmount
        {
            get { return _maxItemAmount; }
        }

        public string CurrentItemName
        {
            get { return _currentItemName; }
        }

        public GameObject CurrentItem
        {
            get { return _currentItem; }
        }

        public GameObject CurrentItemAmountUI
        {
            get { return _currentItemAmountUI; }
            set { _currentItemAmountUI = value; }
        }

        public int CurrentItemType
        {
            get { return Convert.ToInt32(_itemType); }
        }

        public Slot(int slotNumber, Sprite currentItemImage, bool isEmpty, GameObject currentItem, int itemType, GameObject inventoryUI)
        {
            _slotNumber = slotNumber;
            _currentItemImage = currentItemImage;
            _isEmpty = isEmpty;
            _currentItem = currentItem;
            _itemType = (ItemType)itemType;
            _currentItemName = (string)currentItem.GetComponent<Item>().Name;
            
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
        var checkSlot = IsItemInInventory(item);

        if (checkSlot == -1)
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
        else
        {
            if(IsStackFull(_slots[checkSlot - 1]) == false)
            {
                _slots[checkSlot - 1].CurrentItemAmount++;
                _slots[checkSlot - 1].CurrentItemAmountUI.transform.GetChild(1).GetComponent<Text>().text = _slots[checkSlot - 1].CurrentItemAmount.ToString();
                item.SetActive(false);
            }
        }

    }

    void EquipSlot()
    {

    }

    void SelectSlot(string keyName)
    {
        int tempKey;

        bool isNumeric = int.TryParse(keyName, out tempKey);
        
        if (isNumeric == false)
            return;

        if (1 <= tempKey && tempKey <= 3)
        {
            _activeSlotIndex = Convert.ToInt32(keyName);

            UnselectAllSlots();

            GameObject selectedSlot = _inventoryUI.transform.GetChild(_activeSlotIndex - 1).gameObject;
            selectedSlot.GetComponent<Image>().sprite = _selectedSlotImage;
        }
    }

    void UnselectAllSlots()
    {
        for (int i = 0; i < 3; i++)
        {
            _inventoryUI.transform.GetChild(i).gameObject.GetComponent<Image>().sprite = _unselectedSlotImage;
        }
    }

    void CheckForEquip()
    {

    }

    int IsItemInInventory(GameObject item)
    {
        Debug.Log(item.GetComponent<Item>().Name);
        foreach(Slot currentSlot in _slots)
        {
            if (currentSlot.CurrentItem == null)
                continue;

            if (currentSlot.CurrentItemName == item.GetComponent<Item>().Name)
                return currentSlot.SlotNumber;  // && IsStackFull(currentSlot) == false)
        }

        return -1;
    }

    bool IsStackFull(Slot currentSlot)
    {
        return (currentSlot.CurrentItemAmount >= currentSlot.MaxItemAmount);
    }

    void Update()
    {
        _pressedKeyName = Input.inputString;

        SelectSlot(_pressedKeyName);
        
        if (_activeSlotIndex != 0 && _slots[_activeSlotIndex-1].CurrentItemType == 1)
        {
            Debug.Log("Tool is active");
        }

    }
}
