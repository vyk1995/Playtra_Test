using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using System;

public class Wolf : AnimalBehaviour
{
    //int health, maxHealth;
    //[SerializeField]
    //private Image healthBar, StaminaBar;
   public  int target;
    public GameObject TargetGO;
    [SerializeField]
   
    float attackinterval;



   
    // Start is called before the first frame update
    void Start()
    {
        targets.Add(GameObject.Find("Chicken(Clone)"));
        foreach (var pig in GameObject.FindGameObjectsWithTag("Pig"))
        {
            targets.Add(pig);
        }
        target = UnityEngine.Random.Range(0, targets.Count);
        
        attackinterval = 0;
        agent = GetComponent<NavMeshAgent>();
        agent.speed = .5f;
        //6-8 -  9  is exclusive
        maxHealth = UnityEngine.Random.Range(6, 9);
        health = maxHealth;
        maxStamina = 5;
        stamina = maxStamina;
        staminaRegenRate = 1;
       
    }





    // Update is called once per frame
    void Update()
    {
        
        TargetGO = targets[target];
        if (TargetGO == null) 
        {           
            target = UnityEngine.Random.Range(0, targets.Count);
        }



        UpdateStats();
        Movement();

      

       


    }

    protected override void OnCollisionEnter(Collision col)
    {
        var pig = col.gameObject.name == "Pig(Clone)";

        var hitplayer = col.gameObject.GetComponent<Player>();

        if (pig)
        {
            maxHealth += 1;
            maxStamina += 1;
            Destroy(col.gameObject);
        }


        if (hitplayer)
        {
            hitplayer.health -= Damage;
        }
    }



    protected override void UpdateStats()
    {
        base.UpdateStats();

        if (health <= 0)
            Destroy(gameObject);

    }


    public void Movement() 
    {
        if (health < 3)
        {
            Debug.Log("health below");
            var player = targets[0];
            if ( player!= null)
            {
                var dist = Vector3.Distance(transform.position, player.transform.position);
                if (dist < 3)
                {
                    var posDiff = transform.position - player.transform.position;

                    agent.SetDestination(transform.position + posDiff);
                    
                }
            }
        }
        else 
        {

            if (TargetGO != null)
            {
                float PlayerDistance = Vector3.Distance(transform.position, TargetGO.transform.position);

                attackinterval -= 1 * Time.deltaTime;

                if (PlayerDistance > 2)
                {
                    agent.isStopped = false;
                    agent.SetDestination(TargetGO.transform.position);
                   
                }
                else
                {
                    //attack          
                    Attack();
                    agent.isStopped = true;
                }

            }

        }
       
        

        

   


    }

    private void Attack()
    {
        var targetStats =TargetGO.GetComponent<Player>();
        int StaminaUse = UnityEngine.Random.Range(1, 6);
        if( attackinterval <= 0) {

            if (StaminaUse <= stamina)
            {
                stamina -= StaminaUse;
                Damage = StaminaUse;
                Debug.Log("attacking");
                attackinterval = 20;
            
                //if (targetStats != null)
                //{
                //    Debug.Log("its not null");
                //    targetStats.health -= Damage;

                //}
            }
        }
        rigBody = gameObject.GetComponent<Rigidbody>();
        rigBody.AddForce(TargetGO.transform.position - transform.position * .6f);
        agent.velocity = rigBody.velocity;


    }



    private void OnDisable()
    {
       
    }
}
