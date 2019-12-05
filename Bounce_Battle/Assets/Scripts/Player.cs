using UnityEngine;

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
       // Debug.Log(rigBody.velocity.magnitude);

        UpdateStats();
    }

    protected override void UpdateStats()
    {
        base.UpdateStats();        
    }


    protected override void OnCollisionEnter(Collision col)
    {
        Vector3 Direction = col.contacts[0].point - transform.position;

        
        var pig = col.gameObject.name == "Pig(Clone)";
        var wolf = col.gameObject.GetComponent<Wolf>();
        if (pig)
        {
            health = maxHealth;
            maxHealth += 1;
            maxStamina += 1;
            Destroy(col.gameObject);         

        }

        
        if (wolf != null )
        {
            wolf.health -= Damage;
            wolf.gameObject.GetComponent<Rigidbody>().AddForce((Direction.normalized) * 100);
            // deal damage

        }



    }


    void OnDestroy()
    {
        if (targets.Contains(gameObject))
        {
            targets.Remove(gameObject);
            Debug.Log("target removed ");
        }
    }

    protected override void DealDamge()
    {
        //The more stamina a move use the higher the damage dealt of the character hits an enemy(1 health points per stamina point).
       // Enemies will also move and attack the character, following the same stamina / damage rules.






    }
}
