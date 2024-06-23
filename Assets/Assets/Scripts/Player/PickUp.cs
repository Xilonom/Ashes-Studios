using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PickUp : MonoBehaviour
{
    public Item item;
    private InventoryManager inventory;

    private bool given = false;




     void Awake() 
     {
        inventory = GameObject.Find("InventoryManager").GetComponent<InventoryManager>();

       
     }
    void Update() 
    {

    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
         for (int i = 0;i < inventory.Slots.Length;i++)
         {

            if (inventory.items[i] != null)
            {
             if (inventory.items[i].Name == item.Name)
                {
                    inventory.Stack[i] += 1;
                    given = true;
                    Destroy(gameObject);
                    break;
                }
            }
         }
          for(int i = 0; i < inventory.Slots.Length; i++)
          {
            if (given == false)
            {
            if (inventory.items[i] == null)
            {
                inventory.ItemImages[i].SetActive(true);
                inventory.ItemImages[i].GetComponent<Image>().sprite = item.ItemImage;
                inventory.items[i] = item;
                inventory.Stack[i] += 1;
                Destroy(gameObject);
                break;
            }
            }

         }
        }
    }
}
