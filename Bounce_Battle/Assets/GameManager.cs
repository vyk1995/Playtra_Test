using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int pigAmount, woflAmount;
    [SerializeField]
    //0=player,1=pig, 2= wolf
    private GameObject[] AnimalGO;
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        pigAmount = Random.Range(2, 5);
        woflAmount =  Random.Range(4, 7);
        Debug.Log("amount of pigs : " + pigAmount);
        Debug.Log("amount of wolves : " + woflAmount);
        InstantiateAnimals(pigAmount,woflAmount);
    }

    // Update is called once per frame
    void Update()
    {
        
    }





    void InstantiateAnimals(int pigs, int wolves) 
    {
        var chicken = Instantiate(AnimalGO[0], new Vector3(5, 5, 5), Quaternion.identity);
        player = chicken.GetComponent<Player>();

        //spawn inside unit sphere
        
        //spawn pigs
        for (int i = 0; i <pigs; i++)
        {
            Vector3 randomSpawnVec = new Vector3(3f,3f,3f);
            Instantiate(AnimalGO[1],randomSpawnVec,Quaternion.identity);
        }
        //spawn wolves 
        for (int i = 0; i<wolves; i++)
        {
            Vector3 randomSpawnVec2 = new Vector3(3f, 3f, 3f);
            Instantiate(AnimalGO[2], randomSpawnVec2, Quaternion.identity);
        }

    
    
    }
}
