using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerStats : MonoBehaviour
{

    public float health = 100;
    public Image HealthBar;
    public GameObject player;

    void Start()
    {
        
    }


    void Update()
    {
        HealthBar.fillAmount = health/100;
    }

    public void ChangeHealth(float value)
    {
        health += value;
    }


    
}
