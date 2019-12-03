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
    Vector3 dragPosition;
    [SerializeField] GameObject indicator;
    public RaycastHit hitObject;
    float indicatorMoveRAdius;



    private void Start()
    {
        indicatorMoveRAdius =2;
        multiplier = 100;
    }

    // Update is called once per frame
    void Update()
    {


        hitObject = ShootRay();

        //upon pressed
        if (Input.GetMouseButtonDown(0))
        {
            var hitplayer = hitObject.transform.gameObject.GetComponent<DragToShoot>();
            if (hitplayer != null)
            {
                indicator.SetActive(true);
                initialPosition = indicator.transform.position;
                Debug.Log("down");
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
          
            //Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.z, 30));

            Debug.Log(dragPosition);
        }
        //upon released
        if (Input.GetMouseButtonUp(0))
        {

            indicator.SetActive(false);
            var dist = Vector3.Distance(indicator.transform.position, initialPosition);           
            var clampedDist = Mathf.Clamp(dist, 0, 3);
            gameObject.GetComponent<Rigidbody>().AddForce((initialPosition - indicator.transform.position) * clampedDist * multiplier);
            indicator.transform.position = transform.position;
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
