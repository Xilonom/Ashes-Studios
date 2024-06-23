using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UseItem : MonoBehaviour
{
    public InventoryManager inventory;

    public int Slot;

    public bool CanBuild;

    private GameObject[] Player;

    public GameObject SlotObj;

    void Start()
    {
        Player = GameObject.FindGameObjectsWithTag("Player");
    }
    public void Use()
    {
        if (inventory.items[Slot] == null)
        {


        }
        else
        {
        
        if (inventory.items[Slot].Type == "building")
        {
            CanBuild = true;
        }


        }
    }

    private void Update() 
    {


        if (CanBuild == true)
        {
            

            SlotObj.GetComponent<Image>().sprite = inventory.SelectImage;
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
               
                CanBuild = false;
                SlotObj.GetComponent<Image>().sprite = inventory.DefaultImage;
            }
            if (Input.GetMouseButtonDown(0))
            {
                if (CanBuild == true)
                {
                var mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mouseWorldPos.z = 0f;
                inventory.Stack[Slot] -= 1;
                CanBuild = false;
                SlotObj.GetComponent<Image>().sprite = inventory.DefaultImage;
                Instantiate(inventory.items[Slot].ObjectPrefab, mouseWorldPos, Quaternion.identity);
                }

            }
        }
    }

}
