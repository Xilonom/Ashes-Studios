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

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.transform.gameObject.GetComponent<Item>() != null)
        {
            _inventory.PickUp(other.transform.gameObject);
            Destroy(other.transform.gameObject);
        }
    }
}