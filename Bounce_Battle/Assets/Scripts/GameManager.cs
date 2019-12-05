using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int pigAmount, woflAmount;
    [SerializeField]    
    //0=player,1=pig, 2= wolf
    private GameObject[] AnimalGO;
    [SerializeField]  
    private GameObject spawnPoint,platform;
    private Player player;
    private float scatterRadius;
    //List<Collider> spawnedPostions = new List<Collider>();
    public Collider[] cols;
     public LayerMask filtermask;
    public TextMeshProUGUI text1;
    public GameObject panel;
 
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        scatterRadius = platform.GetComponent<CapsuleCollider>().radius * (platform.transform.localScale.x - 2);        
        pigAmount = Random.Range(2, 5);
        woflAmount =  Random.Range(4, 7);        
        InstantiateAnimals(pigAmount,woflAmount);
    }

    // Update is called once per frame
    void Update()
    {
        

   
    }

   
   


    void InstantiateAnimals(int pigs, int wolves) 
    {
        //+1 for chicken.
        int totalAnimalCount = wolves + pigs+1;
        for (int i = 0; i <totalAnimalCount; i++)
        {
            Vector3 tempPos;
            Vector3 spawnPosition = Vector3.zero;           
            bool allowedToSpawn = false;
            //while not allowed to spawn check for new positions
            while (!allowedToSpawn)
            {
                //spawn inside unit sphere 
                tempPos = spawnPoint.transform.position + Random.insideUnitSphere * scatterRadius;
                spawnPosition = new Vector3(tempPos.x, spawnPoint.transform.position.y, tempPos.z);
                allowedToSpawn = CheckOverlap(spawnPosition);

                if (allowedToSpawn)
                {
                    break;
                }
            }

            if (i < wolves)
            {
              var wolf =   Instantiate(AnimalGO[2], spawnPosition, Quaternion.identity);
                
            }
            else if (i > wolves && i !=totalAnimalCount)
            {

                var pig = Instantiate(AnimalGO[1], spawnPosition, Quaternion.identity);
              
            }
            else 
            {
               var go =  Instantiate(AnimalGO[0], spawnPosition, Quaternion.identity);
                player = go.GetComponent<Player>();
                
            }
            
        }
    }


    bool CheckOverlap(Vector3 spawnpostion)
    {
        cols = Physics.OverlapSphere(platform.transform.position, scatterRadius,filtermask);       

        for (int i = 0; i < cols.Length; i++)
        {           

            Vector3 center = cols[i].bounds.center;
            float distance = Vector3.Distance(center, spawnpostion);            
            if (distance < 1.8f) 
            {                               
                return false;            
            }
        }       
        return true;
    }

    

   public RaycastHit RaycastMove ()
    {
        RaycastHit hit;
        Ray raycast = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(raycast, out hit))
        {
            return hit;
        }
        return hit;
    }



   public void GameWin()
    {
        panel.SetActive(true);
        text1.text = "VICTORY!";
        Time.timeScale = 0;
    }

   public void GameOver() 
    {
        panel.SetActive(true);
        Time.timeScale = 0;
        text1.text = "GameOver";

    
    }


    public void PlayAgain() 
    {
        panel.SetActive(false);        
        SceneManager.LoadScene(0);

    }




}



