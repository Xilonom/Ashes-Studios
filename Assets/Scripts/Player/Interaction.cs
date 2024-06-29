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

            }
            // Destroy(col.transform.gameObject);
        }
    }
}