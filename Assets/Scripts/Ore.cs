using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ore : MonoBehaviour
{
    public int Health = 5;

    public bool Triggered = false;

    public GameObject ore;

    

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Pickaxe"))
        {
        Triggered = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Pickaxe"))
        {
        Triggered = false;
        }
    }

void Update()
{
    if (Triggered == true)
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
