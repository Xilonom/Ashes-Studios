using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PickUp : MonoBehaviour
{
    private InventoryManager _inventory;

    void Awake() 
    {
        _inventory = gameObject.GetComponent<InventoryManager>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.gameObject.GetComponent<Item>() != null)
        {
            _inventory.PickUp(col.transform.gameObject);
            // Destroy(col.transform.gameObject);
        }
    }
}