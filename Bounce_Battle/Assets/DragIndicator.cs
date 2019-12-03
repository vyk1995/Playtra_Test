using UnityEngine;

public class DragIndicator : MonoBehaviour
{
    Vector3 startpos, endpos, camOffset;
    Camera cam;
    LineRenderer LR;
    public Player player;
    
    // Start is called before the first frame update
    void Start()
    {
        camOffset = new Vector3(0, 0, 10);
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //LineRend(); 
    }


    public void LineRend()
    {

       
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray raycast = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(raycast, out hit))
            {
                player = hit.transform.gameObject.GetComponent<Player>();
            }


            if (LR == null)
            {
                LR = gameObject.AddComponent<LineRenderer>();
            }
            GameObject playerGo = player.gameObject;

            LR.enabled = true;
            //set number of positions for the line renderer
            LR.positionCount = 2;
            startpos = playerGo.transform.position;
            LR.SetPosition(0, startpos);
            LR.useWorldSpace = true;
        }
        if (Input.GetMouseButton(0))
        {

            endpos = cam.ScreenToWorldPoint(Input.mousePosition) + camOffset;
            LR.SetPosition(1, endpos);
        }
        if (Input.GetMouseButtonUp(0))
        {
            LR.enabled = false;
            
        }

    }


}
