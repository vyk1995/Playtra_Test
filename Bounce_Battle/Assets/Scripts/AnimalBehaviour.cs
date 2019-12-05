using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;


public class AnimalBehaviour : MonoBehaviour
{
    public float health, stamina, maxHealth, maxStamina, Damage;
    public float staminaRegenRate, healthRegenRate;   
    public Image healthBar, StaminaBar;
    public Vector3 Direction;
    protected NavMeshAgent agent;
    protected GameManager gm;
    [SerializeField]
    protected List<GameObject> targets = new List<GameObject>();
    protected Rigidbody rigBody;

    // Start is called before the first frame update
    void Start()
    {   //initialise current values;

       
      
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

    protected virtual void UpdateStats()
    {
        healthBar.fillAmount = health / maxHealth;
  
        StaminaBar.fillAmount = stamina / maxStamina;

        if (health < maxHealth)
        {
            health += healthRegenRate * Time.deltaTime;
        }
        if (stamina < maxStamina )
        {
            stamina += staminaRegenRate * Time.deltaTime;
        }
    }

    protected virtual void OnCollisionEnter(Collision col)
    {
        //Debug.Log("colliding");
        //var pig = col.gameObject.name == "Pig(Clone)";
        //var wolf = col.gameObject.GetComponent<Wolf>();
        //var hitplayer = col.gameObject.GetComponent<Player>();
    
        //if (wolf != null)
        //{
        //    // deal damage
        //    DealDamge();
        //}

        //if (hitplayer) 
        //{
        //    hitplayer.health -= Damage;
        //}



    }
    private void OnDisable()
    {
        targets.Remove(gameObject);
    }


    protected virtual void DealDamge()
    {
        //The more stamina a move use the higher the damage dealt of the character hits an enemy(1 health points per stamina point).
        // Enemies will also move and attack the character, following the same stamina / damage rules.






    }




}
