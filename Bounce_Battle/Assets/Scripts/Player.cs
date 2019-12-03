using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : AnimalBehaviour
{
    //[SerializeField]
    //float health, stamina, maxHealth, maxStamina ;
    //float staminaRegenRate, healthRegenRate;
    //[SerializeField]
    //protected Image healthBar,StaminaBar;

    // Start is called before the first frame update
    void Start()
    {   //initialise current values;
        maxHealth = 10;
        maxStamina = 5;
        health = maxHealth;
        stamina = maxStamina;
        staminaRegenRate = 1;
        healthRegenRate = .2f;

       

    }

    // Update is called once per frame
    void Update()
    {
        UpdateStats();
    }

    protected override void UpdateStats()
    {
        base.UpdateStats();
        //healthBar.fillAmount = health / maxHealth;
        //StaminaBar.fillAmount = stamina / maxStamina;

        //if (health < maxHealth)
        //{
        //    health += healthRegenRate * Time.deltaTime;
        //}
        //if (stamina < maxStamina)
        //{
        //    stamina += staminaRegenRate * Time.deltaTime;
        //}
    }


    private void OnCollisionEnter(Collision col)
    {
        Debug.Log("colliding");
        var pig = col.gameObject.name == "Pig(Clone)";
        var wolf = col.gameObject.GetComponent<Wolf>();
        if (pig)
        {
            maxHealth += 1;
            maxStamina += 1;
            Destroy(col.gameObject);
        }
        if (wolf != null)
        {
            // deal damage
            DealDamge();
        }



    }

    protected override void DealDamge()
    {
        //The more stamina a move use the higher the damage dealt of the character hits an enemy(1 health points per stamina point).
       // Enemies will also move and attack the character, following the same stamina / damage rules.






    }
}
