using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pig : AnimalBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = 2;
        targets.Add(GameObject.Find("Chicken(Clone)"));
        foreach (var pig in GameObject.FindGameObjectsWithTag("Wolf"))
        {
            targets.Add(pig);
        }



    }

    // Update is called once per frame
    void Update()
    {

        MoveAway();

    }

    private void MoveAway()
    {
        foreach (var target in targets)
        {
            if (target != null)
            {
                var dist = Vector3.Distance(transform.position, target.transform.position);
                if (dist < 3)
                {
                    var posDiff = transform.position - target.transform.position;

                    agent.SetDestination(transform.position + posDiff);


                }
            }
        }
    }



}
