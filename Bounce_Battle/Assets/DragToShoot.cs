using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragToShoot : MonoBehaviour
{

    [SerializeField]
    GameObject playerGo;
    [SerializeField]
    float multiplier;
    Vector3 initialPosition;
    [SerializeField] GameObject indicator;
    public RaycastHit hitObject;
    float indicatorMoveRAdius;
    DragToShoot hitplayer;
    Player PS;

    private void Start()
    {
        PS = GetComponent<Player>();
        indicatorMoveRAdius =2;
        multiplier = 100;
    }

    // Update is called once per frame


    //NOTE: some 3rd party code used   : https://pastebin.com/s5Uxugps
    void Update()
    {


        hitObject = ShootRay();
       
        //upon pressed
        if (Input.GetMouseButtonDown(0))
        {


            hitplayer = hitObject.transform.gameObject.GetComponent<DragToShoot>();
            if (hitplayer != null)
            {
                
                    indicator.SetActive(true);
                    initialPosition = indicator.transform.position;
                
                
                             
            }

        }
        //during press
        if (Input.GetMouseButton(0))
        {
            if (indicator != null) 
            {
                var pos = new Vector3(hitObject.point.x, 1.48f, hitObject.point.z);
               var  maxpos = pos - transform.position;
                maxpos = Vector3.ClampMagnitude(maxpos, indicatorMoveRAdius);
                var temp = transform.position + maxpos;
                indicator.transform.position = temp ;                
            }           
        }
        //upon released
        if (Input.GetMouseButtonUp(0))
        {

            indicator.SetActive(false);
            var dist = Vector3.Distance(indicator.transform.position, initialPosition);           
            var clampedDist = Mathf.Clamp(dist, 0, 3);
            // stores value of 0-1 of stamina cost
            int maxStaminaCost = 5;
            float staminacost = (clampedDist/3) * maxStaminaCost /*PS.maxStamina*/;

            //if (staminacost < PS.stamina)
            //{}
            if (staminacost/2 < PS.stamina)
            {
                PS.Damage = staminacost;
                //reduce stamina by staminacost * maxstamina value to refect the actual cost in the stamina meter/
                PS.stamina -= staminacost;
                PS.Direction = initialPosition - indicator.transform.position;
                gameObject.GetComponent<Rigidbody>().AddForce((initialPosition - indicator.transform.position) * clampedDist * multiplier);
                indicator.transform.position = transform.position;
            }
            
           
        }

    }




    public RaycastHit ShootRay()
    {

        RaycastHit hit;
        Ray raycast = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(raycast, out hit))
        {

            return hit;
        }
        return hit;
    }



}
