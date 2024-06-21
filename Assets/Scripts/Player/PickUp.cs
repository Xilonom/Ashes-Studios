using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PickUp : MonoBehaviour
{
    public Sprite ItemImage;
    public string itemName;

    public GameObject Parent;
    public float Stack;

    public InventoryManager inventory;

   public void OnTriggerEnter2D(Collider2D other) 
   {
    if (other.CompareTag("Player"))
    {
        for(int i = 0; i < inventory.Slots.Length; i++)
        {
            if (inventory.ItemType[i] == itemName || inventory.ItemType[i] == "none")
            {

            
            inventory.ItemType[i] = itemName;
            inventory.NumberInStack[i] += Stack;
            inventory.Slots[i].GetComponent<Image>().sprite = ItemImage;
                        Destroy(Parent);
            break;


            }

        }

    }
   }
    void Update()
    {
        
    }
}
