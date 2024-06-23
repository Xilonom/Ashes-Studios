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

    public Item[] items;
    public Text[] Counters;
    public int[] Stack;



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
}
