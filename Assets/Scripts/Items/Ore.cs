using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ore : MonoBehaviour
{
    public int Health = 5;

    public bool CanBreak = false;

    public GameObject ore;

    

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (GameObject.Find("PlayerPickaxe") != null)
        {
        CanBreak = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {

        
        CanBreak = false;
        
    }

void Update()
{
      if (GameObject.Find("PlayerPickaxe") == null)
      {
        CanBreak = false;
      }
    if (CanBreak == true)
    {
         if (Input.GetMouseButtonDown(0))
        {
            Health -= 1;
        }
    }
    
    if (Health == 0)
    {
        Instantiate(ore, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}
}
