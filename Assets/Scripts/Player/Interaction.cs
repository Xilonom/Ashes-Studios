using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Interaction : MonoBehaviour
{
    private enum ItemType
        {
            None = 0,
            Tool = 1,
            CraftSource = 2,
            Resource = 32
        }

    private InventoryManager _inventory;
    private bool _isPressedLMB = false;
    private bool _canGrind = false;
    private GrindItem _currentGrindItem = null;

    void Awake() 
    {
        _inventory = gameObject.GetComponent<InventoryManager>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.gameObject.GetComponent<Item>() != null)
        {
            Item currentItem = col.transform.gameObject.GetComponent<Item>();

            if (currentItem.ThisItemType == (int)ItemType.Tool || currentItem.ThisItemType == (int)ItemType.Resource)
            {
                _inventory.PickUp(col.transform.gameObject);
            }
            else if (currentItem.ThisItemType == (int)ItemType.CraftSource)
            {
                if (_inventory.IsCraftTool())
                {
                    _canGrind = true;
                    _currentGrindItem = col.transform.GetComponent<GrindItem>();
                    print(_currentGrindItem);
                }
            }
            // Destroy(col.transform.gameObject);
        }
    }

    void Grind(bool keyName)
    {
        if (_currentGrindItem != null && keyName == true)
        {
            print("Start grind");
            _currentGrindItem.BreakPart();
        }
    }

    void Update()
    {
        _isPressedLMB = Input.GetMouseButtonDown(0);

        Grind(_isPressedLMB);
    }
}