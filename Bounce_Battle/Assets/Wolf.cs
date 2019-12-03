using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wolf : AnimalBehaviour
{
    //int health, maxHealth;
    //[SerializeField]
    //private Image healthBar, StaminaBar;

    // Start is called before the first frame update
    void Start()
    {
        //6-8
        maxHealth = Random.Range(6, 9);
        health = maxHealth;
        
    }




    protected override void UpdateStats() 
    {
    
    
    }
    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = health / maxHealth;



    }
  
}
