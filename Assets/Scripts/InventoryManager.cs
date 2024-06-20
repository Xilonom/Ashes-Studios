using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryManager : MonoBehaviour
{
    public GameObject[] Slots;


    public float[] NumberInStack;

    public Text[] Counters;
    public string[] ItemType;
    public GameObject inventory;
    public bool IsOpen = false;
    void Start()
    {
         for(int i = 0; i < ItemType.Length; i++)
         {
            ItemType[i] = "none";
         }
    }


    void Update()
    {
         for(int i = 0; i < Counters.Length; i++)
         {
            Counters[i].text = NumberInStack[i].ToString();
         }
         if (Input.GetKeyDown(KeyCode.E))
         {
            inventory.SetActive(!IsOpen);
            IsOpen = !IsOpen;
         }

    }
}
