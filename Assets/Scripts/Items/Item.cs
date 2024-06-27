using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
   private enum ItemType
        {
            None = 0,
            Tool = 1,
            Resource = 32
        }
   [SerializeField] private ItemType _type = ItemType.None;
   [SerializeField] private string _name;
   [SerializeField] private Sprite _itemImage;

   public int ThisItemType 
   { 
      get { return (int)_type; }
   }

   public string Name
   {
      get { return _name; }
      private set { _name = value; }
   }

   public Sprite ItemImage
   {
      get { return _itemImage; }
      private set { _itemImage = value; }
   }
}
