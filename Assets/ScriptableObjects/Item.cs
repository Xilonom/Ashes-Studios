using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Item", menuName = "Item", order = 0)]
public class Item : ScriptableObject 
{
   public string Type;
   public string Name;
   public Sprite ItemImage;

   public GameObject ObjectPrefab;

}
