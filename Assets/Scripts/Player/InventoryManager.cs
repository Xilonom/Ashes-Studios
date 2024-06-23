using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryManager : MonoBehaviour
{


    public GameObject[] ItemImages;
    public GameObject[] Slots;  

    public Sprite SelectImage;

    public Sprite DefaultImage;

    private GameObject Player;

    public Item[] items;
    public Text[] Counters;
    public int[] Stack;

    public bool[] SlotEquipped;


    void Start()
    {
        GameObject[] PlayerTag = GameObject.FindGameObjectsWithTag("Player");

        Player = PlayerTag[0];
        
    }


    void FixedUpdate()
    {
          for(int i = 0; i < Slots.Length; i++)
          {
            Counters[i].text = Stack[i].ToString();
          }

        for(int i = 0; i < Slots.Length; i++)
        {
            if (Stack[i] == 0)
            {
                ItemImages[i].SetActive(false);
                items[i] = null;
            }
            else
            {
                ItemImages[i].SetActive(true);
            }
        }
    }


    

    void EquipSlot()
    {
        if (Input.GetKeyDown("1"))
        {
            for (int i = 0; i < Slots.Length; i++)
            {
                SlotEquipped[i] = false;
            }
            SlotEquipped[0] = true;
        }
        if (Input.GetKeyDown("2"))
        {
            for (int i = 0; i < Slots.Length; i++)
            {
                SlotEquipped[i] = false;
            }
            SlotEquipped[1] = true;
        }
        if (Input.GetKeyDown("3"))
        {
            for (int i = 0; i < Slots.Length; i++)
            {
                SlotEquipped[i] = false;
            }
            SlotEquipped[2] = true;
        }
    }

    void SelectSlot()
    {
         for (int i = 0;i < SlotEquipped.Length; i++)
             {
                if (SlotEquipped[i] == true)
                {
                    Slots[i].GetComponent<Image>().sprite = SelectImage;
                }
                else
                {
                    Slots[i].GetComponent<Image>().sprite = DefaultImage;
                }
             }
    }



    void CheckForEquip()
    {
         for (int i = 0;i < items.Length; i++)
            {
                if (SlotEquipped[i] == true)
                {
                    CheckItem(i);
                }
                if (SlotEquipped[i] == false)
                {
                    if (items[i] != null)
                    {
                        if (items[i].Type != null)
                        {
                        if (items[i].Type == "pickaxe") 
                        {
                            Destroy(GameObject.Find("PlayerPickaxe"));
                        }
                        }
                }
                }
            }
            
    }

    void CheckItem(int Slot)
    {

        if (items[Slot] != null)
        {
        if (items[Slot].Type != null)
        {

            if (items[Slot].Type == "building")
            {
                if (Input.GetMouseButtonDown(0))
                {
               
                
                var mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mouseWorldPos.z = 0f;
                Stack[Slot] -= 1;
                Instantiate(items[Slot].ObjectPrefab, mouseWorldPos, Quaternion.identity);
                
                }
            }
            if (items[Slot].Type == "pickaxe")
            {


                if (GameObject.Find("PlayerPickaxe") == null)
                {
                    GameObject pickaxe = Instantiate(items[Slot].ObjectPrefab, Player.transform.position + new Vector3(0.85f,0,0), Quaternion.identity);

                    pickaxe.name = "PlayerPickaxe";

                  

                }
                GameObject.Find("PlayerPickaxe").transform.position = Player.transform.position + new Vector3(0.85f,0,0);
               

            }





        }
        }
    }

    void Update()
    {
        EquipSlot();

        CheckForEquip();
        SelectSlot();
    }
}
